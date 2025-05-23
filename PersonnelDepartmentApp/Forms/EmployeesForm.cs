using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PersonnelDepartmentApp.Models;
using PersonnelDepartmentApp.Services;
using static PersonnelDepartmentApp.Services.FileService;

namespace PersonnelDepartmentApp
{
    public partial class EmployeesForm : Form
    {
        private EmployeeService employeeService = new EmployeeService();
        private FileService fileService;
        private List<Employee> allEmployees;
        private List<Employee> displayedEmployees;

        public static EmployeesForm GetForm()
        {
            EmployeesForm ThisForm = new EmployeesForm();
            ThisForm.StartPosition = FormStartPosition.CenterScreen;

            return ThisForm;
        }



        public EmployeesForm()
        {
            InitializeComponent();
            groupBoxAddEmployee.Visible = false;
            employeeService = new EmployeeService();
            fileService = new FileService();
            txtSearch.KeyDown += TxtSearch_KeyDown;
            txtSalary.KeyPress += TxtSalary_KeyPress;
            dgvEmployees.ColumnHeaderMouseClick += dgvEmployees_ColumnHeaderMouseClick;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadEmployees()
        {
            allEmployees = employeeService.GetEmployees();
            displayedEmployees = new List<Employee>(allEmployees);

            dgvEmployees.DataSource = displayedEmployees.Select(e => new
            {
                ID = e.Id,
                Прізвище = e.LastName,
                Ім_я = e.FirstName,
                По_батькові = e.MiddleName,
                Дата_народження = e.BirthDate.ToString("dd.MM.yyyy"),
                Номер_паспорта = e.PassportNumber,
                Дата_прийняття = e.HireDate.ToString("dd.MM.yyyy"),
                Дата_звільнення = e.TerminationDate?.ToString("dd.MM.yyyy") ?? "Працює",
                Зарплата = e.Salary.ToString("F2")
            }).ToList();

            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //Сортування
        private string lastSortedColumn = null;
        private bool lastSortAsc = true;


        private void dgvEmployees_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvEmployees.Columns[e.ColumnIndex].DataPropertyName;
            if (lastSortedColumn == columnName)
                lastSortAsc = !lastSortAsc;
            else
                lastSortAsc = true;
            lastSortedColumn = columnName;

            Func<Employee, object> keySelector;
            switch (columnName)
            {
                case "ID":
                    keySelector = emp => emp.Id;
                    break;
                case "Прізвище":
                    keySelector = emp => emp.LastName;
                    break;
                case "Ім_я":
                    keySelector = emp => emp.FirstName;
                    break;
                case "По_батькові":
                    keySelector = emp => emp.MiddleName;
                    break;
                case "Дата_народження":
                    keySelector = emp => emp.BirthDate;
                    break;
                case "Номер_паспорта":
                    keySelector = emp => emp.PassportNumber;
                    break;
                case "Дата_прийняття":
                    keySelector = emp => emp.HireDate;
                    break;
                case "Дата_звільнення":
                    keySelector = emp => emp.TerminationDate ?? DateTime.MaxValue;
                    break;
                case "Зарплата":
                    keySelector = emp => emp.Salary;
                    break;
                default:
                    keySelector = emp => emp.Id;
                    break;
            }

            if (lastSortAsc)
                displayedEmployees = displayedEmployees.OrderBy(keySelector).ToList();
            else
                displayedEmployees = displayedEmployees.OrderByDescending(keySelector).ToList();

            dgvEmployees.DataSource = displayedEmployees.Select(emp => new
            {
                ID = emp.Id,
                Прізвище = emp.LastName,
                Ім_я = emp.FirstName,
                По_батькові = emp.MiddleName,
                Дата_народження = emp.BirthDate.ToString("dd.MM.yyyy"),
                Номер_паспорта = emp.PassportNumber,
                Дата_прийняття = emp.HireDate.ToString("dd.MM.yyyy"),
                Дата_звільнення = emp.TerminationDate?.ToString("dd.MM.yyyy") ?? "Працює",
                Зарплата = emp.Salary.ToString("F2")
            }).ToList();
        }

        private void btnResetSort_Click(object sender, EventArgs e)
        {
            displayedEmployees = new List<Employee>(allEmployees);
            dgvEmployees.DataSource = displayedEmployees.Select(emp => new
            {
                ID = emp.Id,
                Прізвище = emp.LastName,
                Ім_я = emp.FirstName,
                По_батькові = emp.MiddleName,
                Дата_народження = emp.BirthDate.ToString("dd.MM.yyyy"),
                Номер_паспорта = emp.PassportNumber,
                Дата_прийняття = emp.HireDate.ToString("dd.MM.yyyy"),
                Дата_звільнення = emp.TerminationDate?.ToString("dd.MM.yyyy") ?? "Працює",
                Зарплата = emp.Salary.ToString("F2")
            }).ToList();
            lastSortedColumn = null;
        }


        // Відкриття панелі додавання співробітника
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // Показуємо панель
            groupBoxAddEmployee.Visible = true;
            btnAddEmployee.Enabled = false;
            ClearEmployeeForm();
        }

