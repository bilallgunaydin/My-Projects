using _01_Entities;
using _02_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BusinessLayer
{
    public class TaskBLL:IBusiness<Tasks>
    {

        //Bana Bir reposity ne işe yarar  ve neden kullanılır anlatmalısın.
        UnitOfWork _uow;
        public TaskBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Tasks item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.TaskRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public bool Remove(Tasks item)
        {
            _uow.TaskRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Tasks item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.TaskRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        //Get ile GetAll arasında ne fark var ?
        //Biri tekli diğeri alayınımı getiriyor ?
        public Tasks Get(int id)
        {
            return _uow.TaskRepository.Get(id);
        }

        public List<Tasks> GetAll()
        {
            return _uow.TaskRepository.GetAll();
        }
        public object GetALL(int id)
        {
            return _uow.TaskRepository.GetALL(id);
        }
        public object GetALL()
        {
            return _uow.TaskRepository.GetALL();
        }
        public object GetAllMyProject(int id)
        {
            return _uow.TaskRepository.GetAll().Where(x => x.Project.EmployeeID == id ).Select(x => new
            {
                x.TaskID,
                x.Name,
                x.StartDate,
                x.EndDate,
                GörevVeren = x.Manager.FullName,
                GörevAlan = x.Employee.FullName,
                Durumu = x.Situaition.Name
            }).ToList();
        }
        public object GetAllMyFinishProject(int id)
        {
            return _uow.TaskRepository.GetAll().Where(x => x.Project.TeamLeadID == id && x.isFinish == true).Select(x => new
            {
                x.TaskID,
                x.Name,
                x.Description,
                ProjeAdı = x.Project.Name,
                x.StartDate,
                x.EndDate,
                GörevAlan = x.Employee.FullName,
                Durumu = x.Situaition.Name
            }).ToList();
        }
        public object GetAllMyTask(int id)
        {
            return _uow.TaskRepository.GetAll().Where(x => x.Project.TeamLeadID == id && x.isFinish!=true).Select(x => new
            {
                x.TaskID,
                x.Name,
                x.Description,
                ProjeAdı = x.Project.Name,
                x.StartDate,
                x.EndDate,
                GörevAlan = x.Employee.FullName,
                Durumu = x.Situaition.Name
            }).ToList();
        }
    }
}
