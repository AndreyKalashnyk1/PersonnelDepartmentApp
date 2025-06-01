using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonnelDepartmentApp.Models;
using PersonnelDepartmentApp.Services;


namespace PersonnelDepartmentApp.Forms
{
    public partial class EducationsForm: Form
    {
        private EducationRepository educationRepository = new EducationRepository();
        private List<Education> allEducations;
        private List<Employee> employees;
        private Employee selectedEmployee;
        private Education editingEducation;

        public EducationsForm()
        {
            InitializeComponent();
            groupBoxAddEducation.Visible = false;

        }

        public static EducationsForm GetForm()
        {
            EducationsForm ThisForm = new EducationsForm();
            ThisForm.StartPosition = FormStartPosition.CenterScreen;

            return ThisForm;
        }

        private void EducationsForm_Load(object sender, EventArgs e)
        {
            employees = new EmployeeService().GetEmployees();

            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("Список співробітників порожній. Додайте співробітників у відповідній формі.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmployee.DataSource = null;
                return;
            }

            cmbEmployee.DataSource = employees;
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "Id";

            allEducations = educationRepository.LoadEducations() ?? new List<Education>();

            cmbEmployee.SelectedIndex = 0;
            cmbEmployee.SelectedIndexChanged += cmbEmployee_SelectedIndexChanged;
            RefreshEducationList();
        }


        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEmployee = cmbEmployee.SelectedItem as Employee;
            RefreshEducationList();
            ClearEducationForm();
        }

        private void RefreshEducationList()
        {
            if (selectedEmployee == null) return;
            if (allEducations == null) allEducations = new List<Education>();
            var educations = allEducations.Where(e => e.EmployeeId == selectedEmployee.Id).ToList();
            dgvEducations.DataSource = educations
                .Select(e => new
                {
                    e.Id,
                    e.Degree,
                    e.Major,
                    e.Institution,
                    GraduationYear = e.GraduationYear.Year
                }).ToList();
            SetEducationsGridHeaders();
        }


        private void btnAddEducation_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Оберіть співробітника.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            groupBoxAddEducation.Text = "Додати освіту";
            groupBoxAddEducation.Visible = true;
            btnAddEducation.Enabled = false;
            ClearEducationForm();
        }



        private void btnEditEducation_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Оберіть співробітника.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvEducations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть запис для редагування.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvEducations.SelectedRows[0].Cells["Id"].Value);
            editingEducation = allEducations.FirstOrDefault(ed => ed.Id == id);
            if (editingEducation == null) return;

            txtDegree.Text = editingEducation.Degree;
            txtMajor.Text = editingEducation.Major;
            txtInstitution.Text = editingEducation.Institution;
            numGraduationYear.Value = editingEducation.GraduationYear.Year;

            groupBoxAddEducation.Text = "Редагувати освіту";
            groupBoxAddEducation.Visible = true;
            btnAddEducation.Enabled = false;
        }



        private void btnDeleteEducation_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Оберіть співробітника.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvEducations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть запис для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvEducations.SelectedRows[0].Cells["Id"].Value);
            var edu = allEducations.FirstOrDefault(ed => ed.Id == id);
            if (edu == null) return;
            allEducations.Remove(edu);
            educationRepository.SaveEducations(allEducations);
            RefreshEducationList();
            ClearEducationForm();
            groupBoxAddEducation.Visible = false;
            btnAddEducation.Enabled = true;
            editingEducation = null;
        }



        private void btnSaveEducation_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Оберіть співробітника.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (editingEducation == null)
            {
                // Добавление
                var newEdu = new Education
                {
                    Id = allEducations.Count > 0 ? allEducations.Max(ed => ed.Id) + 1 : 1,
                    EmployeeId = selectedEmployee.Id,
                    Degree = txtDegree.Text.Trim(),
                    Major = txtMajor.Text.Trim(),
                    Institution = txtInstitution.Text.Trim(),
                    GraduationYear = new DateTime((int)numGraduationYear.Value, 1, 1)
                };
                allEducations.Add(newEdu);
            }
            else
            {
                // Редактирование
                editingEducation.Degree = txtDegree.Text.Trim();
                editingEducation.Major = txtMajor.Text.Trim();
                editingEducation.Institution = txtInstitution.Text.Trim();
                editingEducation.GraduationYear = new DateTime((int)numGraduationYear.Value, 1, 1);
            }

            educationRepository.SaveEducations(allEducations);
            RefreshEducationList();
            ClearEducationForm();
            groupBoxAddEducation.Visible = false;
            btnAddEducation.Enabled = true;
            editingEducation = null;
        }

        private void ClearEducationForm()
        {
            txtDegree.Text = "";
            txtMajor.Text = "";
            txtInstitution.Text = "";
            int currentYear = DateTime.Now.Year;
            if (numGraduationYear.Maximum < currentYear)
                numGraduationYear.Maximum = currentYear;
            if (numGraduationYear.Minimum > currentYear)
                numGraduationYear.Minimum = 1950;
            numGraduationYear.Value = currentYear;
            editingEducation = null;
        }


        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            groupBoxAddEducation.Visible = false;
            btnAddEducation.Enabled = true;
            ClearEducationForm();
            editingEducation = null;
        }
        private void SetEducationsGridHeaders()
        {
            if (dgvEducations.Columns["Id"] != null)
                dgvEducations.Columns["Id"].HeaderText = "ID";
            if (dgvEducations.Columns["Degree"] != null)
                dgvEducations.Columns["Degree"].HeaderText = "Ступінь";
            if (dgvEducations.Columns["Major"] != null)
                dgvEducations.Columns["Major"].HeaderText = "Спеціальність";
            if (dgvEducations.Columns["Institution"] != null)
                dgvEducations.Columns["Institution"].HeaderText = "Заклад";
            if (dgvEducations.Columns["GraduationYear"] != null)
                dgvEducations.Columns["GraduationYear"].HeaderText = "Рік закінчення";
        }

    }
}
