using _01_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer.Mapping
{
    class AccountTypeMap:EntityTypeConfiguration<AccountType>
    {
        public AccountTypeMap()
        {
            HasKey(ac => ac.AccountTypeID);

            Property(ac => ac.AccountTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);//Otomatik artan Özelliği

            Property(ac => ac.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
