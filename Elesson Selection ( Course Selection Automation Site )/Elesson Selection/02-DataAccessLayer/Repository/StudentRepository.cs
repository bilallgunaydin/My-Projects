using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        internal StudentRepository(ELessonSelectionContext context)
            : base(context)
        {

        }
    }
}
