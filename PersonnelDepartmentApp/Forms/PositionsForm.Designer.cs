namespace PersonnelDepartmentApp
{
    partial class PositionsForm
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
            this.btnResetSort = new System.Windows.Forms.Button();
            this.btnSearchPositions = new System.Windows.Forms.Button();
            this.txtSearchPositions = new System.Windows.Forms.TextBox();
            this.groupBoxPositionEdit = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Найменування = new System.Windows.Forms.Label();
            this.txtPositionSalary = new System.Windows.Forms.TextBox();
            this.txtPositionRequirements = new System.Windows.Forms.TextBox();
            this.txtPositionTitle = new System.Windows.Forms.TextBox();
            this.btnCancelPositionEdit = new System.Windows.Forms.Button();
            this.btnSavePosition = new System.Windows.Forms.Button();
            this.btnDeletePosition = new System.Windows.Forms.Button();
            this.btnEditPosition = new System.Windows.Forms.Button();
            this.btnReloadPositions = new System.Windows.Forms.Button();
            this.btnAddPosition = new System.Windows.Forms.Button();
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.btnRemovePositionFromEmployee = new System.Windows.Forms.Button();
            this.btnResetEmpSort = new System.Windows.Forms.Button();
            this.btnSearchEmployees = new System.Windows.Forms.Button();
            this.txtSearchEmployees = new System.Windows.Forms.TextBox();
            this.btnAssignPosition = new System.Windows.Forms.Button();
            this.dgvEmployeesWithPositions = new System.Windows.Forms.DataGridView();
            this.groupBoxPositionEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeesWithPositions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResetSort
            // 
            this.btnResetSort.Location = new System.Drawing.Point(1422, 22);
            this.btnResetSort.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetSort.Name = "btnResetSort";
            this.btnResetSort.Size = new System.Drawing.Size(211, 48);
            this.btnResetSort.TabIndex = 28;
            this.btnResetSort.Text = "Скинути сорт.";
            this.btnResetSort.UseVisualStyleBackColor = true;
            this.btnResetSort.Click += new System.EventHandler(this.btnResetSort_Click_1);
            // 
            // btnSearchPositions
            // 
            this.btnSearchPositions.Location = new System.Drawing.Point(1203, 22);
            this.btnSearchPositions.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchPositions.Name = "btnSearchPositions";
            this.btnSearchPositions.Size = new System.Drawing.Size(211, 48);
            this.btnSearchPositions.TabIndex = 25;
            this.btnSearchPositions.Text = "Пошук пос.";
            this.btnSearchPositions.UseVisualStyleBackColor = true;
            this.btnSearchPositions.Click += new System.EventHandler(this.btnSearchPositions_Click);
            // 
            // txtSearchPositions
            // 
            this.txtSearchPositions.Location = new System.Drawing.Point(816, 22);
            this.txtSearchPositions.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchPositions.Name = "txtSearchPositions";
            this.txtSearchPositions.Size = new System.Drawing.Size(366, 34);
            this.txtSearchPositions.TabIndex = 24;
            this.txtSearchPositions.TextChanged += new System.EventHandler(this.txtSearchPositions_TextChanged_1);
            // 
            // groupBoxPositionEdit
            // 
            this.groupBoxPositionEdit.Controls.Add(this.label2);
            this.groupBoxPositionEdit.Controls.Add(this.label1);
            this.groupBoxPositionEdit.Controls.Add(this.Найменування);
            this.groupBoxPositionEdit.Controls.Add(this.txtPositionSalary);
            this.groupBoxPositionEdit.Controls.Add(this.txtPositionRequirements);
            this.groupBoxPositionEdit.Controls.Add(this.txtPositionTitle);
            this.groupBoxPositionEdit.Controls.Add(this.btnCancelPositionEdit);
            this.groupBoxPositionEdit.Controls.Add(this.btnSavePosition);
            this.groupBoxPositionEdit.Location = new System.Drawing.Point(1216, 80);
            this.groupBoxPositionEdit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBoxPositionEdit.Name = "groupBoxPositionEdit";
            this.groupBoxPositionEdit.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBoxPositionEdit.Size = new System.Drawing.Size(425, 557);
            this.groupBoxPositionEdit.TabIndex = 23;
            this.groupBoxPositionEdit.TabStop = false;
            this.groupBoxPositionEdit.Text = "Дані посади";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 305);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Вимоги до посади";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 178);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "Зарплата за посадою";
            // 
            // Найменування
            // 
            this.Найменування.AutoSize = true;
            this.Найменування.Location = new System.Drawing.Point(8, 51);
            this.Найменування.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Найменування.Name = "Найменування";
            this.Найменування.Size = new System.Drawing.Size(220, 28);
            this.Найменування.TabIndex = 14;
            this.Найменування.Text = "Найменування посади";
            // 
            // txtPositionSalary
            // 
            this.txtPositionSalary.Location = new System.Drawing.Point(13, 237);
            this.txtPositionSalary.Margin = new System.Windows.Forms.Padding(4);
            this.txtPositionSalary.Name = "txtPositionSalary";
            this.txtPositionSalary.Size = new System.Drawing.Size(394, 34);
            this.txtPositionSalary.TabIndex = 13;
            // 
            // txtPositionRequirements
            // 
            this.txtPositionRequirements.Location = new System.Drawing.Point(13, 364);
            this.txtPositionRequirements.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPositionRequirements.Name = "txtPositionRequirements";
            this.txtPositionRequirements.Size = new System.Drawing.Size(399, 34);
            this.txtPositionRequirements.TabIndex = 12;
            // 
            // txtPositionTitle
            // 
            this.txtPositionTitle.Location = new System.Drawing.Point(8, 104);
            this.txtPositionTitle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPositionTitle.Name = "txtPositionTitle";
            this.txtPositionTitle.Size = new System.Drawing.Size(399, 34);
            this.txtPositionTitle.TabIndex = 9;
            // 
            // btnCancelPositionEdit
            // 
            this.btnCancelPositionEdit.Location = new System.Drawing.Point(229, 475);
            this.btnCancelPositionEdit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCancelPositionEdit.Name = "btnCancelPositionEdit";
            this.btnCancelPositionEdit.Size = new System.Drawing.Size(167, 59);
            this.btnCancelPositionEdit.TabIndex = 5;
            this.btnCancelPositionEdit.Text = "Скасувати";
            this.btnCancelPositionEdit.UseVisualStyleBackColor = true;
            this.btnCancelPositionEdit.Click += new System.EventHandler(this.btnCancelPositionEdit_Click);
            // 
            // btnSavePosition
            // 
            this.btnSavePosition.Location = new System.Drawing.Point(19, 475);
            this.btnSavePosition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSavePosition.Name = "btnSavePosition";
            this.btnSavePosition.Size = new System.Drawing.Size(174, 59);
            this.btnSavePosition.TabIndex = 4;
            this.btnSavePosition.Text = "Зберегти";
            this.btnSavePosition.UseVisualStyleBackColor = true;
            this.btnSavePosition.Click += new System.EventHandler(this.btnSavePosition_Click);
            // 
            // btnDeletePosition
            // 
            this.btnDeletePosition.Location = new System.Drawing.Point(1150, 649);
            this.btnDeletePosition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnDeletePosition.Name = "btnDeletePosition";
            this.btnDeletePosition.Size = new System.Drawing.Size(147, 68);
            this.btnDeletePosition.TabIndex = 22;
            this.btnDeletePosition.Text = "Видалити посаду";
            this.btnDeletePosition.UseVisualStyleBackColor = true;
            this.btnDeletePosition.Click += new System.EventHandler(this.btnDeletePosition_Click);
            // 
            // btnEditPosition
            // 
            this.btnEditPosition.Location = new System.Drawing.Point(984, 650);
            this.btnEditPosition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnEditPosition.Name = "btnEditPosition";
            this.btnEditPosition.Size = new System.Drawing.Size(140, 67);
            this.btnEditPosition.TabIndex = 21;
            this.btnEditPosition.Text = "Редагувати посаду";
            this.btnEditPosition.UseVisualStyleBackColor = true;
            this.btnEditPosition.Click += new System.EventHandler(this.btnEditPosition_Click);
            // 
            // btnReloadPositions
            // 
            this.btnReloadPositions.Location = new System.Drawing.Point(1464, 649);
            this.btnReloadPositions.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnReloadPositions.Name = "btnReloadPositions";
            this.btnReloadPositions.Size = new System.Drawing.Size(148, 68);
            this.btnReloadPositions.TabIndex = 20;
            this.btnReloadPositions.Text = "Оновити посади";
            this.btnReloadPositions.UseVisualStyleBackColor = true;
            this.btnReloadPositions.Click += new System.EventHandler(this.btnReloadPositions_Click);
            // 
            // btnAddPosition
            // 
            this.btnAddPosition.Location = new System.Drawing.Point(816, 650);
            this.btnAddPosition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnAddPosition.Name = "btnAddPosition";
            this.btnAddPosition.Size = new System.Drawing.Size(143, 67);
            this.btnAddPosition.TabIndex = 19;
            this.btnAddPosition.Text = "Додати посаду";
            this.btnAddPosition.UseVisualStyleBackColor = true;
            this.btnAddPosition.Click += new System.EventHandler(this.btnAddPosition_Click);
            // 
            // dgvPositions
            // 
            this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositions.Location = new System.Drawing.Point(816, 80);
            this.dgvPositions.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.RowHeadersWidth = 62;
            this.dgvPositions.RowTemplate.Height = 28;
            this.dgvPositions.Size = new System.Drawing.Size(796, 534);
            this.dgvPositions.TabIndex = 17;
            // 
            // btnRemovePositionFromEmployee
            // 
            this.btnRemovePositionFromEmployee.Location = new System.Drawing.Point(231, 647);
            this.btnRemovePositionFromEmployee.Name = "btnRemovePositionFromEmployee";
            this.btnRemovePositionFromEmployee.Size = new System.Drawing.Size(221, 68);
            this.btnRemovePositionFromEmployee.TabIndex = 34;
            this.btnRemovePositionFromEmployee.Text = "Видалити посаду у співробітника";
            this.btnRemovePositionFromEmployee.UseVisualStyleBackColor = true;
            this.btnRemovePositionFromEmployee.Click += new System.EventHandler(this.btnRemovePositionFromEmployee_Click);
            // 
            // btnResetEmpSort
            // 
            this.btnResetEmpSort.Location = new System.Drawing.Point(569, 21);
            this.btnResetEmpSort.Name = "btnResetEmpSort";
            this.btnResetEmpSort.Size = new System.Drawing.Size(175, 34);
            this.btnResetEmpSort.TabIndex = 33;
            this.btnResetEmpSort.Text = "Скинути сорт.";
            this.btnResetEmpSort.UseVisualStyleBackColor = true;
            this.btnResetEmpSort.Click += new System.EventHandler(this.btnResetEmpSort_Click);
            // 
            // btnSearchEmployees
            // 
            this.btnSearchEmployees.Location = new System.Drawing.Point(378, 21);
            this.btnSearchEmployees.Name = "btnSearchEmployees";
            this.btnSearchEmployees.Size = new System.Drawing.Size(185, 34);
            this.btnSearchEmployees.TabIndex = 32;
            this.btnSearchEmployees.Text = "Пошук праців.";
            this.btnSearchEmployees.UseVisualStyleBackColor = true;
            this.btnSearchEmployees.Click += new System.EventHandler(this.btnSearchEmployees_Click);
            // 
            // txtSearchEmployees
            // 
            this.txtSearchEmployees.Location = new System.Drawing.Point(15, 21);
            this.txtSearchEmployees.Name = "txtSearchEmployees";
            this.txtSearchEmployees.Size = new System.Drawing.Size(342, 34);
            this.txtSearchEmployees.TabIndex = 31;
            this.txtSearchEmployees.TextChanged += new System.EventHandler(this.txtSearchEmployees_TextChanged);
            // 
            // btnAssignPosition
            // 
            this.btnAssignPosition.Location = new System.Drawing.Point(13, 647);
            this.btnAssignPosition.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssignPosition.Name = "btnAssignPosition";
            this.btnAssignPosition.Size = new System.Drawing.Size(197, 68);
            this.btnAssignPosition.TabIndex = 30;
            this.btnAssignPosition.Text = "Пере/Призначити посаду";
            this.btnAssignPosition.UseVisualStyleBackColor = true;
            this.btnAssignPosition.Click += new System.EventHandler(this.btnAssignPosition_Click);
            // 
            // dgvEmployeesWithPositions
            // 
            this.dgvEmployeesWithPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeesWithPositions.Location = new System.Drawing.Point(13, 80);
            this.dgvEmployeesWithPositions.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmployeesWithPositions.Name = "dgvEmployeesWithPositions";
            this.dgvEmployeesWithPositions.RowHeadersWidth = 62;
            this.dgvEmployeesWithPositions.RowTemplate.Height = 28;
            this.dgvEmployeesWithPositions.Size = new System.Drawing.Size(781, 534);
            this.dgvEmployeesWithPositions.TabIndex = 29;
            // 
            // PositionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1643, 731);
            this.Controls.Add(this.btnRemovePositionFromEmployee);
            this.Controls.Add(this.btnResetEmpSort);
            this.Controls.Add(this.btnSearchEmployees);
            this.Controls.Add(this.txtSearchEmployees);
            this.Controls.Add(this.btnAssignPosition);
            this.Controls.Add(this.dgvEmployeesWithPositions);
            this.Controls.Add(this.btnResetSort);
            this.Controls.Add(this.btnSearchPositions);
            this.Controls.Add(this.txtSearchPositions);
            this.Controls.Add(this.groupBoxPositionEdit);
            this.Controls.Add(this.btnDeletePosition);
            this.Controls.Add(this.btnEditPosition);
            this.Controls.Add(this.btnReloadPositions);
            this.Controls.Add(this.btnAddPosition);
            this.Controls.Add(this.dgvPositions);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PositionsForm";
            this.Text = "PositionsForm";
            this.Load += new System.EventHandler(this.PositionsForm_Load);
            this.groupBoxPositionEdit.ResumeLayout(false);
            this.groupBoxPositionEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeesWithPositions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnResetSort;
        private System.Windows.Forms.Button btnSearchPositions;
        private System.Windows.Forms.TextBox txtSearchPositions;
        private System.Windows.Forms.GroupBox groupBoxPositionEdit;
        private System.Windows.Forms.TextBox txtPositionTitle;
        private System.Windows.Forms.Button btnCancelPositionEdit;
        private System.Windows.Forms.Button btnSavePosition;
        private System.Windows.Forms.Button btnDeletePosition;
        private System.Windows.Forms.Button btnEditPosition;
        private System.Windows.Forms.Button btnReloadPositions;
        private System.Windows.Forms.Button btnAddPosition;
        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.TextBox txtPositionRequirements;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Найменування;
        private System.Windows.Forms.TextBox txtPositionSalary;
        private System.Windows.Forms.Button btnRemovePositionFromEmployee;
        private System.Windows.Forms.Button btnResetEmpSort;
        private System.Windows.Forms.Button btnSearchEmployees;
        private System.Windows.Forms.TextBox txtSearchEmployees;
        private System.Windows.Forms.Button btnAssignPosition;
        private System.Windows.Forms.DataGridView dgvEmployeesWithPositions;
    }
}