using CTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CTest.DAL
{
  public  class HierarichyContext:DbContext
    {
        public HierarichyContext()
        {
                
        }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Department> Departments  { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
    }
}
