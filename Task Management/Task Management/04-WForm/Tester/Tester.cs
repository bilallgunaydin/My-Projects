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

namespace WForm.Tester
{
    public partial class Tester : Form
    {
        TaskBLL _taskBLL;
        Tasks task;
        ProjectBLL _projectBLL;
        Project _project;
        public Tester()
        {
            InitializeComponent();
            _taskBLL = new TaskBLL();
            task = new Tasks();
            _projectBLL = new ProjectBLL();
            _project = new Project();
        }

        private void Tester_Load(object sender, EventArgs e)
        {
            List();
        }

        private void btnSuccesfull_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvTest.SelectedRows[0].Cells[0].Value;
                task = _taskBLL.Get(id);
                task.isFinish = true;


                bool control = _taskBLL.Update(task);
                if (control)
                {

                    MessageBox.Show("Başarılı.Takım Liderine Yollandı.");
                    List();
                    _project = _projectBLL.Get(task.ProjectID);
                    if (_project.EndDate == null || _project.EndDate < task.EndDate)
                    {
                        _project.EndDate = task.EndDate;
                        _projectBLL.Update(_project);
                    }
                }
                else
                {
                    MessageBox.Show("Başarısız oldu.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }
        public void List()
        {
            dgvTest.DataSource = _taskBLL.GetALL();
        }

        private void btnTestError_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvTest.SelectedRows[0].Cells[0].Value;
                task = _taskBLL.Get(id);
                task.SituaitionID = 2;
                _taskBLL.Update(task);
                List();
                MessageBox.Show("Yazılım Geliştiriciye Geri Yollandı");
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu!");
            }
        }
    }
}
