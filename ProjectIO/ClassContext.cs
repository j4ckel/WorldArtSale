using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectIO.EntityConfigurations;
using Repositoty;

namespace ProjectIO
{
    public class ClassContext :DbContext
    {
        public ClassContext() : base("data source = CV-BB-5772\\SQLEXPRESS; initial catalog = WorldArtSale; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework")
        {

        }
        public DbSet<ClassArt> classArt { get; set; }        
        public DbSet<ClassCustomer> classCustomer { get; set; }
        public DbSet<ClassSalesValues> classSalesValues { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityConfigurationClassArt());
            modelBuilder.Configurations.Add(new EntityConfigurationsClassCustomer());
            modelBuilder.Configurations.Add(new EntityConfigurationsClassSalesValues());
        }
    }
}
