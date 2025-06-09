namespace PersonnelDepartmentApp.Forms
{
    partial class EducationsForm
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
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.dgvEducations = new System.Windows.Forms.DataGridView();
            this.groupBoxAddEducation = new System.Windows.Forms.GroupBox();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnSaveEducation = new System.Windows.Forms.Button();
            this.numGraduationYear = new System.Windows.Forms.NumericUpDown();
            this.lblGraduationYear = new System.Windows.Forms.Label();
            this.txtInstitution = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMajor = new System.Windows.Forms.Label();
            this.txtDegree = new System.Windows.Forms.TextBox();
            this.lblDegree = new System.Windows.Forms.Label();
            this.btnAddEducation = new System.Windows.Forms.Button();
            this.btnEditEducation = new System.Windows.Forms.Button();
            this.btnDeleteEducation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEducations)).BeginInit();
            this.groupBoxAddEducation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGraduationYear)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(169, 17);
            this.cmbEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(296, 36);
            this.cmbEmployee.TabIndex = 0;
            this.cmbEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(16, 17);
            this.lblEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(135, 28);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Співробітник";
            // 
            // dgvEducations
            // 
            this.dgvEducations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEducations.Location = new System.Drawing.Point(21, 79);
            this.dgvEducations.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEducations.Name = "dgvEducations";
            this.dgvEducations.RowHeadersWidth = 62;
            this.dgvEducations.RowTemplate.Height = 28;
            this.dgvEducations.Size = new System.Drawing.Size(993, 496);
            this.dgvEducations.TabIndex = 2;
            // 
            // groupBoxAddEducation
            // 
            this.groupBoxAddEducation.Controls.Add(this.txtMajor);
            this.groupBoxAddEducation.Controls.Add(this.btnCancelEdit);
            this.groupBoxAddEducation.Controls.Add(this.btnSaveEducation);
            this.groupBoxAddEducation.Controls.Add(this.numGraduationYear);
            this.groupBoxAddEducation.Controls.Add(this.lblGraduationYear);
            this.groupBoxAddEducation.Controls.Add(this.txtInstitution);
            this.groupBoxAddEducation.Controls.Add(this.label1);
            this.groupBoxAddEducation.Controls.Add(this.lblMajor);
            this.groupBoxAddEducation.Controls.Add(this.txtDegree);
            this.groupBoxAddEducation.Controls.Add(this.lblDegree);
            this.groupBoxAddEducation.Location = new System.Drawing.Point(665, 3);
            this.groupBoxAddEducation.Name = "groupBoxAddEducation";
            this.groupBoxAddEducation.Size = new System.Drawing.Size(384, 686);
            this.groupBoxAddEducation.TabIndex = 3;
            this.groupBoxAddEducation.TabStop = false;
            this.groupBoxAddEducation.Text = "Додати/Редагувати освіту";
            // 
            // txtMajor
            // 
            this.txtMajor.Location = new System.Drawing.Point(12, 166);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(362, 34);
            this.txtMajor.TabIndex = 9;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Location = new System.Drawing.Point(217, 601);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(132, 65);
            this.btnCancelEdit.TabIndex = 8;
            this.btnCancelEdit.Text = "Скасувати";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnSaveEducation
            // 
            this.btnSaveEducation.Location = new System.Drawing.Point(23, 601);
            this.btnSaveEducation.Name = "btnSaveEducation";
            this.btnSaveEducation.Size = new System.Drawing.Size(128, 65);
            this.btnSaveEducation.TabIndex = 7;
            this.btnSaveEducation.Text = "Зберегти";
            this.btnSaveEducation.UseVisualStyleBackColor = true;
            this.btnSaveEducation.Click += new System.EventHandler(this.btnSaveEducation_Click);
            // 
            // numGraduationYear
            // 
            this.numGraduationYear.Location = new System.Drawing.Point(12, 390);
            this.numGraduationYear.Name = "numGraduationYear";
            this.numGraduationYear.Size = new System.Drawing.Size(176, 34);
            this.numGraduationYear.TabIndex = 6;
            // 
            // lblGraduationYear
            // 
            this.lblGraduationYear.AutoSize = true;
            this.lblGraduationYear.Location = new System.Drawing.Point(7, 338);
            this.lblGraduationYear.Name = "lblGraduationYear";
            this.lblGraduationYear.Size = new System.Drawing.Size(144, 28);
            this.lblGraduationYear.TabIndex = 5;
            this.lblGraduationYear.Text = "Рік закінчення";
            // 
            // txtInstitution
            // 
            this.txtInstitution.Location = new System.Drawing.Point(12, 257);
            this.txtInstitution.Name = "txtInstitution";
            this.txtInstitution.Size = new System.Drawing.Size(362, 34);
            this.txtInstitution.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Заклад";
            // 
            // lblMajor
            // 
            this.lblMajor.AutoSize = true;
            this.lblMajor.Location = new System.Drawing.Point(7, 135);
            this.lblMajor.Name = "lblMajor";
            this.lblMajor.Size = new System.Drawing.Size(138, 28);
            this.lblMajor.TabIndex = 2;
            this.lblMajor.Text = "Спеціальність";
            // 
            // txtDegree
            // 
            this.txtDegree.Location = new System.Drawing.Point(12, 81);
            this.txtDegree.Name = "txtDegree";
            this.txtDegree.Size = new System.Drawing.Size(362, 34);
            this.txtDegree.TabIndex = 1;
            // 
            // lblDegree
            // 
            this.lblDegree.AutoSize = true;
            this.lblDegree.Location = new System.Drawing.Point(7, 49);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(81, 28);
            this.lblDegree.TabIndex = 0;
            this.lblDegree.Text = "Ступінь";
            // 
            // btnAddEducation
            // 
            this.btnAddEducation.Location = new System.Drawing.Point(21, 604);
            this.btnAddEducation.Name = "btnAddEducation";
            this.btnAddEducation.Size = new System.Drawing.Size(130, 72);
            this.btnAddEducation.TabIndex = 4;
            this.btnAddEducation.Text = "Додати освіту";
            this.btnAddEducation.UseVisualStyleBackColor = true;
            this.btnAddEducation.Click += new System.EventHandler(this.btnAddEducation_Click);
            // 
            // btnEditEducation
            // 
            this.btnEditEducation.Location = new System.Drawing.Point(169, 604);
            this.btnEditEducation.Name = "btnEditEducation";
            this.btnEditEducation.Size = new System.Drawing.Size(130, 72);
            this.btnEditEducation.TabIndex = 5;
            this.btnEditEducation.Text = "Редагувати освіту";
            this.btnEditEducation.UseVisualStyleBackColor = true;
            this.btnEditEducation.Click += new System.EventHandler(this.btnEditEducation_Click);
            // 
            // btnDeleteEducation
            // 
            this.btnDeleteEducation.Location = new System.Drawing.Point(320, 604);
            this.btnDeleteEducation.Name = "btnDeleteEducation";
            this.btnDeleteEducation.Size = new System.Drawing.Size(130, 72);
            this.btnDeleteEducation.TabIndex = 6;
            this.btnDeleteEducation.Text = "Видалити освіту";
            this.btnDeleteEducation.UseVisualStyleBackColor = true;
            this.btnDeleteEducation.Click += new System.EventHandler(this.btnDeleteEducation_Click);
            // 
            // EducationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 694);
            this.Controls.Add(this.btnDeleteEducation);
            this.Controls.Add(this.btnEditEducation);
            this.Controls.Add(this.btnAddEducation);
            this.Controls.Add(this.groupBoxAddEducation);
            this.Controls.Add(this.dgvEducations);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EducationsForm";
            this.Text = "Освіта";
            this.Load += new System.EventHandler(this.EducationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEducations)).EndInit();
            this.groupBoxAddEducation.ResumeLayout(false);
            this.groupBoxAddEducation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGraduationYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.DataGridView dgvEducations;
        private System.Windows.Forms.GroupBox groupBoxAddEducation;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnSaveEducation;
        private System.Windows.Forms.NumericUpDown numGraduationYear;
        private System.Windows.Forms.Label lblGraduationYear;
        private System.Windows.Forms.TextBox txtInstitution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMajor;
        private System.Windows.Forms.TextBox txtDegree;
        private System.Windows.Forms.Button btnAddEducation;
        private System.Windows.Forms.Button btnEditEducation;
        private System.Windows.Forms.Button btnDeleteEducation;
        private System.Windows.Forms.TextBox txtMajor;
    }
}