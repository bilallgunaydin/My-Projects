using _01_Entities;
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

namespace WForm.Team_Leader
{
    public partial class CustomerRequestForm : Form
    {
        CustomerBLL _customerBLL;
        ProjectBLL _projectBLL;
        CustomerRequestBLL _customerRequest;
        CustomerRequest customerRequest;
        public CustomerRequestForm()
        {
            InitializeComponent();
            _customerBLL = new CustomerBLL();
            _projectBLL = new ProjectBLL();
            _customerRequest = new CustomerRequestBLL();
            customerRequest = new CustomerRequest();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                customerRequest.ProjectID = (int)cmbProject.SelectedValue;
                if (cmbType.SelectedIndex == 0)
                    customerRequest.RequestType = false;
                else if (cmbType.SelectedIndex == 1)
                    customerRequest.RequestType = true;
               
                customerRequest.RequestDate = DateTime.Now;
                customerRequest.Description = txtDesc.Text;
                bool control = _customerRequest.Add(customerRequest);
                if (control && cmbType.SelectedIndex != -1)
                {
                    MessageBox.Show("İşlem Gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                    MessageBox.Show("İstek Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("İstek Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
                
        }

        private void Clear()
        {
            txtDesc.Text = string.Empty;
            cmbCustomer.SelectedIndex = -1;
            cmbProject.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
        }

        private void CustomerRequestForm_Load(object sender, EventArgs e)
        {
            cmbCustomer.DataSource = _customerBLL.GetAll();
            cmbCustomer.DisplayMember = "ContactName";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedIndex = -1;

            
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbProject.DataSource = _projectBLL.GetAll().Where(x => x.CustomerID == (int)cmbCustomer.SelectedValue).ToList();
                cmbProject.DisplayMember = "Name";
                cmbProject.ValueMember = "ProjectID";
                
            }
            catch (Exception)
            {

            }

        }
    }
}
