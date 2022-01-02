using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessLayer;


namespace FormAppMHRS
{
    public partial class SingInForm : Form
    {

        GenderBLL _genderBLL;
        SecurityQuestionBLL _securityBLL;
        PoorlBLL _poorlyBLL;
        Poorly poorly;
   
        public SingInForm()
        {
            InitializeComponent();
            _genderBLL = new GenderBLL();
            _poorlyBLL = new PoorlBLL();
            _securityBLL = new SecurityQuestionBLL();
        }
       

        private void SginInForm_Load(object sender, EventArgs e)
        {
            cmbSecurityQuestion.DataSource = _securityBLL.GetAll();
            cmbSecurityQuestion.DisplayMember = "Question";
            cmbSecurityQuestion.ValueMember = "ID";
           cmbSecurityQuestion.SelectedIndex = -1;
            cmbGender.DataSource = _genderBLL.GetAll();
            cmbGender.DisplayMember = "GenderName";
            cmbGender.ValueMember = "GenderID";
            cmbGender.SelectedIndex = -1;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            poorly = new Poorly();
            poorly.Personel.TCNumber=txtBxTcNumber.Text;
            poorly.Personel.FirstName = txtBxFirstName.Text;
            poorly.Personel.LastName = txtBxLastName.Text;
            poorly.Personel.Gender.GenderID = (int)cmbGender.SelectedValue;
            poorly.Personel.BirthDate = dtpBirthOfDate.Value;
            poorly.Personel.BirthPlace = txtBxBirthPlace.Text;
            poorly.Personel.FatherName = txtBxFatherName.Text;
            poorly.Personel.MotherName = txtBxLastName.Text;
            poorly.Contact.MobilePhone = mskBxMobilePhone.Text;
            poorly.Contact.LandPhone = mskBxLandPhone.Text;
            poorly.Contact.Email = txtBxMail.Text;
            poorly.Safety.Password = txtBxPassword.Text;
            poorly.Safety.SecurityQuestion.ID = (int)cmbSecurityQuestion.SelectedValue;
            poorly.Safety.Answer = txtBxAnswer.Text;
            if (txtBxMail.Text == txtBxMailAgain.Text && txtBxPassword.Text == txtBxPasswordAgain.Text)
            {
                _poorlyBLL.Insert(poorly);
                mail.SentMail(poorly, "Hoş Geldiniz", "Sn. " + poorly.Personel.FullName + " Kaydınız başarıyla yapılmıştır");
                this.Close();

            }
            else
            {
                MessageBox.Show("Girdiğiniz şifreler veya mail adresleri birbirleriyle aynı değil, lütfen aynı şifreyi ve aynı mail adresini yanlarındaki alanlara yazınız.");
            }

        }

     
    }
}
