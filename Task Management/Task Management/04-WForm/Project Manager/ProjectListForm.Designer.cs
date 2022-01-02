namespace WForm.Project_Manager
{
    partial class ProjectListForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvProjectList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iptalEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpDeadLine = new System.Windows.Forms.DateTimePicker();
            this.dtpGenerate = new System.Windows.Forms.DateTimePicker();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.txtProjectDesc = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbTeamLead = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMyProject = new System.Windows.Forms.Button();
            this.btnFinishProject = new System.Windows.Forms.Button();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.dgvFinishProject = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinishProject)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProjectList
            // 
            this.dgvProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjectList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvProjectList.Location = new System.Drawing.Point(11, 218);
            this.dgvProjectList.MultiSelect = false;
            this.dgvProjectList.Name = "dgvProjectList";
            this.dgvProjectList.ReadOnly = true;
            this.dgvProjectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjectList.Size = new System.Drawing.Size(598, 313);
            this.dgvProjectList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem,
            this.iptalEtToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // iptalEtToolStripMenuItem
            // 
            this.iptalEtToolStripMenuItem.Name = "iptalEtToolStripMenuItem";
            this.iptalEtToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.iptalEtToolStripMenuItem.Text = "İptal Et";
            this.iptalEtToolStripMenuItem.Click += new System.EventHandler(this.iptalEtToolStripMenuItem_Click);
            // 
            // dtpDeadLine
            // 
            this.dtpDeadLine.Location = new System.Drawing.Point(693, 104);
            this.dtpDeadLine.Name = "dtpDeadLine";
            this.dtpDeadLine.Size = new System.Drawing.Size(285, 20);
            this.dtpDeadLine.TabIndex = 19;
            // 
            // dtpGenerate
            // 
            this.dtpGenerate.Location = new System.Drawing.Point(693, 57);
            this.dtpGenerate.Name = "dtpGenerate";
            this.dtpGenerate.Size = new System.Drawing.Size(285, 20);
            this.dtpGenerate.TabIndex = 17;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(692, 15);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(284, 21);
            this.cmbCustomer.TabIndex = 15;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(125, 148);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(284, 21);
            this.cmbEmployee.TabIndex = 13;
            // 
            // txtProjectDesc
            // 
            this.txtProjectDesc.Location = new System.Drawing.Point(123, 39);
            this.txtProjectDesc.Multiline = true;
            this.txtProjectDesc.Name = "txtProjectDesc";
            this.txtProjectDesc.Size = new System.Drawing.Size(286, 102);
            this.txtProjectDesc.TabIndex = 11;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(123, 12);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(284, 20);
            this.txtProjectName.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(591, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 21;
            this.label7.Tag = "";
            this.label7.Text = "İstenen Bitiş Tarihi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(616, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "İstenen Tarih:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(629, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Müşteri Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Proje Yöneticisi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Proje Açıklaması:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Proje Adı:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(819, 151);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(159, 38);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbTeamLead
            // 
            this.cmbTeamLead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeamLead.FormattingEnabled = true;
            this.cmbTeamLead.Location = new System.Drawing.Point(125, 191);
            this.cmbTeamLead.Name = "cmbTeamLead";
            this.cmbTeamLead.Size = new System.Drawing.Size(284, 21);
            this.cmbTeamLead.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Takım Lideri :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMyProject);
            this.groupBox1.Controls.Add(this.btnFinishProject);
            this.groupBox1.Controls.Add(this.btnGetAll);
            this.groupBox1.Location = new System.Drawing.Point(607, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 311);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projeleri Filtrele";
            // 
            // btnMyProject
            // 
            this.btnMyProject.Location = new System.Drawing.Point(9, 35);
            this.btnMyProject.Name = "btnMyProject";
            this.btnMyProject.Size = new System.Drawing.Size(70, 38);
            this.btnMyProject.TabIndex = 29;
            this.btnMyProject.Text = "Projelerim";
            this.btnMyProject.UseVisualStyleBackColor = true;
            this.btnMyProject.Click += new System.EventHandler(this.btnMyProject_Click);
            // 
            // btnFinishProject
            // 
            this.btnFinishProject.Location = new System.Drawing.Point(9, 245);
            this.btnFinishProject.Name = "btnFinishProject";
            this.btnFinishProject.Size = new System.Drawing.Size(70, 38);
            this.btnFinishProject.TabIndex = 31;
            this.btnFinishProject.Text = "Projeyi Kapat";
            this.btnFinishProject.UseVisualStyleBackColor = true;
            this.btnFinishProject.Click += new System.EventHandler(this.btnFinishProject_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(8, 141);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(70, 38);
            this.btnGetAll.TabIndex = 30;
            this.btnGetAll.Text = "Tümünü Gör";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // dgvFinishProject
            // 
            this.dgvFinishProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFinishProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinishProject.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvFinishProject.Location = new System.Drawing.Point(693, 218);
            this.dgvFinishProject.MultiSelect = false;
            this.dgvFinishProject.Name = "dgvFinishProject";
            this.dgvFinishProject.ReadOnly = true;
            this.dgvFinishProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFinishProject.Size = new System.Drawing.Size(285, 313);
            this.dgvFinishProject.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(690, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 30;
            this.label8.Tag = "";
            this.label8.Text = "Tamamlanan Projeler";
            // 
            // ProjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 537);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvFinishProject);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbTeamLead);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtpDeadLine);
            this.Controls.Add(this.dtpGenerate);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.txtProjectDesc);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProjectList);
            this.Name = "ProjectListForm";
            this.Text = "ProjectListForm";
            this.Load += new System.EventHandler(this.ProjectListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinishProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProjectList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iptalEtToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpDeadLine;
        private System.Windows.Forms.DateTimePicker dtpGenerate;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.TextBox txtProjectDesc;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbTeamLead;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnMyProject;
        private System.Windows.Forms.Button btnFinishProject;
        private System.Windows.Forms.DataGridView dgvFinishProject;
        private System.Windows.Forms.Label label8;
    }
}