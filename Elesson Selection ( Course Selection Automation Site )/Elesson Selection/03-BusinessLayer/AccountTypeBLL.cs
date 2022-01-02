using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccountTypeBLL:IBusiness<AccountType>
    {
         UnitOfWork _uow;
         public AccountTypeBLL()
        {
            _uow = new UnitOfWork();
        }
        /// <summary>
        /// Hesap Tipi eklemek için kullanılır.
        /// </summary>
         /// <param name="item">AccountType tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Add(AccountType item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.AccountTypeRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        /// Hesap Tipi silmek için kullanılır.Normalde remove metodu kullanılması gerekir. Ancak veri tabanı ile işlem yapılıyorsa silmek yerine onu pasif hale getirmek veri kaybına ve tablolar arasındaki ilişkiye zarar vermez.
        /// </summary>
        /// <param name="item">AccountType tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Remove(AccountType item)
        {
            if (item != null)
            {
                item.isPassive = true;
                _uow.AccountTypeRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        /// Var olan hesap tiplerini güncellemek için kullanılır.
        /// </summary>
        /// <param name="item">AccountType tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Update(AccountType item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.AccountTypeRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        /// id'si ile eşleşen AccountType tipini döndürür.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns></returns>
        public AccountType Get(int id)
        {
            return _uow.AccountTypeRepository.Get(id);
        }

        /// <summary>
        /// Pasif olmayan tüm AccountType tiplerini liste olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public List<AccountType> GetAll()
        {
            return _uow.AccountTypeRepository.GetAll().Where(a => a.isPassive == false).ToList();
        }
    }
}
