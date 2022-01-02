using _01_Entities;
using _02_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BusinessLayer
{
    public class AccountTypeBLL : IBusiness<AccountType>
    {
        UnitOfWork _uow;
        public AccountTypeBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(AccountType item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.AccountTypeRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public bool Remove(AccountType item)
        {
            _uow.AccountTypeRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(AccountType item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.AccountTypeRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public AccountType Get(int id)
        {
            return _uow.AccountTypeRepository.Get(id);
        }

        public List<AccountType> GetAll()
        {
            return _uow.AccountTypeRepository.GetAll();
        }
    }
}
