using CTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CTest.DAL.Configurations
{
   public class LocationConfigurations : EntityTypeConfiguration<Location>
    {
        public LocationConfigurations()
        {
            HasKey(c => c.Location_Id);
           
        }
    }
}
