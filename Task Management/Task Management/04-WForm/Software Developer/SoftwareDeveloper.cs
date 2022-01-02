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

namespace WForm.Software_Developer
{
    public partial class SoftwareDeveloper : Form
    {
        TaskBLL _task;
        Tasks task;
        ProjectBLL proBll;
        public SoftwareDeveloper()
        {
            InitializeComponent();
            _task = new TaskBLL();
            task = new Tasks();
            proBll = new ProjectBLL();
        }

        private void SoftwareDeveloper_Load(object sender, EventArgs e)
        {
            List();   
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvSoftware.SelectedRows[0].Cells[0].Value;
                task = _task.Get(id);
                task.EmployeeID = Login.LoginID;
                _task.Update(task);
                List();
                MessageBox.Show("Görev İşleme Alındı");
            }
            catch (Exception)
            {
                MessageBox.Show("İşleme Alma Başarısız.");
            }
            
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvSoftware.SelectedRows[0].Cells[0].Value;
                task = _task.Get(id);
                task.SituaitionID = 3;
                _task.Update(task);
                List();
                MessageBox.Show("Görev Tamamlandı.Test Uzmanına yollandı");
            }
            catch (Exception)
            {
                MessageBox.Show("Problem oluştu!");
            }
            
        }
        public void List()
        {
             
            dgvSoftware.DataSource = _task.GetALL(Login.LoginID);
        }
    }
}
