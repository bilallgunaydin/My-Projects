namespace WForm.Software_Developer
{
    partial class SoftwareDeveloper
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
            this.dgvSoftware = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCompleted = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftware)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSoftware
            // 
            this.dgvSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoftware.Location = new System.Drawing.Point(12, 12);
            this.dgvSoftware.MultiSelect = false;
            this.dgvSoftware.Name = "dgvSoftware";
            this.dgvSoftware.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoftware.Size = new System.Drawing.Size(511, 477);
            this.dgvSoftware.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(320, 495);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(97, 39);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Yapıma başla..";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCompleted
            // 
            this.btnCompleted.Location = new System.Drawing.Point(423, 495);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(100, 39);
            this.btnCompleted.TabIndex = 2;
            this.btnCompleted.Text = "Tamamlandı";
            this.btnCompleted.UseVisualStyleBackColor = true;
            this.btnCompleted.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // SoftwareDeveloper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 544);
            this.Controls.Add(this.btnCompleted);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvSoftware);
            this.Name = "SoftwareDeveloper";
            this.Text = "SoftwareDeveloper";
            this.Load += new System.EventHandler(this.SoftwareDeveloper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftware)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSoftware;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCompleted;
    }
}