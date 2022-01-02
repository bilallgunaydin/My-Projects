using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class AccountTypeMap:EntityTypeConfiguration<AccountType>
    {
        public AccountTypeMap()
        {
            HasKey(a => a.ID).Property(a => a.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(a => a.isPassive)
                .HasColumnType("bit")
                .IsRequired();
                
        }
    }
}