        // Скасування додавання співробітника
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            groupBoxAddEmployee.Visible = false;
            btnAddEmployee.Enabled = true;
            ClearEmployeeForm();
        }

        // Очищення полів форми
        private void ClearEmployeeForm()
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtPassportNumber.Text = "";
            txtSalary.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            dtpHireDate.Value = DateTime.Now;
            dtpTerminationDate.Value = DateTime.Now;
            dtpTerminationDate.Checked = false; // Зробити поле дати звільнення необов'язковим
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                employeeService.SaveEmployees();
                MessageBox.Show("Дані успішно збережені!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // Відкриття панелі редагування працівника
        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            //if (dgvEmployees.SelectedRows.Count == 0)
            if (dgvEmployees.RowCount <= 0)
            {
                //MessageBox.Show("Виберіть працівника для редагування.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Список співробітників порожній, натисніть кнопку <<Оновити список>>.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть працівника для редагування.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                // Отримуємо ID вибраного працівника
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["ID"].Value);
            Employee employee = employeeService.GetEmployeeById(employeeId);

            if (employee == null)
            {
                MessageBox.Show("Працівник не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Заповнюємо поля даними працівника
            txtLastName.Text = employee.LastName;
            txtFirstName.Text = employee.FirstName;
            txtMiddleName.Text = employee.MiddleName;
            txtPassportNumber.Text = employee.PassportNumber;
            dtpBirthDate.Value = employee.BirthDate;
            dtpHireDate.Value = employee.HireDate;
            txtSalary.Text = employee.Salary.ToString();
            if (employee.TerminationDate.HasValue)
            {
                dtpTerminationDate.Value = employee.TerminationDate.Value;
                dtpTerminationDate.Checked = true;
            }
            else
            {
                dtpTerminationDate.Checked = false;
            }

            // Міняємо заголовок панелі та показуємо її
            groupBoxAddEmployee.Text = "Редагування працівника";
            groupBoxAddEmployee.Visible = true;
            btnAddEmployee.Enabled = false;

            // Зберігаємо ID працівника для редагування
            btnSaveEmployee.Tag = employeeId;
        }

        // Видалення працівника
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть працівника для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Отримуємо ID вибраного працівника
            int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["ID"].Value);

            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цього працівника?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                employeeService.DeleteEmployee(employeeId);
                LoadEmployees();
                MessageBox.Show("Працівника успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvEmployees.Focus();
        }

        // Оновлення працівника
        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                int? employeeId = btnSaveEmployee.Tag as int?;
                if (employeeId.HasValue)
                {
                    // Оновлення існуючого працівника
                    Employee updatedEmployee = new Employee
                    {
                        Id = employeeId.Value,
                        LastName = txtLastName.Text,
                        FirstName = txtFirstName.Text,
                        MiddleName = txtMiddleName.Text,
                        BirthDate = dtpBirthDate.Value,
                        PassportNumber = txtPassportNumber.Text,
                        HireDate = dtpHireDate.Value,
                        TerminationDate = dtpTerminationDate.Checked ? dtpTerminationDate.Value : (DateTime?)null,
                        Salary = decimal.Parse(txtSalary.Text)
                    };

                    employeeService.EditEmployee(employeeId.Value, updatedEmployee);
                    btnSaveEmployee.Tag = null;
                    MessageBox.Show("Працівника успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Додавання нового працівника
                    Employee newEmployee = new Employee
                    {
                        Id = employeeService.GetNextEmployeeId(),
                        LastName = txtLastName.Text,
                        FirstName = txtFirstName.Text,
                        MiddleName = txtMiddleName.Text,
                        BirthDate = dtpBirthDate.Value,
                        PassportNumber = txtPassportNumber.Text,
                        HireDate = dtpHireDate.Value,
                        TerminationDate = dtpTerminationDate.Checked ? dtpTerminationDate.Value : (DateTime?)null,
                        Salary = decimal.Parse(txtSalary.Text)
                    };

                    employeeService.AddEmployee(newEmployee);
                    MessageBox.Show("Працівника успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Оновлюємо таблицю
                LoadEmployees();

                // Закриваємо панель додавання/редагування
                groupBoxAddEmployee.Visible = false;
                btnAddEmployee.Enabled = true;
                ClearEmployeeForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження працівника: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обробник кнопки пошуку
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            var filteredEmployees = employeeService.GetEmployees()
                .Where(emp =>
                    emp.FirstName.ToLower().Contains(searchText) ||
                    emp.LastName.ToLower().Contains(searchText) ||
                    emp.MiddleName.ToLower().Contains(searchText) ||
                    emp.PassportNumber.ToLower().Contains(searchText) ||
                    emp.Id.ToString().Contains(searchText))
                .Select(emp => new
                {
                    ID = emp.Id,
                    Прізвище = emp.LastName,
                    Ім_я = emp.FirstName,
                    По_батькові = emp.MiddleName,
                    Дата_народження = emp.BirthDate.ToString("dd.MM.yyyy"),
                    Номер_паспорта = emp.PassportNumber,
                    Дата_прийняття = emp.HireDate.ToString("dd.MM.yyyy"),
                    Дата_звільнення = emp.TerminationDate?.ToString("dd.MM.yyyy") ?? "Працює",
                    Зарплата = emp.Salary
                }).ToList();

            dgvEmployees.DataSource = filteredEmployees;
        }

        // Автоматичне скидання фільтра при очищенні поля пошуку
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadEmployees();
            }
        }
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void TxtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Дозволяємо тільки цифри, одну кому або крапку, і Backspace
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != '\b' && ch != ',' && ch != '.')
            {
                e.Handled = true;
            }

