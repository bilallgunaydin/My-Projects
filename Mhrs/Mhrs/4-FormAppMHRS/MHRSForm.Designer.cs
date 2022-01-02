namespace FormAppMHRS
{
    partial class MHRSForm
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
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbCounty = new System.Windows.Forms.ComboBox();
            this.cmbClinic = new System.Windows.Forms.ComboBox();
            this.cmbHospital = new System.Windows.Forms.ComboBox();
            this.cmbExamination = new System.Windows.Forms.ComboBox();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpReserveDate = new System.Windows.Forms.DateTimePicker();
            this.lviewDoctor = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlRecerseTime = new System.Windows.Forms.Panel();
            this.lblPorrly = new System.Windows.Forms.Label();
            this.lblSystemDate = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblReserveDate = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCounty = new System.Windows.Forms.Label();
            this.lblClinic = new System.Windows.Forms.Label();
            this.lblHospital = new System.Windows.Forms.Label();
            this.lblExamination = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(465, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "HASTANE RANDEVU ARAMA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCity
            // 
            this.cmbCity.BackColor = System.Drawing.Color.White;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(130, 87);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(187, 21);
            this.cmbCity.TabIndex = 1;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedValueChanged);
            // 
            // cmbCounty
            // 
            this.cmbCounty.BackColor = System.Drawing.Color.White;
            this.cmbCounty.FormattingEnabled = true;
            this.cmbCounty.Location = new System.Drawing.Point(130, 114);
            this.cmbCounty.Name = "cmbCounty";
            this.cmbCounty.Size = new System.Drawing.Size(187, 21);
            this.cmbCounty.TabIndex = 1;
            this.cmbCounty.SelectedIndexChanged += new System.EventHandler(this.cmbCounty_SelectedIndexChanged);
            // 
            // cmbClinic
            // 
            this.cmbClinic.BackColor = System.Drawing.Color.White;
            this.cmbClinic.FormattingEnabled = true;
            this.cmbClinic.Location = new System.Drawing.Point(130, 141);
            this.cmbClinic.Name = "cmbClinic";
            this.cmbClinic.Size = new System.Drawing.Size(187, 21);
            this.cmbClinic.TabIndex = 1;
            // 
            // cmbHospital
            // 
            this.cmbHospital.BackColor = System.Drawing.Color.White;
            this.cmbHospital.FormattingEnabled = true;
            this.cmbHospital.Location = new System.Drawing.Point(130, 168);
            this.cmbHospital.Name = "cmbHospital";
            this.cmbHospital.Size = new System.Drawing.Size(187, 21);
            this.cmbHospital.TabIndex = 1;
            this.cmbHospital.SelectedIndexChanged += new System.EventHandler(this.cmbHospital_SelectedIndexChanged);
            // 
            // cmbExamination
            // 
            this.cmbExamination.BackColor = System.Drawing.Color.White;
            this.cmbExamination.FormattingEnabled = true;
            this.cmbExamination.Location = new System.Drawing.Point(130, 195);
            this.cmbExamination.Name = "cmbExamination";
            this.cmbExamination.Size = new System.Drawing.Size(187, 21);
            this.cmbExamination.TabIndex = 2;
            this.cmbExamination.SelectedIndexChanged += new System.EventHandler(this.cmbExamination_SelectedIndexChanged);
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.BackColor = System.Drawing.Color.White;
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(130, 222);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(187, 21);
            this.cmbDoctor.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(130, 266);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 31);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(228, 266);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 31);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Randevu Ara";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpReserveDate
            // 
            this.dtpReserveDate.Location = new System.Drawing.Point(130, 61);
            this.dtpReserveDate.Name = "dtpReserveDate";
            this.dtpReserveDate.Size = new System.Drawing.Size(187, 20);
            this.dtpReserveDate.TabIndex = 7;
            this.dtpReserveDate.ValueChanged += new System.EventHandler(this.dtpReserveDate_ValueChanged);
            // 
            // lviewDoctor
            // 
            this.lviewDoctor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lviewDoctor.Location = new System.Drawing.Point(130, 364);
            this.lviewDoctor.Name = "lviewDoctor";
            this.lviewDoctor.Size = new System.Drawing.Size(920, 154);
            this.lviewDoctor.TabIndex = 8;
            this.lviewDoctor.UseCompatibleStateImageBehavior = false;
            this.lviewDoctor.View = System.Windows.Forms.View.Details;
            this.lviewDoctor.SelectedIndexChanged += new System.EventHandler(this.lviewDoctor_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Hekim";
            this.columnHeader1.Width = 117;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "En Erken Tarih";
            this.columnHeader2.Width = 147;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kurum Adı";
            this.columnHeader3.Width = 129;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Klinik Adı";
            this.columnHeader4.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Muayene Yeri";
            this.columnHeader5.Width = 97;
            // 
            // pnlRecerseTime
            // 
            this.pnlRecerseTime.Location = new System.Drawing.Point(347, 61);
            this.pnlRecerseTime.Name = "pnlRecerseTime";
            this.pnlRecerseTime.Size = new System.Drawing.Size(703, 285);
            this.pnlRecerseTime.TabIndex = 9;
            // 
            // lblPorrly
            // 
            this.lblPorrly.AutoSize = true;
            this.lblPorrly.ForeColor = System.Drawing.Color.LightYellow;
            this.lblPorrly.Location = new System.Drawing.Point(11, 13);
            this.lblPorrly.Name = "lblPorrly";
            this.lblPorrly.Size = new System.Drawing.Size(0, 13);
            this.lblPorrly.TabIndex = 10;
            // 
            // lblSystemDate
            // 
            this.lblSystemDate.AutoSize = true;
            this.lblSystemDate.Location = new System.Drawing.Point(127, 24);
            this.lblSystemDate.Name = "lblSystemDate";
            this.lblSystemDate.Size = new System.Drawing.Size(0, 13);
            this.lblSystemDate.TabIndex = 10;
            this.lblSystemDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(186, 313);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 33);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblReserveDate
            // 
            this.lblReserveDate.AutoSize = true;
            this.lblReserveDate.ForeColor = System.Drawing.Color.LightYellow;
            this.lblReserveDate.Location = new System.Drawing.Point(29, 67);
            this.lblReserveDate.Name = "lblReserveDate";
            this.lblReserveDate.Size = new System.Drawing.Size(83, 13);
            this.lblReserveDate.TabIndex = 12;
            this.lblReserveDate.Text = "Randevu Tarihi:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.ForeColor = System.Drawing.Color.LightYellow;
            this.lblCity.Location = new System.Drawing.Point(29, 95);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(52, 13);
            this.lblCity.TabIndex = 13;
            this.lblCity.Text = "Şehir Adı:";
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.ForeColor = System.Drawing.Color.LightYellow;
            this.lblCounty.Location = new System.Drawing.Point(29, 122);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(45, 13);
            this.lblCounty.TabIndex = 14;
            this.lblCounty.Text = "İlçe Adı:";
            // 
            // lblClinic
            // 
            this.lblClinic.AutoSize = true;
            this.lblClinic.ForeColor = System.Drawing.Color.LightYellow;
            this.lblClinic.Location = new System.Drawing.Point(29, 149);
            this.lblClinic.Name = "lblClinic";
            this.lblClinic.Size = new System.Drawing.Size(53, 13);
            this.lblClinic.TabIndex = 15;
            this.lblClinic.Text = "Klinik Adı:";
            // 
            // lblHospital
            // 
            this.lblHospital.AutoSize = true;
            this.lblHospital.ForeColor = System.Drawing.Color.LightYellow;
            this.lblHospital.Location = new System.Drawing.Point(29, 176);
            this.lblHospital.Name = "lblHospital";
            this.lblHospital.Size = new System.Drawing.Size(68, 13);
            this.lblHospital.TabIndex = 16;
            this.lblHospital.Text = "Hastane Adı:";
            // 
            // lblExamination
            // 
            this.lblExamination.AutoSize = true;
            this.lblExamination.ForeColor = System.Drawing.Color.LightYellow;
            this.lblExamination.Location = new System.Drawing.Point(29, 203);
            this.lblExamination.Name = "lblExamination";
            this.lblExamination.Size = new System.Drawing.Size(78, 13);
            this.lblExamination.TabIndex = 17;
            this.lblExamination.Text = "Muayene Yeri: ";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.ForeColor = System.Drawing.Color.LightYellow;
            this.lblDoctor.Location = new System.Drawing.Point(29, 230);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(60, 13);
            this.lblDoctor.TabIndex = 18;
            this.lblDoctor.Text = "Doktor Adı:";
            // 
            // MHRSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(1141, 548);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblExamination);
            this.Controls.Add(this.lblHospital);
            this.Controls.Add(this.lblClinic);
            this.Controls.Add(this.lblCounty);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblReserveDate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblSystemDate);
            this.Controls.Add(this.lblPorrly);
            this.Controls.Add(this.pnlRecerseTime);
            this.Controls.Add(this.lviewDoctor);
            this.Controls.Add(this.dtpReserveDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.cmbExamination);
            this.Controls.Add(this.cmbHospital);
            this.Controls.Add(this.cmbClinic);
            this.Controls.Add(this.cmbCounty);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.label1);
            this.Name = "MHRSForm";
            this.Text = "MHRSForm";
            this.Load += new System.EventHandler(this.MHRSForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbCounty;
        private System.Windows.Forms.ComboBox cmbClinic;
        private System.Windows.Forms.ComboBox cmbHospital;
        private System.Windows.Forms.ComboBox cmbExamination;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpReserveDate;
        private System.Windows.Forms.ListView lviewDoctor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel pnlRecerseTime;
        private System.Windows.Forms.Label lblPorrly;
        private System.Windows.Forms.Label lblSystemDate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblReserveDate;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.Label lblClinic;
        private System.Windows.Forms.Label lblHospital;
        private System.Windows.Forms.Label lblExamination;
        private System.Windows.Forms.Label lblDoctor;
    }
}