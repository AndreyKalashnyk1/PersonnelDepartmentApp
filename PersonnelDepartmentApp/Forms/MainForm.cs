using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelDepartmentApp.Forms
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void співробітникиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmEmployees_Click(object sender, EventArgs e)
        {
            EmployeesForm.GetForm().ShowDialog();
        }

        private void формуванняНаказівToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void довідкаКористувачуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsn_Departments_Click(object sender, EventArgs e)
        {
            DepartmentsForm.GetForm().ShowDialog();
        }

        private void tsmPositions_Click(object sender, EventArgs e)
        {
            PositionsForm.GetForm().ShowDialog();
        }
    }
}
