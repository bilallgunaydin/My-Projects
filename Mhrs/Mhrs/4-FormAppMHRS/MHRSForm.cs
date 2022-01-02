using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessLayer;

namespace FormAppMHRS
{
    public partial class MHRSForm : Form
    {
        CityBLL _cityBLL;
        CountyBLL _countyBLL;
        ClinicBLL _clinicBLL;
        PoorlBLL _poorlyBLL;
        HospitalBLL _hospitalBLL;
        ExaminationPlaceBLL _examinationPlaceBLL;
        DoctorBLL _doctorBLL;
        AppointmentBLL _appointmentBLL;
        internal Poorly _poorly = new Poorly();

        public MHRSForm()
        {
            InitializeComponent();
            _cityBLL = new CityBLL();
            _countyBLL = new CountyBLL();
            _clinicBLL = new ClinicBLL();
            _poorlyBLL = new PoorlBLL();
            _hospitalBLL = new HospitalBLL();
            _doctorBLL = new DoctorBLL();
            _examinationPlaceBLL = new ExaminationPlaceBLL();
            _appointmentBLL=new AppointmentBLL();
        }

        private void MHRSForm_Load(object sender, EventArgs e)
        {
           
            DateTime date = DateTime.Now;
            DateTime dateAddDay = new DateTime();
            DateTime dateNow = new DateTime();
            if (date.DayOfWeek == DayOfWeek.Friday)
            {
                dateNow = date;
                dateAddDay = date.AddDays(4);
            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                dateNow = date.AddDays(2);
                dateAddDay = date.AddDays(2);
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                dateNow = date.AddDays(1);
                dateAddDay = date.AddDays(2);
            }
            else if (date.DayOfWeek == DayOfWeek.Thursday)
            {
                dateNow = date;
                dateAddDay = date.AddDays(4);
            }
            else
            {
                dateAddDay = date.AddDays(2);
            }
            dtpReserveDate.MinDate = dateNow;
            dtpReserveDate.MaxDate = dateAddDay;

            lblPorrly.Text = "Sn. " + _poorly.Personel.FullName;
            lblSystemDate.Text = DateTime.Now.ToString();

            cmbCity.DataSource = _cityBLL.GetAll();
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "ID";
            cmbCity.SelectedIndex = -1;
            Clear();
        }

