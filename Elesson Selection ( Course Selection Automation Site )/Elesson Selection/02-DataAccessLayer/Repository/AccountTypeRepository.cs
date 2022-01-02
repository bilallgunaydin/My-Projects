using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class AccountTypeRepository : BaseRepository<AccountType>
    {
        internal AccountTypeRepository(ELessonSelectionContext context)
            : base(context)
        {

        }
    }
}
