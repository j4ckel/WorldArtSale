using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositoty;

namespace ProjectIO.EntityConfigurations
{
    class EntityConfigurationClassArt : EntityTypeConfiguration<ClassArt>
    {
        public EntityConfigurationClassArt()
        {
            this.ToTable("ArtTable");

            

            this.Property(u => u.picturePath)
                .HasMaxLength(150)
                .IsRequired();

            this.Property(u => u.pictureDescription)
                .HasMaxLength(150)
                .IsRequired();

            this.Property(u => u.pictureTitel)
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
