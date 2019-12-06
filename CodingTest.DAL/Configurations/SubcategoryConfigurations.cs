using CodingTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CodingTest.DAL.Configurations
{
  public  class SubcategoryConfigurations : EntityTypeConfiguration<SubCategory>
    {
        // configuring SubCategory
        public SubcategoryConfigurations()
        {
            HasKey(c => c.SubCategory_Id);
        }
    }
}
