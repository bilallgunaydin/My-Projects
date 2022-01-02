namespace WForm.Team_Leader
{
    partial class TeamLeader
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
            this.projeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.talepFormuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projeToolStripMenuItem,
            this.müşteriToolStripMenuItem,
            this.işToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(673, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projeToolStripMenuItem
            // 
            this.projeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeleToolStripMenuItem});
            this.projeToolStripMenuItem.Name = "projeToolStripMenuItem";
            this.projeToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.projeToolStripMenuItem.Text = "Proje";
            // 
            // listeleToolStripMenuItem
            // 
            this.listeleToolStripMenuItem.Name = "listeleToolStripMenuItem";
            this.listeleToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.listeleToolStripMenuItem.Text = "Listele";
            this.listeleToolStripMenuItem.Click += new System.EventHandler(this.listeleToolStripMenuItem_Click);
            // 
            // müşteriToolStripMenuItem
            // 
            this.müşteriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeleToolStripMenuItem1,
            this.talepFormuToolStripMenuItem});
            this.müşteriToolStripMenuItem.Name = "müşteriToolStripMenuItem";
            this.müşteriToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.müşteriToolStripMenuItem.Text = "Müşteri";
            // 
            // listeleToolStripMenuItem1
            // 
            this.listeleToolStripMenuItem1.Name = "listeleToolStripMenuItem1";
            this.listeleToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.listeleToolStripMenuItem1.Text = "Listele";
            this.listeleToolStripMenuItem1.Click += new System.EventHandler(this.listeleToolStripMenuItem1_Click);
            // 
            // talepFormuToolStripMenuItem
            // 
            this.talepFormuToolStripMenuItem.Name = "talepFormuToolStripMenuItem";
            this.talepFormuToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.talepFormuToolStripMenuItem.Text = "Talep Formu";
            this.talepFormuToolStripMenuItem.Click += new System.EventHandler(this.talepFormuToolStripMenuItem_Click);
            // 
            // işToolStripMenuItem
            // 
            this.işToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oluşturToolStripMenuItem,
            this.listeleToolStripMenuItem2});
            this.işToolStripMenuItem.Name = "işToolStripMenuItem";
            this.işToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.işToolStripMenuItem.Text = "Görev";
            // 
            // oluşturToolStripMenuItem
            // 
            this.oluşturToolStripMenuItem.Name = "oluşturToolStripMenuItem";
            this.oluşturToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.oluşturToolStripMenuItem.Text = "Oluştur";
            this.oluşturToolStripMenuItem.Click += new System.EventHandler(this.oluşturToolStripMenuItem_Click);
            // 
            // listeleToolStripMenuItem2
            // 
            this.listeleToolStripMenuItem2.Name = "listeleToolStripMenuItem2";
            this.listeleToolStripMenuItem2.Size = new System.Drawing.Size(113, 22);
            this.listeleToolStripMenuItem2.Text = "Listele";
            this.listeleToolStripMenuItem2.Click += new System.EventHandler(this.listeleToolStripMenuItem2_Click);
            // 
            // TeamLeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 499);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TeamLeader";
            this.Text = "TeamLeader";
            this.Load += new System.EventHandler(this.TeamLeader_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşteriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem işToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oluşturToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem talepFormuToolStripMenuItem;
    }
}