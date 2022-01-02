using _01_Entities;
using _02_DataAccessLayer;
using _03_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03BusinessLayer
{
    public class ProjectEmployeeBLL:IBusiness<ProjectEmployee>
    {
        UnitOfWork _uow;
        public ProjectEmployeeBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(ProjectEmployee item)
        {
            try
            {
                _uow.ProjectEmployeeRepository.Add(item);
                return _uow.ApplyChanges();
            }
            catch (Exception)
            {

                return false;
            }

        }


        public bool Remove(ProjectEmployee item)
        {
            _uow.ProjectEmployeeRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(ProjectEmployee item)
        {
            try
            {
                _uow.ProjectEmployeeRepository.Update(item);
                return _uow.ApplyChanges();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public ProjectEmployee Get(int id)
        {
            return _uow.ProjectEmployeeRepository.Get(id);
        }

        public List<ProjectEmployee> GetAll()
        {
            return _uow.ProjectEmployeeRepository.GetAll();
        }
        public object GetAllProject(int id)
        {
            return _uow.ProjectEmployeeRepository.GetAll().Where(x => x.EmployeeID == id && x.Project.IsCancel != true && x.Project.IsFinish != true).Select(x => new
            {
                x.Project.ProjectID,
                x.Project.Name,
                x.Project.TeamLead.FullName,
                x.Project.DeadLine,
                x.Project.GenerateDate
            }).ToList();
        }
    } 
}