using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ELessonSelectionContext _lessonContext;
        internal BaseRepository(ELessonSelectionContext elessonContext)
        {
            _lessonContext = elessonContext;
        }
        public void Add(TEntity item)
        {
            _lessonContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Added;
        }

        public void Remove(TEntity item)
        {
            _lessonContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Update(TEntity item)
        {
            _lessonContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
        }

        public TEntity Get(int id)
        {
            return _lessonContext.Set<TEntity>().Find(id);
        }

        
        public List<TEntity> GetAll()
        {

            return _lessonContext.Set<TEntity>().ToList();
        }
    }
}
