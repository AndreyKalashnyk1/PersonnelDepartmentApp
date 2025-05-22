using System;
using System.Collections.Generic;
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

        private List<Department> departments;
        private List<Employee> employees;

        public DepartmentsForm()
        {
            InitializeComponent();
            groupBoxDepartmentEdit.Visible = false;
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
                    FullName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                    Department = departments != null
                        ? departments.FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name ?? "—"
                        : "—"
                })
                .ToList();

            dgvEmployeesWithDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            groupBoxDepartmentEdit.Visible = false;
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

    }
}
