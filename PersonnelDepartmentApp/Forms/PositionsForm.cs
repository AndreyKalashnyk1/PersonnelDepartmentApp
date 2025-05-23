using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PersonnelDepartmentApp.Models;
using PersonnelDepartmentApp.Services;

namespace PersonnelDepartmentApp
{
    public partial class PositionsForm : Form
    {
        private List<Position> positions;
        private List<Position> allPositions;
        private List<Position> displayedPositions;
        private FileService fileService;
        private int? editingPositionId = null;
        private string lastSortedColumn = null;
        private bool lastSortAsc = true;
        private EmployeeService employeeService = new EmployeeService();
        private List<Employee> employees;
        private string lastEmpSortedColumn = null;
        private bool lastEmpSortAsc = true;
        private List<Employee> displayedEmployees;


        private PositionService positionService = new PositionService();

        public static PositionsForm GetForm()
        {
            PositionsForm ThisForm = new PositionsForm();
            ThisForm.StartPosition = FormStartPosition.CenterScreen;

            return ThisForm;
        }
        public PositionsForm()
        {
            InitializeComponent();
            fileService = new FileService();
            groupBoxPositionEdit.Visible = false;
            txtSearchPositions.KeyDown += txtSearchPositions_KeyDown;
            txtSearchPositions.TextChanged += txtSearchPositions_TextChanged;
            dgvPositions.ColumnHeaderMouseClick += dgvPositions_ColumnHeaderMouseClick;
            btnSearchEmployees.Click += btnSearchEmployees_Click;
            txtSearchEmployees.TextChanged += txtSearchEmployees_TextChanged;
            txtSearchEmployees.KeyDown += txtSearchEmployees_KeyDown;
            btnResetEmpSort.Click += btnResetEmpSort_Click;
            dgvEmployeesWithPositions.ColumnHeaderMouseClick += dgvEmployeesWithPositions_ColumnHeaderMouseClick;

        }

        private void PositionsForm_Load(object sender, EventArgs e)
        {
            LoadPositions();
            LoadEmployeesWithPositions();
            groupBoxPositionEdit.Visible = false;
        }

        private void LoadPositions()
        {
            positions = positionService.GetPositions();
            allPositions = new List<Position>(positions);
            displayedPositions = new List<Position>(positions);

            dgvPositions.DataSource = displayedPositions
                .Select(p => new { p.Id, p.Title, p.Salary, p.Requirements })
                .ToList();
            dgvPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void LoadEmployeesWithPositions()
        {
            employees = employeeService.GetEmployees();
            dgvEmployeesWithPositions.DataSource = employees
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Position = emp.PositionId.HasValue
                        ? positions.FirstOrDefault(p => p.Id == emp.PositionId.Value)?.Title ?? "—"
                        : "—"

                })
                .ToList();
            dgvEmployeesWithPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            editingPositionId = null;
            txtPositionTitle.Text = "";
            txtPositionSalary.Text = "";
            txtPositionRequirements.Text = "";
            groupBoxPositionEdit.Text = "Додати посаду";
            groupBoxPositionEdit.Visible = true;
        }

