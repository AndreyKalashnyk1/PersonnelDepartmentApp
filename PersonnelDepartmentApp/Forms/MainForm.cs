using System;
using System.Linq;
using System.Windows.Forms;
using PersonnelDepartmentApp.Models;
using PersonnelDepartmentApp.Services;

namespace PersonnelDepartmentApp
{
    public partial class MainForm : Form
    {
        private EmployeeService employeeService = new EmployeeService();
        private FileService fileService;

        public MainForm()
        {
            InitializeComponent();
            groupBoxAddEmployee.Visible = false;
            fileService = new FileService();
            // Прив'язка обробника події до кнопки збереження працівника
            btnSaveEmployee.Click += btnSaveEmployee_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadEmployees()
        {
            var employees = employeeService.GetEmployees();

            dgvEmployees.DataSource = employees.Select(e => new
            {
                ID = e.Id,
                Прізвище = e.LastName,
                Ім_я = e.FirstName,
                По_батькові = e.MiddleName,
                Дата_народження = e.BirthDate.ToString("dd.MM.yyyy"),
                Номер_паспорта = e.PassportNumber,
                Дата_прийняття = e.HireDate.ToString("dd.MM.yyyy"),
                Дата_звільнення = e.TerminationDate?.ToString("dd.MM.yyyy") ?? "Працює",
                Зарплата = e.Salary
            }).ToList();

            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        // Збереження нового працівника
        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                // Створюємо нового працівника
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

                // Додаємо працівника до списку і зберігаємо в файл
                employeeService.AddEmployee(newEmployee);
                fileService.AppendEmployee(newEmployee);

                // Оновлюємо таблицю
                LoadEmployees();

                // Закриваємо панель додавання
                groupBoxAddEmployee.Visible = false;
                btnAddEmployee.Enabled = true;
                ClearEmployeeForm();

                MessageBox.Show("Працівника успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання працівника: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadEmployees();
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
    }
}
