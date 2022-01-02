namespace WForm.Tester
{
    partial class Tester
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
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.btnSuccesfull = new System.Windows.Forms.Button();
            this.btnTestError = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTest
            // 
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Location = new System.Drawing.Point(12, 12);
            this.dgvTest.MultiSelect = false;
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTest.Size = new System.Drawing.Size(579, 415);
            this.dgvTest.TabIndex = 0;
            // 
            // btnSuccesfull
            // 
            this.btnSuccesfull.Location = new System.Drawing.Point(403, 433);
            this.btnSuccesfull.Name = "btnSuccesfull";
            this.btnSuccesfull.Size = new System.Drawing.Size(91, 35);
            this.btnSuccesfull.TabIndex = 1;
            this.btnSuccesfull.Text = "Test Başarılı";
            this.btnSuccesfull.UseVisualStyleBackColor = true;
            this.btnSuccesfull.Click += new System.EventHandler(this.btnSuccesfull_Click);
            // 
            // btnTestError
            // 
            this.btnTestError.Location = new System.Drawing.Point(500, 433);
            this.btnTestError.Name = "btnTestError";
            this.btnTestError.Size = new System.Drawing.Size(91, 35);
            this.btnTestError.TabIndex = 2;
            this.btnTestError.Text = "Test Başarısız";
            this.btnTestError.UseVisualStyleBackColor = true;
            this.btnTestError.Click += new System.EventHandler(this.btnTestError_Click);
            // 
            // Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 480);
            this.Controls.Add(this.btnTestError);
            this.Controls.Add(this.btnSuccesfull);
            this.Controls.Add(this.dgvTest);
            this.Name = "Tester";
            this.Text = "Tester";
            this.Load += new System.EventHandler(this.Tester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.Button btnSuccesfull;
        private System.Windows.Forms.Button btnTestError;
    }
}