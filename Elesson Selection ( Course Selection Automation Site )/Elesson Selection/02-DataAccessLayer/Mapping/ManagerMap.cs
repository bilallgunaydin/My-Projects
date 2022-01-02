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
    class ManagerMap:EntityTypeConfiguration<Manager>
    {
        public ManagerMap()
        {
            HasKey(m => m.ID).Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.FirstName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(m => m.LastName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(m => m.Mail)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(100);
            Property(m => m.Password)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(12);
            Property(m => m.isPassive)
                .HasColumnType("bit")
                .IsRequired();
            
            //Relationship
            HasRequired(m => m.AccountType)
                .WithMany()
                .HasForeignKey(m => m.AccountTypeID)
                .WillCascadeOnDelete(false);
            
        }
    }
}
