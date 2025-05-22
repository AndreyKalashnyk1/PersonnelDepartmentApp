namespace PersonnelDepartmentApp
{
    partial class DepartmentsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvEmployeesWithDepartments = new System.Windows.Forms.DataGridView();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.btnAssignDepartment = new System.Windows.Forms.Button();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.btnReloadDepartments = new System.Windows.Forms.Button();
            this.btnEditDepartment = new System.Windows.Forms.Button();
            this.btnDeleteDepartment = new System.Windows.Forms.Button();
            this.groupBoxDepartmentEdit = new System.Windows.Forms.GroupBox();
            this.btnSaveDepartment = new System.Windows.Forms.Button();
            this.btnCancelDepartmentEdit = new System.Windows.Forms.Button();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchDepartments = new System.Windows.Forms.Button();
            this.txtSearchDepartments = new System.Windows.Forms.TextBox();
            this.btnSearchEmployees = new System.Windows.Forms.Button();
            this.txtSearchEmployees = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeesWithDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.groupBoxDepartmentEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployeesWithDepartments
            // 
            this.dgvEmployeesWithDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeesWithDepartments.Location = new System.Drawing.Point(15, 84);
            this.dgvEmployeesWithDepartments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvEmployeesWithDepartments.Name = "dgvEmployeesWithDepartments";
            this.dgvEmployeesWithDepartments.RowHeadersWidth = 62;
            this.dgvEmployeesWithDepartments.RowTemplate.Height = 28;
            this.dgvEmployeesWithDepartments.Size = new System.Drawing.Size(768, 570);
            this.dgvEmployeesWithDepartments.TabIndex = 0;
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Location = new System.Drawing.Point(809, 84);
            this.dgvDepartments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.RowHeadersWidth = 62;
            this.dgvDepartments.RowTemplate.Height = 28;
            this.dgvDepartments.Size = new System.Drawing.Size(737, 570);
            this.dgvDepartments.TabIndex = 1;
            // 
            // btnAssignDepartment
            // 
            this.btnAssignDepartment.Location = new System.Drawing.Point(12, 678);
            this.btnAssignDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAssignDepartment.Name = "btnAssignDepartment";
            this.btnAssignDepartment.Size = new System.Drawing.Size(194, 87);
            this.btnAssignDepartment.TabIndex = 2;
            this.btnAssignDepartment.Text = "Пере/Призначити підрозділ";
            this.btnAssignDepartment.UseVisualStyleBackColor = true;
            this.btnAssignDepartment.Click += new System.EventHandler(this.btnAssignDepartment_Click);
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.Location = new System.Drawing.Point(804, 678);
            this.btnAddDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(149, 88);
            this.btnAddDepartment.TabIndex = 4;
            this.btnAddDepartment.Text = "Додати підрозділ";
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
            // 
            // btnReloadDepartments
            // 
            this.btnReloadDepartments.Location = new System.Drawing.Point(1392, 678);
            this.btnReloadDepartments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReloadDepartments.Name = "btnReloadDepartments";
            this.btnReloadDepartments.Size = new System.Drawing.Size(152, 87);
            this.btnReloadDepartments.TabIndex = 5;
            this.btnReloadDepartments.Text = "Оновити підрозділи";
            this.btnReloadDepartments.UseVisualStyleBackColor = true;
            this.btnReloadDepartments.Click += new System.EventHandler(this.btnReloadDepartments_Click);
            // 
            // btnEditDepartment
            // 
            this.btnEditDepartment.Location = new System.Drawing.Point(960, 678);
            this.btnEditDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditDepartment.Name = "btnEditDepartment";
            this.btnEditDepartment.Size = new System.Drawing.Size(149, 88);
            this.btnEditDepartment.TabIndex = 6;
            this.btnEditDepartment.Text = "Редагувати підрозділ";
            this.btnEditDepartment.UseVisualStyleBackColor = true;
            this.btnEditDepartment.Click += new System.EventHandler(this.btnEditDepartment_Click);
            // 
            // btnDeleteDepartment
            // 
            this.btnDeleteDepartment.Location = new System.Drawing.Point(1117, 678);
            this.btnDeleteDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteDepartment.Name = "btnDeleteDepartment";
            this.btnDeleteDepartment.Size = new System.Drawing.Size(149, 88);
            this.btnDeleteDepartment.TabIndex = 7;
            this.btnDeleteDepartment.Text = "Видалити підрозділ";
            this.btnDeleteDepartment.UseVisualStyleBackColor = true;
            this.btnDeleteDepartment.Click += new System.EventHandler(this.btnDeleteDepartment_Click);
            // 
            // groupBoxDepartmentEdit
            // 
            this.groupBoxDepartmentEdit.Controls.Add(this.label1);
            this.groupBoxDepartmentEdit.Controls.Add(this.txtDepartmentName);
            this.groupBoxDepartmentEdit.Controls.Add(this.btnCancelDepartmentEdit);
            this.groupBoxDepartmentEdit.Controls.Add(this.btnSaveDepartment);
            this.groupBoxDepartmentEdit.Location = new System.Drawing.Point(1208, 84);
            this.groupBoxDepartmentEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDepartmentEdit.Name = "groupBoxDepartmentEdit";
            this.groupBoxDepartmentEdit.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDepartmentEdit.Size = new System.Drawing.Size(353, 261);
            this.groupBoxDepartmentEdit.TabIndex = 8;
            this.groupBoxDepartmentEdit.TabStop = false;
            this.groupBoxDepartmentEdit.Text = "Дані підрозділу";
            // 
            // btnSaveDepartment
            // 
            this.btnSaveDepartment.Location = new System.Drawing.Point(19, 189);
            this.btnSaveDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveDepartment.Name = "btnSaveDepartment";
            this.btnSaveDepartment.Size = new System.Drawing.Size(142, 50);
            this.btnSaveDepartment.TabIndex = 4;
            this.btnSaveDepartment.Text = "Зберегти";
            this.btnSaveDepartment.UseVisualStyleBackColor = true;
            this.btnSaveDepartment.Click += new System.EventHandler(this.btnSaveDepartment_Click);
            // 
            // btnCancelDepartmentEdit
            // 
            this.btnCancelDepartmentEdit.Location = new System.Drawing.Point(195, 189);
            this.btnCancelDepartmentEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelDepartmentEdit.Name = "btnCancelDepartmentEdit";
            this.btnCancelDepartmentEdit.Size = new System.Drawing.Size(146, 50);
            this.btnCancelDepartmentEdit.TabIndex = 5;
            this.btnCancelDepartmentEdit.Text = "Скасувати";
            this.btnCancelDepartmentEdit.UseVisualStyleBackColor = true;
            this.btnCancelDepartmentEdit.Click += new System.EventHandler(this.btnCancelDepartmentEdit_Click);
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(14, 117);
            this.txtDepartmentName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(327, 34);
            this.txtDepartmentName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Введіть назву нового підрозділу";
            // 
            // btnSearchDepartments
            // 
            this.btnSearchDepartments.Location = new System.Drawing.Point(1127, 25);
            this.btnSearchDepartments.Name = "btnSearchDepartments";
            this.btnSearchDepartments.Size = new System.Drawing.Size(209, 34);
            this.btnSearchDepartments.TabIndex = 10;
            this.btnSearchDepartments.Text = "Пошук підрозділів";
            this.btnSearchDepartments.UseVisualStyleBackColor = true;
            this.btnSearchDepartments.Click += new System.EventHandler(this.btnSearchDepartments_Click);
            // 
            // txtSearchDepartments
            // 
            this.txtSearchDepartments.Location = new System.Drawing.Point(807, 25);
            this.txtSearchDepartments.Name = "txtSearchDepartments";
            this.txtSearchDepartments.Size = new System.Drawing.Size(300, 34);
            this.txtSearchDepartments.TabIndex = 9;
            // 
            // btnSearchEmployees
            // 
            this.btnSearchEmployees.Location = new System.Drawing.Point(335, 25);
            this.btnSearchEmployees.Name = "btnSearchEmployees";
            this.btnSearchEmployees.Size = new System.Drawing.Size(201, 34);
            this.btnSearchEmployees.TabIndex = 12;
            this.btnSearchEmployees.Text = "Пошук працівників";
            this.btnSearchEmployees.UseVisualStyleBackColor = true;
            this.btnSearchEmployees.Click += new System.EventHandler(this.btnSearchEmployees_Click);
            // 
            // txtSearchEmployees
            // 
            this.txtSearchEmployees.Location = new System.Drawing.Point(15, 25);
            this.txtSearchEmployees.Name = "txtSearchEmployees";
            this.txtSearchEmployees.Size = new System.Drawing.Size(300, 34);
            this.txtSearchEmployees.TabIndex = 11;
            // 
            // DepartmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1561, 782);
            this.Controls.Add(this.btnSearchEmployees);
            this.Controls.Add(this.txtSearchEmployees);
            this.Controls.Add(this.btnSearchDepartments);
            this.Controls.Add(this.txtSearchDepartments);
            this.Controls.Add(this.groupBoxDepartmentEdit);
            this.Controls.Add(this.btnDeleteDepartment);
            this.Controls.Add(this.btnEditDepartment);
            this.Controls.Add(this.btnReloadDepartments);
            this.Controls.Add(this.btnAddDepartment);
            this.Controls.Add(this.btnAssignDepartment);
            this.Controls.Add(this.dgvDepartments);
            this.Controls.Add(this.dgvEmployeesWithDepartments);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DepartmentsForm";
            this.Text = "DepartmentsForm";
            this.Load += new System.EventHandler(this.DepartmentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeesWithDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.groupBoxDepartmentEdit.ResumeLayout(false);
            this.groupBoxDepartmentEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployeesWithDepartments;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.Button btnAssignDepartment;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Button btnReloadDepartments;
        private System.Windows.Forms.Button btnEditDepartment;
        private System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.GroupBox groupBoxDepartmentEdit;
        private System.Windows.Forms.Button btnCancelDepartmentEdit;
        private System.Windows.Forms.Button btnSaveDepartment;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchDepartments;
        private System.Windows.Forms.TextBox txtSearchDepartments;
        private System.Windows.Forms.Button btnSearchEmployees;
        private System.Windows.Forms.TextBox txtSearchEmployees;
    }
}