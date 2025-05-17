using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PersonnelDepartmentApp.Models;

namespace PersonnelDepartmentApp
{
    public partial class MainForm : Form
    {
        private List<Employee> employees = new List<Employee>();

        public MainForm()
        {
            InitializeComponent();
            LoadEmployees();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            // Тимчасові дані для тестування
            employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Іван", LastName = "Петренко", MiddleName = "Олексійович", BirthDate = new DateTime(1985, 3, 15), PassportNumber = "AA123456", Salary = 15000, HireDate = new DateTime(2010, 5, 1), LastPromotionDate = new DateTime(2020, 8, 15) },
                new Employee { Id = 2, FirstName = "Марія", LastName = "Іваненко", MiddleName = "Петрівна", BirthDate = new DateTime(1990, 7, 20), PassportNumber = "AB654321", Salary = 12000, HireDate = new DateTime(2015, 4, 10), LastPromotionDate = new DateTime(2023, 2, 1) },
                new Employee { Id = 3, FirstName = "Петро", LastName = "Коваленко", MiddleName = "Васильович", BirthDate = new DateTime(1978, 12, 5), PassportNumber = "AC987654", Salary = 20000, HireDate = new DateTime(2008, 9, 15), LastPromotionDate = new DateTime(2019, 11, 20) }
            };

            dgvEmployees.DataSource = employees.Select(e => new
            {
                e.Id,
                FullName = $"{e.LastName} {e.FirstName} {e.MiddleName}",
                e.PassportNumber,
                e.Salary,
                e.HireDate,
                e.LastPromotionDate
            }).ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }
    }
}
