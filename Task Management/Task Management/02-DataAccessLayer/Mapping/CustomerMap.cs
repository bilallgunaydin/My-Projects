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
    class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(c => c.CustomerID);
            Property(c=> c.CustomerID)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.CompanyName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.ContactName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.Address)
                .HasColumnType("varchar")
                .IsRequired();
            Property(c => c.Email)
                .HasColumnType("varchar")
                .IsRequired();
            Property(c => c.LogoURL)
                .HasColumnType("varchar")
                .IsOptional();
            Property(c => c.GSM)
                .HasColumnType("char")
                .IsRequired()
                .HasMaxLength(16);
            Property(c => c.isPassive)
                .HasColumnType("bit")
                .IsRequired();
            
        }
    }
}
