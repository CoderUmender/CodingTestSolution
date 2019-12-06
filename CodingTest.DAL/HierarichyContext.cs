using CodingTest.BAL.Domain;
using CodingTest.DAL.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Text;

namespace CodingTest.DAL
{
  public  class HierarichyContext:DbContext
    {
        public HierarichyContext():base("name=CodingTestContext")
        {
            // this.Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=CodingTest;Integrated Security=True;Pooling=False";
           

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
