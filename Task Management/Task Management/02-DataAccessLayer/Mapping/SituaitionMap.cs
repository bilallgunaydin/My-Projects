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
    class SituaitionMap : EntityTypeConfiguration<Situaition>
    {
        public SituaitionMap()
        {
            HasKey(sit => sit.SituationID);

            Property(sit => sit.SituationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(sit => sit.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
