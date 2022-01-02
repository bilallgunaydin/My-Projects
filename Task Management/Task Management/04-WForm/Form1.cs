using _03_BusinessLayer;
using _01_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WForm.Project_Manager;
using WForm.Team_Leader;
using WForm.Work_Analyst;
using WForm.Software_Developer;

namespace WForm
{
    public partial class Login : Form
    {
        ForgetPassword frmForger = new ForgetPassword();
        EmployeeBLL emp;
        Employees _emp;
        public Login()
        {
            InitializeComponent();
            emp = new EmployeeBLL();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ForgetPassword_Click(object sender, EventArgs e)
        {
            frmForger.ShowDialog();
        }
        public static int LoginID;
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginID = emp.GetLogin(txtEmail.Text, txtPassword.Text);
            _emp = emp.Get(LoginID);
            if(_emp == null)
            {
                MessageBox.Show("E-mail veya Şifre Hatalı.");
                txtEmail.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                
                this.Hide();
                if (_emp.AccountTypeID == 1)
                {
                    ProjectManager pro = new ProjectManager();
                    pro.Show();
                }
                else if(_emp.AccountTypeID == 2)
                {
                    TeamLeader team = new TeamLeader();
                    team.Show();
                }
                else if(_emp.AccountTypeID == 3)
                {
                    WorkAnalyst work = new WorkAnalyst();
                    work.Show();
                }
                else if(_emp.AccountTypeID == 4)
                {
                    SoftwareDeveloper dev = new SoftwareDeveloper();
                    dev.Show();
                }
                else
                {
                    Tester.Tester test = new Tester.Tester();
                    test.Show();
                }
               
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "bilallgunaydin@gmail.com";
            txtPassword.Text = "bilal123";
        }

       
    }
}
