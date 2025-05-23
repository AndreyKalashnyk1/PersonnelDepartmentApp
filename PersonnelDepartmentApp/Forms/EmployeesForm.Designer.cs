namespace PersonnelDepartmentApp
{
    partial class EmployeesForm
    {
        
        /// Required designer variable.
        
        private System.ComponentModel.IContainer components = null;

        
        /// Clean up any resources being used.
        
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

        
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        
        private void InitializeComponent()
        {
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBoxAddEmployee = new System.Windows.Forms.GroupBox();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.btnSaveEmployee = new System.Windows.Forms.Button();
            this.dtpTerminationDate = new System.Windows.Forms.DateTimePicker();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtPassportNumber = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetSort = new System.Windows.Forms.Button();
            this.btnGenerateOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.groupBoxAddEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 48);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersWidth = 62;
            this.dgvEmployees.RowTemplate.Height = 28;
            this.dgvEmployees.Size = new System.Drawing.Size(1184, 550);
            this.dgvEmployees.TabIndex = 0;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(12, 604);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(150, 69);
            this.btnAddEmployee.TabIndex = 1;
            this.btnAddEmployee.Text = "Додати співробітника";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(172, 604);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(139, 69);
            this.btnEditEmployee.TabIndex = 2;
            this.btnEditEmployee.Text = "Редагувати співробітника";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(332, 604);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(150, 69);
            this.btnDeleteEmployee.TabIndex = 3;
            this.btnDeleteEmployee.Text = "Видалити співробітника";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(497, 604);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 69);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Оновити список";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 34);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(332, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 34);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBoxAddEmployee
            // 
            this.groupBoxAddEmployee.Controls.Add(this.btnClearFields);
            this.groupBoxAddEmployee.Controls.Add(this.btnSaveEmployee);
            this.groupBoxAddEmployee.Controls.Add(this.dtpTerminationDate);
            this.groupBoxAddEmployee.Controls.Add(this.dtpHireDate);
            this.groupBoxAddEmployee.Controls.Add(this.dtpBirthDate);
            this.groupBoxAddEmployee.Controls.Add(this.txtFirstName);
            this.groupBoxAddEmployee.Controls.Add(this.txtSalary);
            this.groupBoxAddEmployee.Controls.Add(this.txtPassportNumber);
            this.groupBoxAddEmployee.Controls.Add(this.txtMiddleName);
            this.groupBoxAddEmployee.Controls.Add(this.txtLastName);
            this.groupBoxAddEmployee.Controls.Add(this.label8);
            this.groupBoxAddEmployee.Controls.Add(this.label7);
            this.groupBoxAddEmployee.Controls.Add(this.label6);
            this.groupBoxAddEmployee.Controls.Add(this.label5);
            this.groupBoxAddEmployee.Controls.Add(this.label4);
            this.groupBoxAddEmployee.Controls.Add(this.label3);
            this.groupBoxAddEmployee.Controls.Add(this.label2);
            this.groupBoxAddEmployee.Controls.Add(this.label1);
            this.groupBoxAddEmployee.Location = new System.Drawing.Point(838, 0);
            this.groupBoxAddEmployee.Name = "groupBoxAddEmployee";
            this.groupBoxAddEmployee.Size = new System.Drawing.Size(358, 685);
            this.groupBoxAddEmployee.TabIndex = 7;
            this.groupBoxAddEmployee.TabStop = false;
            this.groupBoxAddEmployee.Text = "Додавання співробітника";
            this.groupBoxAddEmployee.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(195, 604);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(150, 69);
            this.btnClearFields.TabIndex = 17;
            this.btnClearFields.Text = "Очистити поля";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // btnSaveEmployee
            // 
            this.btnSaveEmployee.Location = new System.Drawing.Point(23, 604);
            this.btnSaveEmployee.Name = "btnSaveEmployee";
            this.btnSaveEmployee.Size = new System.Drawing.Size(150, 69);
            this.btnSaveEmployee.TabIndex = 16;
            this.btnSaveEmployee.Text = "Зберегти";
            this.btnSaveEmployee.UseVisualStyleBackColor = true;
            this.btnSaveEmployee.Click += new System.EventHandler(this.btnSaveEmployee_Click);
            // 
            // dtpTerminationDate
            // 
            this.dtpTerminationDate.Location = new System.Drawing.Point(23, 555);
            this.dtpTerminationDate.Name = "dtpTerminationDate";
            this.dtpTerminationDate.Size = new System.Drawing.Size(322, 34);
            this.dtpTerminationDate.TabIndex = 15;
            this.dtpTerminationDate.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Location = new System.Drawing.Point(23, 487);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(322, 34);
            this.dtpHireDate.TabIndex = 14;
            this.dtpHireDate.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(23, 283);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(322, 34);
            this.dtpBirthDate.TabIndex = 13;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(23, 147);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(322, 34);
            this.txtFirstName.TabIndex = 12;
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(23, 419);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(322, 34);
            this.txtSalary.TabIndex = 11;
            this.txtSalary.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtPassportNumber
            // 
            this.txtPassportNumber.Location = new System.Drawing.Point(23, 351);
            this.txtPassportNumber.Name = "txtPassportNumber";
            this.txtPassportNumber.Size = new System.Drawing.Size(322, 34);
            this.txtPassportNumber.TabIndex = 10;
            this.txtPassportNumber.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(23, 215);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(322, 34);
            this.txtMiddleName.TabIndex = 9;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(23, 79);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(322, 34);
            this.txtLastName.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 524);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 28);
            this.label8.TabIndex = 7;
            this.label8.Text = "Дата звільнення";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 28);
            this.label7.TabIndex = 6;
            this.label7.Text = "Дата прийняття";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Зарплата";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Номер паспорта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата народження";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "По батькові";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ім\'я";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Прізвище";
            // 
            // btnResetSort
            // 
            this.btnResetSort.Location = new System.Drawing.Point(627, 8);
            this.btnResetSort.Name = "btnResetSort";
            this.btnResetSort.Size = new System.Drawing.Size(210, 34);
            this.btnResetSort.TabIndex = 8;
            this.btnResetSort.Text = "Скинути сортування";
            this.btnResetSort.UseVisualStyleBackColor = true;
            this.btnResetSort.Click += new System.EventHandler(this.btnResetSort_Click);
            // 
            // btnGenerateOrder
            // 
            this.btnGenerateOrder.Location = new System.Drawing.Point(662, 605);
            this.btnGenerateOrder.Name = "btnGenerateOrder";
            this.btnGenerateOrder.Size = new System.Drawing.Size(145, 68);
            this.btnGenerateOrder.TabIndex = 9;
            this.btnGenerateOrder.Text = "Генерувати наказ";
            this.btnGenerateOrder.UseVisualStyleBackColor = true;
            this.btnGenerateOrder.Click += new System.EventHandler(this.btnGenerateOrder_Click);
            // 
            // EmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 681);
            this.Controls.Add(this.btnGenerateOrder);
            this.Controls.Add(this.btnResetSort);
            this.Controls.Add(this.groupBoxAddEmployee);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnEditEmployee);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.dgvEmployees);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Відділ кадрів";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.groupBoxAddEmployee.ResumeLayout(false);
            this.groupBoxAddEmployee.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBoxAddEmployee;
        private System.Windows.Forms.DateTimePicker dtpTerminationDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.TextBox txtPassportNumber;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveEmployee;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.Button btnResetSort;
        private System.Windows.Forms.Button btnGenerateOrder;
    }
}