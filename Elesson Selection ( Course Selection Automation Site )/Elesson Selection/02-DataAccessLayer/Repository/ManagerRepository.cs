using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ManagerRepository : BaseRepository<Manager>
    {
        internal ManagerRepository(ELessonSelectionContext context)
            : base(context)
        {

        }
    }
}
