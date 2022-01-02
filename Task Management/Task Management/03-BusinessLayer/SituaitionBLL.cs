using _01_Entities;
using _02_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BusinessLayer
{
    public class SituaitionBLL : IBusiness<Situaition>
    {
        UnitOfWork _uow;
        public SituaitionBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Situaition item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.SituaitionRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public bool Remove(Situaition item)
        {
            _uow.SituaitionRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Situaition item)
        {
            
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.SituaitionRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public Situaition Get(int id)
        {
            return _uow.SituaitionRepository.Get(id);
        }

        public List<Situaition> GetAll()
        {
            return _uow.SituaitionRepository.GetAll();
        }
    }
}
