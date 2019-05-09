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
            Database.SetInitializer(new SeedInitializer());
        }
        //den her sætter mit table classart op i DB
        public DbSet<ClassArt> classArt { get; set; }
        //den her sætter mit table classCustomer op i DB
        public DbSet<ClassCustomer> classCustomer { get; set; }
        //den her sætter mit table classSalesValues op i DB
        public DbSet<ClassSalesValues> classSalesValues { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //kald af EntityConfigurations
            modelBuilder.Configurations.Add(new EntityConfigurationClassArt());
            modelBuilder.Configurations.Add(new EntityConfigurationsClassCustomer());
            modelBuilder.Configurations.Add(new EntityConfigurationsClassSalesValues());
        }
    }
}
