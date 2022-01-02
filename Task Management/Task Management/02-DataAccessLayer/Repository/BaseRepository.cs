using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer.Repository
{
    public abstract class BaseRepository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        TaskManagementContext _taskContext;
        internal BaseRepository(TaskManagementContext taskContext)
        {
            _taskContext = taskContext;
        }
        public void Add(TEntity item)
        {
            _taskContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Added;
        }

        public void Remove(TEntity item)
        {
            _taskContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Update(TEntity item)
        {
            _taskContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
        }

        public TEntity Get(int id)
        {
            return _taskContext.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            _taskContext.EntityleriSerbestBırak();
            return _taskContext.Set<TEntity>().ToList();
        }
    }
}
