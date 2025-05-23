using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PersonnelDepartmentApp.Models;
using PersonnelDepartmentApp.Services;

namespace PersonnelDepartmentApp
{
    public partial class DepartmentsForm : Form
    {
        private DepartmentService departmentService = new DepartmentService();
        private EmployeeService employeeService = new EmployeeService();
        private int? editingDepartmentId = null;
        private FileService fileService;

        private List<Department> departments;
        private List<Employee> employees;
        private List<Department> allDepartments;
        private List<Department> displayedDepartments;
        private string lastSortedEmpColumn = null;
        private bool lastEmpSortAsc = true;
        private List<Employee> displayedEmployeesWithDepartments;


        public DepartmentsForm()
        {
            InitializeComponent();
            fileService = new FileService();
            groupBoxDepartmentEdit.Visible = false;
            txtSearchDepartments.KeyDown += txtSearchDepartments_KeyDown;
            txtSearchEmployees.KeyDown += txtSearchEmployees_KeyDown;
            txtSearchDepartments.TextChanged += txtSearchDepartments_TextChanged;
            txtSearchEmployees.TextChanged += txtSearchEmployees_TextChanged;
            dgvDepartments.ColumnHeaderMouseClick += dgvDepartments_ColumnHeaderMouseClick;
            dgvEmployeesWithDepartments.ColumnHeaderMouseClick += dgvEmployeesWithDepartments_ColumnHeaderMouseClick;
        }
      
        public static DepartmentsForm GetForm()
        {
            DepartmentsForm ThisForm = new DepartmentsForm();
            ThisForm.StartPosition = FormStartPosition.CenterScreen;

            return ThisForm;
        }
        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            employees = employeeService.GetEmployees();

            dgvEmployeesWithDepartments.DataSource = employees
                .Select(emp => new
                {
                    emp.Id,
                    ФІО = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Department = departments != null
                        ? departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                        : "—"
                })
                .ToList();

            dgvEmployeesWithDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            groupBoxDepartmentEdit.Visible = false;
        }

        //сортування для таблички з підрозділами
        private string lastSortedDeptColumn = null;
        private bool lastDeptSortAsc = true;

        private void dgvDepartments_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Если коллекция не инициализирована — инициализируем из departments
            if (displayedDepartments == null)
            {
                displayedDepartments = departments != null
                    ? new List<Department>(departments)
                    : new List<Department>();
            }

            string columnName = dgvDepartments.Columns[e.ColumnIndex].DataPropertyName;
            if (lastSortedDeptColumn == columnName)
                lastDeptSortAsc = !lastDeptSortAsc;
            else
                lastDeptSortAsc = true;
            lastSortedDeptColumn = columnName;

            Func<Department, object> keySelector;
            switch (columnName)
            {
                case "Id":
                    keySelector = d => d.Id;
                    break;
                case "Name":
                    keySelector = d => d.Name;
                    break;
                default:
                    keySelector = d => d.Id;
                    break;
            }

            if (lastDeptSortAsc)
                displayedDepartments = displayedDepartments.OrderBy(keySelector).ToList();
            else
                displayedDepartments = displayedDepartments.OrderByDescending(keySelector).ToList();

