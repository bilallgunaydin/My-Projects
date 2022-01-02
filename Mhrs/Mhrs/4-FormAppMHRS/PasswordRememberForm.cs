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
   
    public partial class PasswordRememberForm : Form
    {
        PoorlBLL _poorlyBLL;
        Poorly poorly;
        public PasswordRememberForm()
        {
            InitializeComponent();
            _poorlyBLL = new PoorlBLL();
        }

        bool isTrue = true;
        private void btnSend_Click(object sender, EventArgs e)
        {
            poorly = new Poorly();
            Poorly outPoorly = new Poorly();
            poorly.Personel.TCNumber = txtBxTcNumber.Text;
            poorly.Contact.Email = txtBxMail.Text;
            if(_poorlyBLL.MailControl(poorly,out outPoorly)){
                if (outPoorly.Safety.Password!=null)
                {
                    mail.SentMail(poorly, "Şifre hatırlatma", "Sn. " + outPoorly.Personel.FullName + "\n\nGiriş Bilgileriniz:\n\nT.C Kimlik Numaranız: "+outPoorly.Personel.TCNumber.Substring(0,3)+"*****"+outPoorly.Personel.TCNumber.Substring(8,3)+"\nŞifreniz : "+outPoorly.Safety.Password);
                    MessageBox.Show("mail gönderildi"); 
                }
            }
            else
            {
                MessageBox.Show("Mail adresiniz veya tc kimlik numara kaydınız yoktur.");
            }
        }
    }
}
