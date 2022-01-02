using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Entities
{
    interface IDataMapper<TEntity,TKey>
    {

        int insert(TEntity item);
        int update(TEntity item);
        int delete(TEntity item);
        List<TEntity> GetAll();

        TEntity Get(TKey id);
        
        
        
    }
}