        private void btnEditPosition_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть посаду для редагування.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells[0].Value);
            var position = positions.FirstOrDefault(p => p.Id == positionId);
            if (position == null)
            {
                MessageBox.Show("Посаду не знайдено. Оновіть список.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            editingPositionId = position.Id;
            txtPositionTitle.Text = position.Title;
            txtPositionSalary.Text = position.Salary.ToString("F2");
            txtPositionRequirements.Text = position.Requirements;
            groupBoxPositionEdit.Text = "Редагувати посаду";
            groupBoxPositionEdit.Visible = true;
        }

        private void btnDeletePosition_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть посаду для видалення.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells[0].Value);
            var confirm = MessageBox.Show(
                "Ви дійсно бажаєте видалити посаду?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                positionService.DeletePosition(positionId);
                LoadPositions();
                LoadEmployeesWithPositions();
                MessageBox.Show("Посаду успішно видалено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvPositions.Focus();
        }

        private void btnSavePosition_Click(object sender, EventArgs e)
        {
            var title = txtPositionTitle.Text.Trim();
            var requirements = txtPositionRequirements.Text.Trim();
            decimal salary;
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Введіть назву посади.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtPositionSalary.Text, out salary))
            {
                MessageBox.Show("Введіть коректну зарплату.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (editingPositionId == null)
            {
                var newPosition = new Position { Title = title, Salary = salary, Requirements = requirements };
                positionService.AddPosition(newPosition);
                MessageBox.Show("Посаду додано.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var updatedPosition = new Position
                {
                    Id = editingPositionId.Value,
                    Title = title,
                    Salary = salary,
                    Requirements = requirements
                };
                positionService.EditPosition(editingPositionId.Value, updatedPosition);
                MessageBox.Show("Посаду відредаговано.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            groupBoxPositionEdit.Visible = false;
            LoadPositions();
            LoadEmployeesWithPositions();
        }

        private void btnCancelPositionEdit_Click(object sender, EventArgs e)
        {
            groupBoxPositionEdit.Visible = false;
        }

        private void btnReloadPositions_Click(object sender, EventArgs e)
        {
            positionService.ReloadPositions();
            LoadPositions();
            LoadEmployeesWithPositions();
        }

        private void btnSearchPositions_Click(object sender, EventArgs e)
        {
            string search = txtSearchPositions.Text.Trim().ToLower();
            var filtered = positions
                .Where(p => p.Title != null && p.Title.ToLower().Contains(search))
                .Select(p => new { p.Id, p.Title, p.Salary, p.Requirements })
                .ToList();
            dgvPositions.DataSource = filtered;
        }

        private void txtSearchPositions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchPositions_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtSearchPositions_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchPositions.Text))
            {
                dgvPositions.DataSource = positions
                    .Select(p => new { p.Id, p.Title, p.Salary, p.Requirements })
                    .ToList();
            }
        }

        private void dgvPositions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (displayedPositions == null)
            {
                displayedPositions = positions != null
                    ? new List<Position>(positions)
                    : new List<Position>();
            }
            string columnName = dgvPositions.Columns[e.ColumnIndex].DataPropertyName;
            if (lastSortedColumn == columnName)
                lastSortAsc = !lastSortAsc;
            else
                lastSortAsc = true;
            lastSortedColumn = columnName;

            Func<Position, object> keySelector;
            switch (columnName)
            {
                case "Id":
                    keySelector = p => p.Id;
                    break;
                case "Title":
                    keySelector = p => p.Title;
                    break;
                case "Salary":
                    keySelector = p => p.Salary;
                    break;
                case "Requirements":
                    keySelector = p => p.Requirements;
                    break;
                default:
                    keySelector = p => p.Id;
                    break;
            }

            if (lastSortAsc)
                displayedPositions = displayedPositions.OrderBy(keySelector).ToList();
            else
                displayedPositions = displayedPositions.OrderByDescending(keySelector).ToList();

            dgvPositions.DataSource = displayedPositions
                .Select(p => new { p.Id, p.Title, p.Salary, p.Requirements })
                .ToList();
        }

        private void btnResetSort_Click_1(object sender, EventArgs e)
        {
            displayedPositions = new List<Position>(allPositions);
            dgvPositions.DataSource = displayedPositions
                .Select(p => new { p.Id, p.Title, p.Salary, p.Requirements })
                .ToList();
            lastSortedColumn = null;
        }

        private void btnAssignPosition_Click(object sender, EventArgs e)
        {
            if (positions == null || positions.Count == 0)
            {
                MessageBox.Show("Будь ласка, спочатку оновіть список посад.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("Список працівників порожній.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvEmployeesWithPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть працівника для призначення посади.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть посаду для призначення.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployeesWithPositions.SelectedRows[0].Cells[0].Value);
            int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells[0].Value);

            var selectedEmployee = employees.FirstOrDefault(emp => emp.Id == employeeId);
            var selectedPosition = positions.FirstOrDefault(p => p.Id == positionId);

            if (selectedEmployee == null || selectedPosition == null)
            {
                MessageBox.Show("Помилка вибору працівника або посади.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedEmployee.PositionId = selectedPosition.Id;
            employeeService.SaveEmployees();


            LoadEmployeesWithPositions();

            MessageBox.Show("Посаду призначено працівнику.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnRemovePositionFromEmployee_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("Список працівників порожній.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvEmployeesWithPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть працівника для видалення посади.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployeesWithPositions.SelectedRows[0].Cells[0].Value);
            var selectedEmployee = employees.FirstOrDefault(emp => emp.Id == employeeId);

            if (selectedEmployee == null)
            {
                MessageBox.Show("Працівник не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!selectedEmployee.PositionId.HasValue)
            {
                MessageBox.Show("У цього працівника вже не вказано посаду.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Ви дійсно бажаєте видалити посаду у цього працівника?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                selectedEmployee.PositionId = null;
                employeeService.SaveEmployees();

                LoadEmployeesWithPositions();

                MessageBox.Show("Посаду у працівника видалено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvEmployeesWithPositions.Focus();
        }

        private void btnSearchEmployees_Click(object sender, EventArgs e)
        {
            string search = txtSearchEmployees.Text.Trim().ToLower();

            var filtered = employees
                .Where(emp =>
                    $"{emp.LastName} {emp.FirstName} {emp.MiddleName}".ToLower().Contains(search) ||
                    (emp.PositionId.HasValue && positions.FirstOrDefault(p => p.Id == emp.PositionId.Value)?.Title.ToLower().Contains(search) == true)
                )
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Position = emp.PositionId.HasValue
                        ? positions.FirstOrDefault(p => p.Id == emp.PositionId.Value)?.Title ?? "—"
                        : "—"
                })
                .ToList();

            dgvEmployeesWithPositions.DataSource = filtered;
        }

        private void txtSearchEmployees_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchEmployees.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(search))
            {
                LoadEmployeesWithPositions();
                return;
            }

            var filtered = employees
                .Where(emp =>
                    $"{emp.LastName} {emp.FirstName} {emp.MiddleName}".ToLower().Contains(search) ||
                    (emp.PositionId.HasValue && positions.FirstOrDefault(p => p.Id == emp.PositionId.Value)?.Title.ToLower().Contains(search) == true)
                )
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Position = emp.PositionId.HasValue
                        ? positions.FirstOrDefault(p => p.Id == emp.PositionId.Value)?.Title ?? "—"
                        : "—"
                })
                .ToList();

            dgvEmployeesWithPositions.DataSource = filtered;
        }
        private void txtSearchEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchEmployees_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void dgvEmployeesWithPositions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (displayedEmployees == null)
                displayedEmployees = new List<Employee>(employees);

            string columnName = dgvEmployeesWithPositions.Columns[e.ColumnIndex].DataPropertyName;
            if (lastEmpSortedColumn == columnName)
                lastEmpSortAsc = !lastEmpSortAsc;
            else
                lastEmpSortAsc = true;
            lastEmpSortedColumn = columnName;

            Func<Employee, object> keySelector;
            switch (columnName)
            {
                case "Id":
                    keySelector = emp => emp.Id;
                    break;
                case "FullName":
                    keySelector = emp => $"{emp.LastName} {emp.FirstName} {emp.MiddleName}";
                    break;
                case "Position":
                    keySelector = emp => emp.PositionId.HasValue
                        ? positions.FirstOrDefault(p => p.Id == emp.PositionId.Value)?.Title ?? ""
                        : "";
                    break;
                default:
                    keySelector = emp => emp.Id;
                    break;
            }

            if (lastEmpSortAsc)
                displayedEmployees = displayedEmployees.OrderBy(keySelector).ToList();
            else
                displayedEmployees = displayedEmployees.OrderByDescending(keySelector).ToList();

            dgvEmployeesWithPositions.DataSource = displayedEmployees
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Position = emp.PositionId.HasValue
                        ? positions.FirstOrDefault(p => p.Id == emp.PositionId.Value)?.Title ?? "—"
                        : "—"
                })
                .ToList();
        }

        private void btnResetEmpSort_Click(object sender, EventArgs e)
        {
            displayedEmployees = new List<Employee>(employees);
            dgvEmployeesWithPositions.DataSource = displayedEmployees
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Position = emp.PositionId.HasValue
                        ? positions.FirstOrDefault(p => p.Id == emp.PositionId.Value)?.Title ?? "—"
                        : "—"
                })
                .ToList();
            lastEmpSortedColumn = null;
        }

        private void txtSearchPositions_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnGenerateAppointOrder_Click(object sender, EventArgs e)
        {
            if (dgvEmployeesWithPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть співробітника для формування наказу.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployeesWithPositions.SelectedRows[0].Cells["ID"].Value);
            Employee emp = employeeService.GetEmployeeById(employeeId);

            // Отримуємо посаду по PositionId
            Position position = positionService.GetPositionById(emp.PositionId ?? 0);

            var replacements = new Dictionary<string, string>
            {
                { "{OrderNumber}", DateTime.Now.Ticks.ToString().Substring(10) },
                { "{OrderDate}", DateTime.Now.ToString("dd.MM.yyyy") },
                { "{FullName}", $"{emp.LastName} {emp.FirstName} {emp.MiddleName}" },
                { "{Position}", position?.Title ?? "" },
                { "{AppointDate}", DateTime.Now.ToString("dd.MM.yyyy") }
            };

            string safeName = $"{emp.LastName}_{emp.FirstName}_{emp.Id}";
            string fileName = $"Наказ_призначення_{safeName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            try
            {
                fileService.GenerateOrderFromWordTemplate("appoint_order_template.docx", replacements, fileName);

                string ordersDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Orders");
                string outputPath = Path.Combine(ordersDir, fileName);

                System.Diagnostics.Process.Start(outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка генерації наказу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
