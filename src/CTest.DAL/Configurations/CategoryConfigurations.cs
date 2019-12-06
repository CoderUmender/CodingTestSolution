using CTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CTest.DAL.Configurations
{
   public class CategoryConfigurations : EntityTypeConfiguration<Category>
    {
        public CategoryConfigurations()
        {
            HasKey(c => c.Category_Id);
        }
    }
}
