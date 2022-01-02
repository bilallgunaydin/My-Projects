using _01_Entities;
using _02_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BusinessLayer
{
    public class ProjectBLL : IBusiness<Project>
    {
        UnitOfWork _uow;
        public ProjectBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Project item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name) && !string.IsNullOrWhiteSpace(item.Description) && item.GenerateDate < item.DeadLine)
            {
                _uow.ProjectRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public bool Remove(Project item)
        {
            _uow.ProjectRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Project item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name) && !string.IsNullOrWhiteSpace(item.Description) && item.GenerateDate < item.DeadLine)
            {
                _uow.ProjectRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public Project Get(int id)
        {
            return _uow.ProjectRepository.Get(id);
        }

        public List<Project> GetAll()
        {
            return _uow.ProjectRepository.GetAll();
        }
        public object GetAllTable()
        {
            return _uow.ProjectRepository.GetAll().Select(x => new { x.ProjectID, x.Name, x.Description, ProjeYöneticisi = x.Employee.FullName, x.Customer.ContactName, x.GenerateDate, x.DeadLine, x.StartDate, x.EndDate, x.IsFinish, x.IsCancel }).ToList();
        }
        public object GetAllMyProject(int id)
        {
            return _uow.ProjectRepository.GetAll().Where(x => x.EmployeeID == id).Select(x => new
            {
                x.ProjectID,
                x.Name,
                x.Description,
                ProjeYöneticisi = x.Employee.FullName,
                x.Customer.ContactName,
                x.GenerateDate,
                x.DeadLine,
                x.StartDate,
                x.EndDate,
                x.IsFinish,
                x.IsCancel
            }
            ).ToList();
        }
        public object GetAllMyFinishProject(int id)
        {
            return _uow.ProjectRepository.GetAll().Where(x => x.EmployeeID == id && x.IsFinish == true).Select(x => new { x.ProjectID, x.Name }).ToList();
        }
        public object GetAllFinishProject()
        {
            return _uow.ProjectRepository.GetAll().Where(x => x.IsFinish == true).Select(x => new { x.ProjectID, x.Name }).ToList();
        }
        public List<Tasks> GetAllProjectTask(int LoginId, int SelectedID)
        {
            return _uow.TaskRepository.GetAll().Where(x => x.ProjectID == SelectedID && x.Project.EmployeeID == LoginId).ToList();
        }
        public object TeamLeadProject(int id)
        {
            return _uow.ProjectRepository.GetAll().Where(x => x.TeamLeadID == id && x.IsCancel != true && x.IsFinish != true).Select(x => new {
                x.ProjectID,
                x.Name,
                x.Description,
                x.GenerateDate,
                x.DeadLine,
                x.StartDate,
                x.EndDate,
                x.IsFinish,
                x.IsCancel
            }).ToList();
        }

    }
}
