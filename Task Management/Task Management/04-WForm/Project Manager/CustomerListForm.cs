using _03_BusinessLayer;
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

namespace WForm.Project_Manager
{
    public partial class CustomerListForm : Form
    {
        CustomerBLL _customerBLL;
        _01_Entities.Customer _customer;
        
        public CustomerListForm()
        {
            InitializeComponent();
            _customerBLL = new CustomerBLL();
            _customer = new _01_Entities.Customer();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            GetCustomer();
        }

        private void GetCustomer()
        {
            dgvCustomer.DataSource = _customerBLL.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=(int)dgvCustomer.SelectedRows[0].Cells[0].Value;
            _customer = new _01_Entities.Customer();
            _customer = _customerBLL.Get(id);
            _customer.CompanyName = txtCompanyName.Text;
            _customer.ContactName = txtContactName.Text;
            _customer.Address = txtAddress.Text;
            _customer.Email = txtMail.Text;
            _customer.LogoURL = txtLogoURL.Text;
            _customer.GSM = txtGSM.Text;
           bool control= _customerBLL.Update(_customer);
           if (control)
           {

               MessageBox.Show("Güncelleme Başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
           }
           else
               MessageBox.Show("İşlem başarısız oldu", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            GetCustomer();
            CustomerClear();
        }

        private void CustomerClear()
        {
            txtCompanyName.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtGSM.Text = string.Empty;
            txtLogoURL.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtCompanyName.Focus();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                 int id = (int)dgvCustomer.SelectedRows[0].Cells[0].Value;
            _customer = _customerBLL.Get(id);
            txtCompanyName.Text = _customer.CompanyName;
            txtContactName.Text = _customer.ContactName;
            txtAddress.Text = _customer.Address;
            txtMail.Text = _customer.Email;
            txtLogoURL.Text = _customer.LogoURL;
            txtGSM.Text = _customer.GSM;
            }
            catch (Exception)
            {

            }
            
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvCustomer.SelectedRows[0].Cells[0].Value;
                _customer = _customerBLL.Get(id);
                _customer.isPassive = true;
                _customerBLL.Update(_customer);
                GetCustomer();
            }
            catch (Exception)
            {
                
               
            }
        }
    }
}