            // Забороняємо більше однієї крапки/коми
            if ((ch == ',' || ch == '.') && ((TextBox)sender).Text.Contains(",") || ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }

            // Забороняємо мінус у будь-якій формі
            if (ch == '-')
            {
                e.Handled = true;
            }
        }

        private void btnGenerateOrder_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть співробітника для формування наказу.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["ID"].Value);
            Employee emp = employeeService.GetEmployeeById(employeeId);

            string position = ""; // Получить из PositionService
            string department = ""; // Получить из DepartmentService

            var replacements = new Dictionary<string, string>
            {
                { "{OrderNumber}", DateTime.Now.Ticks.ToString().Substring(10) },
                { "{OrderDate}", DateTime.Now.ToString("dd.MM.yyyy") },
                { "{FullName}", $"{emp.LastName} {emp.FirstName} {emp.MiddleName}" },
                { "{BirthDate}", emp.BirthDate.ToString("dd.MM.yyyy") },
                { "{PassportNumber}", emp.PassportNumber },
                { "{Position}", position },
                { "{Department}", department },
                { "{HireDate}", emp.HireDate.ToString("dd.MM.yyyy") },
                { "{Salary}", emp.Salary.ToString("F2") }
            };

            string safeName = $"{emp.LastName}_{emp.FirstName}_{emp.Id}";
            string fileName = $"Наказ_прийом_{safeName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            try
            {
                fileService.GenerateOrderFromWordTemplate("hire_order_template.docx", replacements, fileName);

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
