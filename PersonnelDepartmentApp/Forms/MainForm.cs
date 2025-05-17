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

        public MainForm()
        {
            InitializeComponent();
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




        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadEmployees();
        }
    }
}
