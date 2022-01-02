using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLayer;
using System.Windows.Forms;

namespace FormAppMHRS
{
    public partial class LoginForm : Form
    {
        PoorlBLL _poorlBLL;
        string securtyCode = "";
        public LoginForm()
        {
            InitializeComponent();
            _poorlBLL = new PoorlBLL();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SecurityCode();
            txtTCNumber.Text= "12457898652";
            txtPassword.Text= "Hb124578";
        }

        private void SecurityCode()
        {
            Random rnd = new Random();
            securtyCode = rnd.Next(10000, 100000).ToString();
           txtSecurityCode.Text= lblSecurityCode.Text = securtyCode;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            SecurityCode();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text!="" && txtSecurityCode.Text!="" && txtTCNumber.Text!="")
            {
                if (securtyCode == txtSecurityCode.Text)
                {
                    SecurityCode();
                    Poorly poorly = new Poorly();
                    poorly.Personel.TCNumber = txtTCNumber.Text;
                    poorly.Safety.Password = txtPassword.Text;
                    txtPassword.Text = "";
                    txtSecurityCode.Text = "";
                    int patientID;
                    if (_poorlBLL.Get(poorly, out patientID))
                    {
                        poorly = _poorlBLL.Get(patientID);
                        MHRSForm form = new MHRSForm();
                        form._poorly = poorly;
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("TC kimlik numaran veya Şifren hatalı");
                    }
                }
                else
                {
                    MessageBox.Show("Güvenlik kodu hatalı");
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakamazsınız");
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            SingInForm singInForm = new SingInForm();
            singInForm.Show();
            
        }

        private void UpdatePassword_Click(object sender, EventArgs e)
        {
            PasswordRememberForm password = new PasswordRememberForm();
            password.Show();
            this.Hide();
        }

        private void txtTCNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