            dgvDepartments.DataSource = displayedDepartments
                .Select(d => new { d.Id, d.Name })
                .ToList();
        }


        //сортування для таблиці зі співробітниками та підрозділами
        private void dgvEmployeesWithDepartments_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvEmployeesWithDepartments.Columns[e.ColumnIndex].DataPropertyName;
            if (lastSortedEmpColumn == columnName)
                lastEmpSortAsc = !lastEmpSortAsc;
            else
                lastEmpSortAsc = true;
            lastSortedEmpColumn = columnName;

            // Для сортировки используем employees, а не DataSource
            Func<Employee, object> keySelector;
            switch (columnName)
            {
                case "Id":
                    keySelector = emp => emp.Id;
                    break;
                case "FullName":
                case "ФІО":
                    keySelector = emp => $"{emp.LastName} {emp.FirstName} {emp.MiddleName}";
                    break;
                case "Department":
                    keySelector = emp => departments != null
                        ? departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? ""
                        : "";
                    break;
                default:
                    keySelector = emp => emp.Id;
                    break;
            }

            if (lastEmpSortAsc)
                displayedEmployeesWithDepartments = employees.OrderBy(keySelector).ToList();
            else
                displayedEmployeesWithDepartments = employees.OrderByDescending(keySelector).ToList();

            dgvEmployeesWithDepartments.DataSource = displayedEmployeesWithDepartments
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Department = departments != null
                        ? departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                        : "—"
                })
                .ToList();
        }

        private void btnAssignDepartment_Click(object sender, EventArgs e)
        {
            if (departments == null || departments.Count == 0)
            {
                MessageBox.Show("Будь ласка, спочатку оновіть список підрозділів.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("Список працівників порожній.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvEmployeesWithDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть працівника для призначення підрозділу.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть підрозділ для призначення.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployeesWithDepartments.SelectedRows[0].Cells[0].Value);
            int departmentId = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells[0].Value);

            var selectedEmployee = employees.FirstOrDefault(emp => emp.Id == employeeId);
            if (selectedEmployee == null)
            {
                MessageBox.Show("Працівник не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedEmployee.DepartmentId = departmentId;
            employeeService.SaveEmployees();

            // Обновляем сотрудников и подразделения
            employees = employeeService.GetEmployees();
            if (departments == null || departments.Count == 0)
            {
                departmentService.ReloadDepartments();
                departments = departmentService.GetDepartments();
            }

            dgvEmployeesWithDepartments.DataSource = employees
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Department = departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                })
                .ToList();

            MessageBox.Show("Підрозділ призначено працівнику.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            if (!IsDepartmentsLoaded())
            {
                MessageBox.Show("Будь ласка, спочатку оновіть список підрозділів.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            editingDepartmentId = null;
            txtDepartmentName.Text = "";
            groupBoxDepartmentEdit.Text = "Додати підрозділ";
            groupBoxDepartmentEdit.Visible = true;
        }



        private void btnReloadDepartments_Click(object sender, EventArgs e)
        {
            departmentService.ReloadDepartments();
            departments = departmentService.GetDepartments();
            dgvDepartments.DataSource = departments
                .Select(d => new { d.Id, d.Name })
                .ToList();

            // Обновляем сотрудников с актуальными подразделениями
            employees = employeeService.GetEmployees();
            dgvEmployeesWithDepartments.DataSource = employees
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Department = departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                })
                .ToList();
        }


        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            if (!IsDepartmentsLoaded())
            {
                MessageBox.Show("Будь ласка, спочатку оновіть список підрозділів.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть підрозділ для редагування.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int departmentId = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells[0].Value);
            var department = departments.FirstOrDefault(d => d.Id == departmentId);
            if (department == null)
            {
                MessageBox.Show("Підрозділ не знайдено. Оновіть список.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            editingDepartmentId = department.Id;
            txtDepartmentName.Text = department.Name;
            groupBoxDepartmentEdit.Text = "Редагувати підрозділ";
            groupBoxDepartmentEdit.Visible = true;
        }



        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (!IsDepartmentsLoaded())
            {
                MessageBox.Show("Будь ласка, спочатку оновіть список підрозділів.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть підрозділ для видалення.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int departmentId = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells[0].Value);

            var confirm = MessageBox.Show(
                "Ви дійсно бажаєте видалити підрозділ?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                departmentService.DeleteDepartment(departmentId);
                DepartmentsForm_Load(null, null);
                MessageBox.Show("Підрозділ успішно видалено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            departmentService.ReloadDepartments();
            departments = departmentService.GetDepartments();
            dgvDepartments.DataSource = departments
                .Select(d => new { d.Id, d.Name })
                .ToList();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private bool IsDepartmentsLoaded()
        {
            return departments != null && departments.Count > 0;
        }

        private void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            var name = txtDepartmentName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введіть назву підрозділу.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (editingDepartmentId == null)
            {
                var newDepartment = new Department { Name = name };
                departmentService.AddDepartment(newDepartment);
                MessageBox.Show("Підрозділ додано.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var updatedDepartment = new Department
                {
                    Id = editingDepartmentId.Value,
                    Name = name
                };
                departmentService.EditDepartment(editingDepartmentId.Value, updatedDepartment);
                MessageBox.Show("Підрозділ відредаговано.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // После любого изменения — обновляем список подразделений
            departmentService.ReloadDepartments();
            departments = departmentService.GetDepartments();
            dgvDepartments.DataSource = departments
                .Select(d => new { d.Id, d.Name })
                .ToList();

            // И обновляем сотрудников с актуальными подразделениями
            dgvEmployeesWithDepartments.DataSource = employees
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Department = departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                })
                .ToList();

            groupBoxDepartmentEdit.Visible = false;
        }




        private void btnCancelDepartmentEdit_Click(object sender, EventArgs e)
        {
            groupBoxDepartmentEdit.Visible = false;
        }

        private void btnSearchDepartments_Click(object sender, EventArgs e)
        {
            if (!IsDepartmentsLoaded())
            {
                MessageBox.Show("Будь ласка, спочатку оновіть список підрозділів.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string search = txtSearchDepartments.Text.Trim().ToLower();
            var filtered = departments
                .Where(d => d.Name != null && d.Name.ToLower().Contains(search))
                .Select(d => new { d.Id, d.Name })
                .ToList();
            dgvDepartments.DataSource = filtered;
        }

        private void btnSearchEmployees_Click(object sender, EventArgs e)
        {
            string search = txtSearchEmployees.Text.Trim().ToLower();
            var filtered = employees
                .Where(emp =>
                    $"{emp.LastName} {emp.FirstName} {emp.MiddleName}".ToLower().Contains(search))
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Department = departments != null
                        ? departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                        : "—"
                })
                .ToList();
            dgvEmployeesWithDepartments.DataSource = filtered;
        }
        private void txtSearchDepartments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchDepartments_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
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
        private void txtSearchDepartments_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchDepartments.Text))
            {
                // Показываем весь список подразделений
                if (IsDepartmentsLoaded())
                {
                    dgvDepartments.DataSource = departments
                        .Select(d => new { d.Id, d.Name })
                        .ToList();
                }
            }
        }

        private void txtSearchEmployees_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchEmployees.Text))
            {
                dgvEmployeesWithDepartments.DataSource = employees
                    .Select(emp => new
                    {
                        emp.Id,
                        FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                        Department = departments != null
                            ? departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                            : "—"
                    })
                    .ToList();
            }
        }

        private void btnResetDeptSort_Click(object sender, EventArgs e)
        {
            displayedDepartments = new List<Department>(allDepartments);
            dgvDepartments.DataSource = displayedDepartments
                .Select(d => new { d.Id, d.Name })
                .ToList();
            lastSortedDeptColumn = null;
        }

        private void btnResetEmpSort_Click(object sender, EventArgs e)
        {
            dgvEmployeesWithDepartments.DataSource = employees
                .Select(emp => new
                {
                    emp.Id,
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Department = departments != null
                        ? departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                        : "—"
                })
                .ToList();
            lastSortedEmpColumn = null;
        }

        private void btnRemoveDepartmentFromEmployee_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("Список працівників порожній.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvEmployeesWithDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть працівника для видалення підрозділу.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployeesWithDepartments.SelectedRows[0].Cells[0].Value);
            var selectedEmployee = employees.FirstOrDefault(emp => emp.Id == employeeId);
            if (selectedEmployee == null)
            {
                MessageBox.Show("Працівник не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedEmployee.DepartmentId == null)
            {
                MessageBox.Show("У цього працівника вже не вказано підрозділ.", "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Ви дійсно бажаєте видалити підрозділ у цього працівника?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                selectedEmployee.DepartmentId = null;
                employeeService.SaveEmployees();

                // Обновляем отображение
                dgvEmployeesWithDepartments.DataSource = employees
                    .Select(emp => new
                    {
                        emp.Id,
                        FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                        Department = departments != null
                            ? departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                            : "—"
                    })
                    .ToList();

                MessageBox.Show("Підрозділ у працівника видалено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmployeesWithDepartments.Focus();
            }
        }

        private void txtSearchDepartments_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void btnGenerateTransferOrder_Click(object sender, EventArgs e)
        {
            if (dgvEmployeesWithDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть співробітника для формування наказу.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployeesWithDepartments.SelectedRows[0].Cells["ID"].Value);
            Employee emp = employeeService.GetEmployeeById(employeeId);

            // Получаем подразделение по DepartmentId
            Department department = departmentService.GetDepartmentById(emp.DepartmentId ?? 0);

            var replacements = new Dictionary<string, string>
    {
        { "{OrderNumber}", DateTime.Now.Ticks.ToString().Substring(10) },
        { "{OrderDate}", DateTime.Now.ToString("dd.MM.yyyy") },
        { "{FullName}", $"{emp.LastName} {emp.FirstName} {emp.MiddleName}" },
        { "{Department}", department?.Name ?? "" },
        { "{TransferDate}", DateTime.Now.ToString("dd.MM.yyyy") }
    };

            string safeName = $"{emp.LastName}_{emp.FirstName}_{emp.Id}";
            string fileName = $"Наказ_переведення_{safeName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            try
            {
                fileService.GenerateOrderFromWordTemplate("transfer_order_template.docx", replacements, fileName);

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
