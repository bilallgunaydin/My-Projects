using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01_Entities;
using _03_BusinessLayer;

namespace WForm.Customer
{
    public partial class CustomerAddForm : Form
    {
        public CustomerAddForm()
        {
            InitializeComponent();
            _customer = new _01_Entities.Customer();
            _customerBLL = new CustomerBLL();
        }
        _01_Entities.Customer _customer;
        CustomerBLL _customerBLL;

        private void btsnSave_Click(object sender, EventArgs e)
        {
            
            _customer.CompanyName = txtCompanyName.Text;
            _customer.ContactName = txtContactName.Text;
            _customer.Address = txtAddress.Text;
            _customer.Email = txtMail.Text;
            _customer.LogoURL = txtLogoURL.Text;
            _customer.GSM = txtGSM.Text;

           bool control=_customerBLL.Add(_customer);
           if (control == true)
           {
               
               MessageBox.Show("Müşteri kaydınız yapıldı","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
               Clear();
           }
           else
               MessageBox.Show("İşlem başarısız oldu", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Clear()
        {
            txtCompanyName.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtLogoURL.Text = string.Empty;
            txtGSM.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
