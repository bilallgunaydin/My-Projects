namespace WForm.Project_Manager
{
    partial class ProjectCreateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBxProjectName = new System.Windows.Forms.TextBox();
            this.txtBxDescription = new System.Windows.Forms.TextBox();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.dtpGenerateDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDeadLine = new System.Windows.Forms.DateTimePicker();
            this.BtnCreateProject = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.lstEmployee = new System.Windows.Forms.ListBox();
            this.lstProjectEmployee = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbTeamLead = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProjectManager = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proje Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proje Açıklaması:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Proje Yöneticisi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Şirket Adı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "İstenen Tarih:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 6;
            this.label7.Tag = "";
            this.label7.Text = "İstenen Bitiş Tarihi:";
            // 
            // txtBxProjectName
            // 
            this.txtBxProjectName.Location = new System.Drawing.Point(132, 13);
            this.txtBxProjectName.Name = "txtBxProjectName";
            this.txtBxProjectName.Size = new System.Drawing.Size(284, 20);
            this.txtBxProjectName.TabIndex = 0;
            // 
            // txtBxDescription
            // 
            this.txtBxDescription.Location = new System.Drawing.Point(131, 51);
            this.txtBxDescription.Multiline = true;
            this.txtBxDescription.Name = "txtBxDescription";
            this.txtBxDescription.Size = new System.Drawing.Size(286, 102);
            this.txtBxDescription.TabIndex = 1;
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(131, 226);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(286, 21);
            this.cmbCustomerName.TabIndex = 3;
            // 
            // dtpGenerateDate
            // 
            this.dtpGenerateDate.Location = new System.Drawing.Point(130, 260);
            this.dtpGenerateDate.Name = "dtpGenerateDate";
            this.dtpGenerateDate.Size = new System.Drawing.Size(287, 20);
            this.dtpGenerateDate.TabIndex = 4;
            // 
            // dtpDeadLine
            // 
            this.dtpDeadLine.Location = new System.Drawing.Point(131, 293);
            this.dtpDeadLine.Name = "dtpDeadLine";
            this.dtpDeadLine.Size = new System.Drawing.Size(287, 20);
            this.dtpDeadLine.TabIndex = 5;
            // 
            // BtnCreateProject
            // 
            this.BtnCreateProject.Location = new System.Drawing.Point(669, 282);
            this.BtnCreateProject.Name = "BtnCreateProject";
            this.BtnCreateProject.Size = new System.Drawing.Size(175, 31);
            this.BtnCreateProject.TabIndex = 8;
            this.BtnCreateProject.Text = "Projeyi Oluştur";
            this.BtnCreateProject.UseVisualStyleBackColor = true;
            this.BtnCreateProject.Click += new System.EventHandler(this.BtnCreateProject_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(446, 282);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(175, 31);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Location = new System.Drawing.Point(446, 13);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(398, 21);
            this.cmbAccountType.TabIndex = 10;
            this.cmbAccountType.SelectedIndexChanged += new System.EventHandler(this.cmbAccountType_SelectedIndexChanged);
            // 
            // lstEmployee
            // 
            this.lstEmployee.FormattingEnabled = true;
            this.lstEmployee.Location = new System.Drawing.Point(446, 49);
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(175, 225);
            this.lstEmployee.TabIndex = 11;
            // 
            // lstProjectEmployee
            // 
            this.lstProjectEmployee.FormattingEnabled = true;
            this.lstProjectEmployee.Location = new System.Drawing.Point(669, 51);
            this.lstProjectEmployee.Name = "lstProjectEmployee";
            this.lstProjectEmployee.Size = new System.Drawing.Size(175, 225);
            this.lstProjectEmployee.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(627, 157);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "-->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbTeamLead
            // 
            this.cmbTeamLead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeamLead.FormattingEnabled = true;
            this.cmbTeamLead.Location = new System.Drawing.Point(131, 192);
            this.cmbTeamLead.Name = "cmbTeamLead";
            this.cmbTeamLead.Size = new System.Drawing.Size(286, 21);
            this.cmbTeamLead.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Takım Lideri :";
            // 
            // txtProjectManager
            // 
            this.txtProjectManager.Location = new System.Drawing.Point(130, 164);
            this.txtProjectManager.Name = "txtProjectManager";
            this.txtProjectManager.Size = new System.Drawing.Size(286, 20);
            this.txtProjectManager.TabIndex = 16;
            // 
            // ProjectCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 363);
            this.Controls.Add(this.txtProjectManager);
            this.Controls.Add(this.cmbTeamLead);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstProjectEmployee);
            this.Controls.Add(this.lstEmployee);
            this.Controls.Add(this.cmbAccountType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.BtnCreateProject);
            this.Controls.Add(this.dtpDeadLine);
            this.Controls.Add(this.dtpGenerateDate);
            this.Controls.Add(this.cmbCustomerName);
            this.Controls.Add(this.txtBxDescription);
            this.Controls.Add(this.txtBxProjectName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProjectCreateForm";
            this.Text = "ProjectCreateForm";
            this.Load += new System.EventHandler(this.ProjectCreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBxProjectName;
        private System.Windows.Forms.TextBox txtBxDescription;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.DateTimePicker dtpGenerateDate;
        private System.Windows.Forms.DateTimePicker dtpDeadLine;
        private System.Windows.Forms.Button BtnCreateProject;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.ListBox lstEmployee;
        private System.Windows.Forms.ListBox lstProjectEmployee;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbTeamLead;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProjectManager;
    }
}