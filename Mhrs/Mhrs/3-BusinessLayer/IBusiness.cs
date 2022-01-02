using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    interface IBusiness <TEntity, TKey>
    {
        bool Insert(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
        List<TEntity> GetAll();
        TEntity Get(TKey id);
    }
}
