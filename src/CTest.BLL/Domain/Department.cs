using System;
using System.Collections.Generic;
namespace CTest.BAL.Domain
{
   public class Department
    {
        public int Department_Id { get; set; }
        public int Description { get; set; }
        public virtual ICollection<Location > Locations { get; set; }
    }
}