        private void cmbCity_SelectedValueChanged(object sender, EventArgs e)
        {
            County county = new County();
            if (cmbCity.SelectedItem != null)
            {
                county.CityID = (City)cmbCity.SelectedItem;
                cmbCounty.DataSource = _countyBLL.GetAll(county);
                cmbCounty.ValueMember = "ID";
                cmbCounty.DisplayMember = "CountyName";
                cmbCounty.SelectedIndex = -1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            HospitalClinicExaminationPlace clinic = new HospitalClinicExaminationPlace();
            if (cmbCounty.SelectedItem != null)
            {

                clinic.HospitalID.County = ((County)cmbCounty.SelectedItem);
                cmbClinic.DataSource = _clinicBLL.GetAll(clinic);
                cmbClinic.DisplayMember = "Name";
                cmbClinic.ValueMember = "ID";
                cmbClinic.SelectedIndex = -1;
                cmbHospital.DataSource = _hospitalBLL.GetAll(clinic);
                cmbHospital.DisplayMember = "Name";
                cmbHospital.ValueMember = "ID";
                cmbHospital.SelectedIndex = -1;
            }
        }

        private void dtpReserveDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReserveDate.Value.DayOfWeek == DayOfWeek.Saturday || dtpReserveDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Hafta sonuna seçim yapamazsınız");
                dtpReserveDate.Value = DateTime.Now;
            }
        }

       
        private void lviewDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lviewDoctor.SelectedItems.Count == 1)
            {
                pnlRecerseTime.Controls.Clear();
                Doctor doctor = (Doctor)lviewDoctor.SelectedItems[0].Tag;
                TabControl tab = new TabControl();
                tab.Name = "tabReserveTime";
                tab.Size = pnlRecerseTime.Size;
                tab.Location = new Point(0, 0);
                pnlRecerseTime.Controls.Add(tab);
                DateTime date = DateTime.Now;
                for (int index = 0; index < 3; index++)
                {
                    
                
                    TabPage page = new TabPage();
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        page.Name = "pageReserve" + index;
                        page.Text = date.ToShortDateString();
                        page.Size = new Size(200, 20);
                        tab.TabPages.Add(page);
                        date=date.AddDays(1);
                       
                    }
                }

                foreach (TabPage tabPage in tab.TabPages)
                {
                   
                    int x = 10;
                    int y = 10;
                    for (DateTime i = doctor.HospitalClinicExaminationPlaceID.StartTime;
                        i < doctor.HospitalClinicExaminationPlaceID.EndTime; 
                        i=i.AddMinutes(doctor.HospitalClinicExaminationPlaceID.ClinicID.ExaminationPeriod))
                    {
                        if (i.Minute % 60 == 0 && x !=10)
                        {
                            y += 25;
                            x = 10;
                        }
                        if (i.Hour!=12)
                        {

                            Button btn = new Button();
                            btn.Name = tabPage.Name + i.ToShortTimeString();
                            btn.Text = i.ToShortTimeString();
                            btn.Location = new Point(x, y);
                            btn.Size = new Size(70, 20);
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderSize = 0;
                            btn.BackColor = Color.Green;
                            btn.ForeColor = Color.White;
                            tabPage.Controls.Add(btn);
                            btn.Click += Btn_Click;
                        }
                        x += 75;
                    }
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Doctor doctor = (Doctor)lviewDoctor.SelectedItems[0].Tag;
            string date = ((Button)sender).Text;
            Appointment appointment =new Appointment();
            appointment.Doctor.DoctorID = doctor.DoctorID;
            appointment.Poorly.Personel.PatientID = _poorly.Personel.PatientID;
            appointment.DateOfAppointment = dtpReserveDate.Value;
            appointment.Status = true;
            if (doctor.DoctorID > 0 && _poorly.Personel.PatientID > 0 && dtpReserveDate.Value != null &&
                date.Length > 0 && appointment.Status == true)
            {
                Poorly outPoorly = new Poorly();
                bool success = _appointmentBLL.Insert(appointment);
                if (success == true)
                {

                    if (_poorlyBLL.MailControl(_poorly, out outPoorly))
                    {
                        if (outPoorly.Safety.Password != null)
                        {
                            mail.SentMail(_poorly, "Randevu Bilgisi",
                                "Sn. " + _poorly.Personel.FullName + "\n \n Randevu Bilgileriniz:\n\n Şehir: " +
                                cmbCity.Text + "\n İlçe: " + cmbCounty.Text + "\n Klinik Adı: " +
                                cmbClinic.Text + "\n" + "Hastane Adı: " + cmbHospital.Text + "\n" +
                                "Muayene Yeri: " + cmbExamination.Text + "\n" + "Doktor Adı: " +
                                cmbDoctor.Text + "\n" + "Randevu Tarihi:    " +
                                dtpReserveDate.Value.ToShortDateString() + "\n" + "Randevu Saati: " + date);
                            MessageBox.Show(
                                "Randevunuz alınmıştır. Randevu bilgileriniz mail adresinize gönderilmiştir.");
                            Button btn = ((Button)sender);
                            btn.BackColor = Color.Gray;
                            btn.Enabled = false;
                        }

                    }
                }
            }
            
        }

        private void cmbClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hospital hospital = new Hospital();
            Clinic clinic = new Clinic();
            if (cmbClinic.SelectedItem!=null &&cmbHospital.SelectedItem!=null)
            {
                clinic = ((Clinic)cmbClinic.SelectedItem);
                hospital.City = ((City)cmbCity.SelectedItem);
                hospital.County = ((County)cmbCounty.SelectedItem);
                cmbHospital.DataSource = _hospitalBLL.GetAll(hospital, clinic);
                cmbHospital.DisplayMember = "Name";
                cmbHospital.ValueMember = "ID";
                cmbHospital.SelectedIndex = -1;
            }
        }

        private void cmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hospital hospital = new Hospital();
            Clinic clinic = new Clinic();
            if (cmbHospital.SelectedItem!=null && cmbClinic.SelectedItem!=null)
            {
                hospital = (Hospital)cmbHospital.SelectedItem;
                clinic = (Clinic)cmbClinic.SelectedItem;
                cmbExamination.DataSource = _examinationPlaceBLL.GetAll(hospital,clinic);
                cmbExamination.DisplayMember = "Name";
                cmbExamination.ValueMember = "ID";
                cmbExamination.SelectedIndex = -1;
                cmbDoctor.DataSource = _doctorBLL.GetAll(hospital, clinic);
                cmbDoctor.DisplayMember = "FullName";
                cmbDoctor.ValueMember = "DoctorID";
                cmbDoctor.SelectedIndex = -1;
            }
        }

        private void cmbExamination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExamination.SelectedItem!=null)
            {
                ExaminationPlace examinationPlace = new ExaminationPlace();
                examinationPlace = (ExaminationPlace)cmbExamination.SelectedItem;
                cmbDoctor.DataSource = _doctorBLL.GetAll(examinationPlace);
                cmbDoctor.DisplayMember = "FullName";
                cmbDoctor.ValueMember = "DoctorID";
                cmbDoctor.SelectedIndex = -1;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbClinic.SelectedItem !=null && cmbHospital.SelectedItem!=null)
            {
                lviewDoctor.Items.Clear();
                Hospital hospital = new Hospital();
                Clinic clinic = new Clinic();
                hospital = (Hospital)cmbHospital.SelectedItem;
                clinic = (Clinic)cmbClinic.SelectedItem;
                List<Doctor> listDoctor = new List<Doctor>();
                listDoctor = _doctorBLL.GetAll(hospital,clinic);
                foreach (Doctor doctor in listDoctor)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = doctor;
                    item.Text = doctor.FullName;
                    item.SubItems.Add(DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday ? DateTime.Now.ToShortDateString() : DateTime.Now.AddDays(1).ToShortDateString());
                    item.SubItems.Add(doctor.HospitalClinicExaminationPlaceID.HospitalID.Name);
                    item.SubItems.Add(doctor.HospitalClinicExaminationPlaceID.ClinicID.Name);
                    item.SubItems.Add(doctor.HospitalClinicExaminationPlaceID.ExaminationPlaceID.Name);
                    lviewDoctor.Items.Add(item);
                }
            }
        }

        public void Clear()
        {
            if(DateTime.Now.DayOfWeek!=DayOfWeek.Saturday && DateTime.Now.DayOfWeek!=DayOfWeek.Sunday)
            dtpReserveDate.Value=DateTime.Now;
            cmbCity.SelectedIndex = -1;
            cmbCounty.SelectedIndex = -1;
            cmbCounty.DataSource = null;
            cmbClinic.SelectedIndex = -1;
            cmbClinic.DataSource = null;
            cmbHospital.SelectedIndex = -1;
            cmbHospital.DataSource = null;
            cmbExamination.SelectedIndex = -1;
            cmbExamination.DataSource = null;
            cmbDoctor.SelectedIndex = -1;
            cmbDoctor.DataSource = null;
            lviewDoctor.Items.Clear();
            pnlRecerseTime.Controls.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}