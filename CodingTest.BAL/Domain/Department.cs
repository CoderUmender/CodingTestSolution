using System;
using System.Collections.Generic;


namespace CodingTest.BAL.Domain
{
   public class Department
    {
        public int Department_Id { get; set; }
        public string Description { get; set; }
   
        public virtual Location Location { get; set; }
        public int Location_ID { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
