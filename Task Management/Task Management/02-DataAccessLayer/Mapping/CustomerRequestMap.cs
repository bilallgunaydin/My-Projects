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
    class CustomerRequestMap : EntityTypeConfiguration<CustomerRequest>
    {
        public CustomerRequestMap()
        {
            HasKey(cr => cr.CustomerRequestID);

            Property(cr => cr.CustomerRequestID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(cr => cr.Project)
                .WithMany()
                .HasForeignKey(cr => cr.ProjectID);

            Property(cr => cr.Description)
                    .HasColumnType("varchar")
                    .IsRequired();

            Property(cr => cr.RequestType)
                    .HasColumnType("bit")
                    .IsRequired();
                    
            Property(cr => cr.RequestDate)
                    .HasColumnType("date")
                    .IsRequired();

        }
    }
}
