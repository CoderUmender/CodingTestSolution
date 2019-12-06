using CTest.BAL.Domain;
using CTest.DAL.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CTest.DAL
{
  public  class HierarichyContext:DbContext
    {
        public HierarichyContext(string name)
        {
            this.Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=CTest;Integrated Security=True;Pooling=False";
            this.Configuration.LazyLoadingEnabled = false;

        }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Department> Departments  { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // adding Configurations to  modelbuilder
            modelBuilder.Configurations.Add(new LocationConfigurations());
            modelBuilder.Configurations.Add(new DepartmentConfigurations());
            modelBuilder.Configurations.Add(new CategoryConfigurations());
            modelBuilder.Configurations.Add(new SubcategoryConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
