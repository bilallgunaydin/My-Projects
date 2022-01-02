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

namespace WForm.Project_Manager
{
    public partial class EmployeeAddForm : Form
    {
        EmployeeBLL empBLL;
        Employees emp;
        AccountTypeBLL _accountTypeBLL;
        public EmployeeAddForm()
        {
            InitializeComponent();
            empBLL = new EmployeeBLL();
            emp = new Employees();
            _accountTypeBLL = new AccountTypeBLL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                emp.FirstName = txtFirstName.Text;
                emp.LastName = txtLastName.Text;
                emp.GSM = txtGSM.Text;
                emp.Email = txtMail.Text;
                emp.Password = txtPassword.Text;
                emp.ImageURL = txtImage.Text;
                emp.AccountTypeID = (int)cmbPosition.SelectedValue;
                bool control = empBLL.Add(emp);
                if (control)
                {
                    MessageBox.Show("Başarılı Şekilde Çalışan Eklendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Clear();
                }
                else
                    MessageBox.Show("Ekleme İşlemi Başarısız.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ekleme İşlemi Başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtImage.Text = string.Empty;
            txtMail.Text = string.Empty;
            cmbPosition.SelectedIndex = -1;
            txtImage.Text = string.Empty;
            txtGSM.Text = string.Empty;
        }

        private void EmployeeAddForm_Load(object sender, EventArgs e)
        {
            cmbPosition.DataSource = _accountTypeBLL.GetAll();
            cmbPosition.ValueMember = "AccountTypeID";
            cmbPosition.DisplayMember = "Name";
        }
    }
}
