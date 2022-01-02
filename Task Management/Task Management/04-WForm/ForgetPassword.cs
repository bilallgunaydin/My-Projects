using _01_Entities;
using _03_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForm
{
    public partial class ForgetPassword : Form
    {
        EmployeeBLL _employeeBLL;
        public ForgetPassword()
        {
            InitializeComponent();
            _employeeBLL = new EmployeeBLL();

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            
                bool control = _employeeBLL.GetPassword(txtEmail.Text);
                if (control)
                {
                    MessageBox.Show("Şifreniz başarılı bir şekilde mail adresinize gönderilmiştir.", "Mail Gönderme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
               
                else
                MessageBox.Show("Email Sistemde kayıtlı değil. Lütfen mail adresinizi kontrol edip tekrar deneyiniz. ");
            
            
        }
    }
}
