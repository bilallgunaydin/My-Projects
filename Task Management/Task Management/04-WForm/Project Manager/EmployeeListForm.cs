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

namespace WForm.Employee
{
    public partial class EmployeeListForm : Form
    {
        EmployeeBLL _employeeBLL;
        Employees _employee;
        AccountTypeBLL _accountBLL;
        public EmployeeListForm()
        {
            InitializeComponent();
            _employeeBLL = new EmployeeBLL();
            _employee = new Employees();
            _accountBLL = new AccountTypeBLL();
        }
        static int id;
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                id = (int)dgvEmployeeList.SelectedRows[0].Cells[0].Value;
                _employee = _employeeBLL.Get(id);
                txtFirstName.Text = _employee.FirstName;
                txtLastName.Text = _employee.LastName;
                txtMail.Text = _employee.Email;
                txtPassword.Text = _employee.Password;
                txtGSM.Text = _employee.GSM;
                cmbPosition.SelectedValue = _employee.AccountTypeID;
            }
            catch
            {

            }

        }

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            GetList();
            GetEmployees();
        }
        private void GetList()
        {
            dgvEmployeeList.DataSource = _employeeBLL.GetAllSelect();
        }



        private void GetEmployees()
        {

            cmbSearchPosition.DataSource = _accountBLL.GetAll();
            cmbSearchPosition.ValueMember = "AccountTypeID";
            cmbSearchPosition.DisplayMember = "Name";
            cmbSearchPosition.SelectedIndex = -1;
            cmbPosition.DataSource = _accountBLL.GetAll();
            cmbPosition.ValueMember = "AccountTypeID";
            cmbPosition.DisplayMember = "Name";
            

        }

        private void cmbSearchPosition_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                _employee = _employeeBLL.Get(id);
                _employee.FirstName = txtFirstName.Text;
                _employee.LastName = txtLastName.Text;
                _employee.Email = txtMail.Text;
                _employee.Password = txtPassword.Text;
                _employee.AccountTypeID = (int)cmbPosition.SelectedValue;
                _employee.GSM = txtGSM.Text;
                _employee.ImageURL = txtImage.Text;
                bool control = _employeeBLL.Update(_employee);
                if (control)
                {
                    MessageBox.Show("Güncelle işleminiz gerçekleşti");
                    Clearİtems();
                    GetEmployees();
                    GetList();

                }
                else
                {
                    MessageBox.Show("İşlem Başarısız");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("İşlem Başarısız");

            }

        }

        private void Clearİtems()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtGSM.Text = string.Empty;
            txtImage.Text = string.Empty;
            txtFirstName.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvEmployeeList.DataSource = _employeeBLL.GetAllSelectType((int)cmbSearchPosition.SelectedValue)
                  .Select(x => new
                  {
                      x.EmployeeID,
                      x.FullName,
                      x.GSM,
                      x.Email,
                      x.AccountType.Name
                  }).ToList();
            }
            catch (Exception)
            {
            }

        }
    }
}
