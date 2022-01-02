namespace WForm.Project_Manager
{
    partial class ProjectManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniProjeOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projeleriListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çalışanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çalışanEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çalışanlarıListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projeyeEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projelerToolStripMenuItem,
            this.müşterilerToolStripMenuItem,
            this.çalışanlarToolStripMenuItem,
            this.işToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(990, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projelerToolStripMenuItem
            // 
            this.projelerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniProjeOluşturToolStripMenuItem,
            this.projeleriListeleToolStripMenuItem});
            this.projelerToolStripMenuItem.Name = "projelerToolStripMenuItem";
            this.projelerToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.projelerToolStripMenuItem.Text = "Proje";
            // 
            // yeniProjeOluşturToolStripMenuItem
            // 
            this.yeniProjeOluşturToolStripMenuItem.Name = "yeniProjeOluşturToolStripMenuItem";
            this.yeniProjeOluşturToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.yeniProjeOluşturToolStripMenuItem.Text = "Oluştur";
            this.yeniProjeOluşturToolStripMenuItem.Click += new System.EventHandler(this.yeniProjeOluşturToolStripMenuItem_Click);
            // 
            // projeleriListeleToolStripMenuItem
            // 
            this.projeleriListeleToolStripMenuItem.Name = "projeleriListeleToolStripMenuItem";
            this.projeleriListeleToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.projeleriListeleToolStripMenuItem.Text = "Listele";
            this.projeleriListeleToolStripMenuItem.Click += new System.EventHandler(this.projeleriListeleToolStripMenuItem_Click);
            // 
            // müşterilerToolStripMenuItem
            // 
            this.müşterilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriEkleToolStripMenuItem,
            this.müşteriListeleToolStripMenuItem});
            this.müşterilerToolStripMenuItem.Name = "müşterilerToolStripMenuItem";
            this.müşterilerToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.müşterilerToolStripMenuItem.Text = "Müşteri";
            // 
            // müşteriEkleToolStripMenuItem
            // 
            this.müşteriEkleToolStripMenuItem.Name = "müşteriEkleToolStripMenuItem";
            this.müşteriEkleToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.müşteriEkleToolStripMenuItem.Text = "Ekle";
            this.müşteriEkleToolStripMenuItem.Click += new System.EventHandler(this.müşteriEkleToolStripMenuItem_Click);
            // 
            // müşteriListeleToolStripMenuItem
            // 
            this.müşteriListeleToolStripMenuItem.Name = "müşteriListeleToolStripMenuItem";
            this.müşteriListeleToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.müşteriListeleToolStripMenuItem.Text = "Listele";
            this.müşteriListeleToolStripMenuItem.Click += new System.EventHandler(this.müşteriListeleToolStripMenuItem_Click);
            // 
            // çalışanlarToolStripMenuItem
            // 
            this.çalışanlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çalışanEkleToolStripMenuItem,
            this.çalışanlarıListeleToolStripMenuItem,
            this.projeyeEkleToolStripMenuItem});
            this.çalışanlarToolStripMenuItem.Name = "çalışanlarToolStripMenuItem";
            this.çalışanlarToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.çalışanlarToolStripMenuItem.Text = "Çalışan";
            // 
            // çalışanEkleToolStripMenuItem
            // 
            this.çalışanEkleToolStripMenuItem.Name = "çalışanEkleToolStripMenuItem";
            this.çalışanEkleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.çalışanEkleToolStripMenuItem.Text = "Ekle";
            this.çalışanEkleToolStripMenuItem.Click += new System.EventHandler(this.çalışanEkleToolStripMenuItem_Click);
            // 
            // çalışanlarıListeleToolStripMenuItem
            // 
            this.çalışanlarıListeleToolStripMenuItem.Name = "çalışanlarıListeleToolStripMenuItem";
            this.çalışanlarıListeleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.çalışanlarıListeleToolStripMenuItem.Text = "Listele";
            this.çalışanlarıListeleToolStripMenuItem.Click += new System.EventHandler(this.çalışanlarıListeleToolStripMenuItem_Click);
            // 
            // projeyeEkleToolStripMenuItem
            // 
            this.projeyeEkleToolStripMenuItem.Name = "projeyeEkleToolStripMenuItem";
            this.projeyeEkleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.projeyeEkleToolStripMenuItem.Text = "Projeye Ekle";
            this.projeyeEkleToolStripMenuItem.Click += new System.EventHandler(this.projeyeEkleToolStripMenuItem_Click);
            // 
            // işToolStripMenuItem
            // 
            this.işToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeleToolStripMenuItem});
            this.işToolStripMenuItem.Name = "işToolStripMenuItem";
            this.işToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.işToolStripMenuItem.Text = "Görev";
            // 
            // listeleToolStripMenuItem
            // 
            this.listeleToolStripMenuItem.Name = "listeleToolStripMenuItem";
            this.listeleToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.listeleToolStripMenuItem.Text = "Listele";
            this.listeleToolStripMenuItem.Click += new System.EventHandler(this.listeleToolStripMenuItem_Click);
            // 
            // ProjectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 554);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProjectManager";
            this.Text = "ProjectManager";
            this.Load += new System.EventHandler(this.ProjectManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniProjeOluşturToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projeleriListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşterilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşteriEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşteriListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çalışanlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çalışanEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çalışanlarıListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projeyeEkleToolStripMenuItem;
    }
}