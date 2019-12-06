using System;
using System.Collections.Generic;

namespace CTest.BAL.Domain
{
   public class Location
    {
        public int Location_Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Department> Departments  { get; set; }
    }
}
