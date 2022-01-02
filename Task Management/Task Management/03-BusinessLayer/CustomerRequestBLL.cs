using _01_Entities;
using _02_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BusinessLayer
{
    public class CustomerRequestBLL : IBusiness<CustomerRequest>
    {

        UnitOfWork _uow;
        public CustomerRequestBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(CustomerRequest item)
        {
            if (!string.IsNullOrWhiteSpace(item.Description))
            {
                _uow.CustomerRequestRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public bool Remove(CustomerRequest item)
        {
            _uow.CustomerRequestRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(CustomerRequest item)
        {
            if (!string.IsNullOrWhiteSpace(item.Description))
            {
                _uow.CustomerRequestRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public CustomerRequest Get(int id)
        {
            return _uow.CustomerRequestRepository.Get(id);
        }

        public List<CustomerRequest> GetAll()
        {
            return _uow.CustomerRequestRepository.GetAll();
        }
        public object GetAllSelectedProject(int id)
        {
            return _uow.CustomerRequestRepository.GetAll().Where(x => x.ProjectID == id).Select(x => new
            {
                x.CustomerRequestID,
                x.Project.Name,
                x.Description,
                x.RequestType,
                x.RequestDate
            }
                ).ToList(); 
        }
    }
}
