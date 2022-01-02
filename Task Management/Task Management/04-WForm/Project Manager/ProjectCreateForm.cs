using _01_Entities;
using _03_BusinessLayer;
using _03BusinessLayer;
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
    public partial class ProjectCreateForm : Form
    {
        ProjectBLL _projectBLL;
        EmployeeBLL _employeeBLL;
        CustomerBLL _customerBLL;
        Project _project;
        ProjectEmployee _proemp;
        ProjectEmployeeBLL _propempBLL;
        public ProjectCreateForm()
        {
            InitializeComponent();
            _projectBLL = new ProjectBLL();
            _project = new Project();
            _employeeBLL = new EmployeeBLL();
            _customerBLL = new CustomerBLL();
            _propempBLL = new ProjectEmployeeBLL();
        }

        private void BtnCreateProject_Click(object sender, EventArgs e)
        {
            try
            {
                _project.Name = txtBxProjectName.Text;
                _project.Description = txtBxDescription.Text;
                _project.EmployeeID = Login.LoginID;
                _project.TeamLeadID = (int)cmbTeamLead.SelectedValue;
                _project.CustomerID = (int)cmbCustomerName.SelectedValue;
                _project.GenerateDate = dtpGenerateDate.Value;
                _project.DeadLine = dtpDeadLine.Value;
                _project.IsCancel = false;
                _project.IsFinish = false;
                bool control=_projectBLL.Add(_project);

                foreach (var item in lstProjectEmployee.Items)
                {
                    _proemp = new ProjectEmployee();
                    _proemp.ProjectID = _project.ProjectID;
                    _proemp.EmployeeID = _employeeBLL.GetAllNameControl(item.ToString());
                    _proemp.isActive = true;
                    _propempBLL.Add(_proemp);
                }
                if(control)
                MessageBox.Show("Proje Başarılı Şekilde Oluşturuldu","Başarılı!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                    MessageBox.Show("Başarısız","Hata!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Başarısız","Hata!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void ProjectCreateForm_Load(object sender, EventArgs e)
        {
            GetEmployee();
            GetCustomer();
            lstEmployee.Items.Clear();
            lstProjectEmployee.Items.Clear();
            txtProjectManager.Enabled = false;
            dtpDeadLine.Value = DateTime.Now.AddDays(20); 
        }

        private void GetCustomer()
        {
            cmbCustomerName.DataSource = _customerBLL.GetAll().ToList();
            cmbCustomerName.DisplayMember = "CompanyName";
            cmbCustomerName.ValueMember = "CustomerID";
            cmbCustomerName.SelectedIndex = -1;
        }

        private void GetEmployee()
        {
            
            txtProjectManager.Text= _employeeBLL.Get(Login.LoginID).FullName;
            cmbAccountType.DataSource = _employeeBLL.GetAllAccountType();
            cmbAccountType.DisplayMember = "Name";
            cmbAccountType.ValueMember = "AccountTypeID";
            cmbAccountType.SelectedIndex = -1;
            cmbTeamLead.DataSource = _employeeBLL.GetAllSelectType(2);
            cmbTeamLead.DisplayMember = "FullName";
            cmbTeamLead.ValueMember = "EmployeeID";
            cmbTeamLead.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBxProjectName.Text = "";
            txtBxDescription.Text = "";
            cmbCustomerName.SelectedIndex = -1;
            cmbTeamLead.SelectedIndex = -1;
            dtpGenerateDate.Value = DateTime.Now;
            dtpDeadLine.Value = DateTime.Now.AddDays(20);
            txtBxProjectName.Focus();
            lstEmployee.Items.Clear();
            lstProjectEmployee.Items.Clear();
        }

        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstEmployee.Items.Clear();
            if (cmbAccountType.SelectedIndex ==0)
            {
              
                foreach (var item in _employeeBLL.GetAllSelectType(3))
                {
                    lstEmployee.Items.Add(item.FullName);
                }
            }
            else if (cmbAccountType.SelectedIndex == 1)
            {
                
                foreach (var item in _employeeBLL.GetAllSelectType(4))
                {
                    lstEmployee.Items.Add(item.FullName);
                }
            }
         else
            {
                
                foreach (var item in _employeeBLL.GetAllSelectType(5))
                {
                    lstEmployee.Items.Add(item.FullName);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lstProjectEmployee.Items.Add(lstEmployee.SelectedItem);
                lstEmployee.Items.Remove(lstEmployee.SelectedItem);
            }
            catch (Exception)
            {
            }
           
        }
    }
}
