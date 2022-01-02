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
    class EmployeeMap:EntityTypeConfiguration<Employees>
    {
        public EmployeeMap()
        {
            HasKey(e => e.EmployeeID);
            Property(e => e.EmployeeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.AccountType)
                .WithMany()
                .HasForeignKey(e => e.AccountTypeID);

            Property(e => e.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            Ignore(e => e.FullName);//Sql de bu alanın gözükmesini istemiyoruz.

            Property(e => e.GSM)
                .HasColumnType("char")
                .HasMaxLength(16)
                .IsRequired();
            Property(e => e.Email)
                .IsRequired()
                .HasColumnType("varchar");
            Property(e => e.ImageURL)
                .IsOptional()
                .HasColumnType("varchar");
            Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnType("varchar");
                
        }
    }
}
