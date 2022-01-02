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
    public partial class ProjectEmployeeAddForm : Form
    {
        ProjectBLL _projectBLL;
        EmployeeBLL _employeeBLL;
        ProjectEmployeeBLL _projectEmpBLL;
        ProjectEmployee _proemp;
        public ProjectEmployeeAddForm()
        {
            InitializeComponent();
            _projectBLL = new ProjectBLL();
            _employeeBLL = new EmployeeBLL();
            _projectEmpBLL = new ProjectEmployeeBLL();
            _proemp = new ProjectEmployee();
        }

        private void ProjectEmployeeAddForm_Load(object sender, EventArgs e)
        {
            GetProject();
            GetAccount();
        }
        private void GetProject()
        {
            cmbProject.DataSource= _projectBLL.GetAllMyProject(Login.LoginID);
            cmbProject.DisplayMember = "Name";
            cmbProject.ValueMember = "ProjectID";
        }
        private void GetAccount()
        {
            cmbAccountType.DataSource = _employeeBLL.GetAllAccountType();
            cmbAccountType.DisplayMember = "Name";
            cmbAccountType.ValueMember = "AccountTypeID";
        }

        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            GetEmployee();
            
        }

        private void GetEmployee()
        {
            lstEmployee.Items.Clear();
            if (cmbAccountType.SelectedIndex == 0)
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

        private void BtnCreateProject_Click(object sender, EventArgs e)
        {
            int counter=0;
            foreach (var item in lstProjectEmployee.Items)
            {
                _proemp = new ProjectEmployee();
                _proemp.ProjectID = (int)cmbProject.SelectedValue;
                _proemp.EmployeeID = _employeeBLL.GetAllNameControl(item.ToString());
                _proemp.isActive = true;
              bool control=_projectEmpBLL.Add(_proemp);
              if (control)
                  counter = 1;
            }
            if(counter==1)
            MessageBox.Show("Ekleme Başarılı","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show("Ekleme Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lstProjectEmployee.Items.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        { 
            lstProjectEmployee.Items.Clear();
            lstEmployee.Items.Clear();
            GetEmployee();
        }
    }
}
