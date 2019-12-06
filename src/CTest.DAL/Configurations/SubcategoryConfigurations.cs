using CTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CTest.DAL.Configurations
{
  public  class SubcategoryConfigurations : EntityTypeConfiguration<SubCategory>
    {
        public SubcategoryConfigurations()
        {
            HasKey(c => c.SubCategory_Id);
        }
    }
}
