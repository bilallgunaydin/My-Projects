namespace WForm.Project_Manager
{
    partial class ProjectEmployeeAddForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstProjectEmployee = new System.Windows.Forms.ListBox();
            this.lstEmployee = new System.Windows.Forms.ListBox();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.BtnCreateProject = new System.Windows.Forms.Button();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(202, 234);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 23);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "-->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstProjectEmployee
            // 
            this.lstProjectEmployee.FormattingEnabled = true;
            this.lstProjectEmployee.Location = new System.Drawing.Point(244, 128);
            this.lstProjectEmployee.Name = "lstProjectEmployee";
            this.lstProjectEmployee.Size = new System.Drawing.Size(175, 225);
            this.lstProjectEmployee.TabIndex = 18;
            // 
            // lstEmployee
            // 
            this.lstEmployee.FormattingEnabled = true;
            this.lstEmployee.Location = new System.Drawing.Point(21, 126);
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(175, 225);
            this.lstEmployee.TabIndex = 17;
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Location = new System.Drawing.Point(21, 99);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(398, 21);
            this.cmbAccountType.TabIndex = 16;
            this.cmbAccountType.SelectedIndexChanged += new System.EventHandler(this.cmbAccountType_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(21, 359);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(175, 31);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BtnCreateProject
            // 
            this.BtnCreateProject.Location = new System.Drawing.Point(244, 359);
            this.BtnCreateProject.Name = "BtnCreateProject";
            this.BtnCreateProject.Size = new System.Drawing.Size(175, 31);
            this.BtnCreateProject.TabIndex = 14;
            this.BtnCreateProject.Text = "Projeye Ekle";
            this.BtnCreateProject.UseVisualStyleBackColor = true;
            this.BtnCreateProject.Click += new System.EventHandler(this.BtnCreateProject_Click);
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(21, 38);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(398, 21);
            this.cmbProject.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Pozisyon Seç";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Proje Adı ";
            // 
            // ProjectEmployeeAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 429);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstProjectEmployee);
            this.Controls.Add(this.lstEmployee);
            this.Controls.Add(this.cmbAccountType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.BtnCreateProject);
            this.Name = "ProjectEmployeeAddForm";
            this.Text = "ProjectEmployeeAddForm";
            this.Load += new System.EventHandler(this.ProjectEmployeeAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstProjectEmployee;
        private System.Windows.Forms.ListBox lstEmployee;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button BtnCreateProject;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}