using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositoty;
namespace ProjectIO.EntityConfigurations
{
    class EntityConfigurationsClassCustomer : EntityTypeConfiguration<ClassCustomer>
    {
        public EntityConfigurationsClassCustomer()
        {
            this.ToTable("Customer");
            this.HasKey<int>(g => g.customerId);
            this.Property(u => u.name)
                .HasMaxLength(50)
                .IsRequired();
            
            this.Property(u => u.address)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(u => u.zipCity)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(u => u.country)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(u => u.email)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(u => u.phoneNo)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(u => u.maxBid)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(u => u.customerCurrencyID)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
