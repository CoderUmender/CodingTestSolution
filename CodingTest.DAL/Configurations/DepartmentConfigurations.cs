using CodingTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CodingTest.DAL.Configurations
{
   public class DepartmentConfigurations : EntityTypeConfiguration<Department>
    {
        public DepartmentConfigurations()
        {
            HasKey(c => c.Department_Id);




        }
    }
}
