using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositoty;

namespace ProjectIO.EntityConfigurations
{
    class EntityConfigurationsClassSalesValues : EntityTypeConfiguration<ClassSalesValues>
{
        public EntityConfigurationsClassSalesValues()
        {
            //name on the table
            this.ToTable("ArtTrade");
            //table column id
            
            //table column customerid forigenkey
            this.Property(u => u.customerId)
            .IsRequired();
            //table column artid forigenkey
            this.Property(u => u.artID)
            .IsRequired();
            //table column bidUSD
            this.Property(u => u.bidUSD)
            .HasMaxLength(50)
            .IsRequired();
            //table column bideur
            this.Property(u => u.bidEUR)
            .HasMaxLength(50)
            .IsRequired();
            //table column bidOwnValuta
            this.Property(u => u.bidOwnValuta)
            .HasMaxLength(50)
            .IsRequired();
            //table column priceWithFeeEUR
            this.Property(u => u.priceWithFeeEUR)
            .HasMaxLength(50)
            .IsRequired();
            //table column priceWithFeeOwnValuta
            this.Property(u => u.priceWithFeeOwnValuta)
            .HasMaxLength(50)
            .IsRequired();
            //table column priceWithFeeUSD
            this.Property(u => u.priceWithFeeUSD)
            .HasMaxLength(50)
            .IsRequired();
            //table column date
            this.Property(u => u.date)
                .IsRequired();
        }
    }
}

