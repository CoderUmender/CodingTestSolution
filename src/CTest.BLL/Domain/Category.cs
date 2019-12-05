using System;
using System.Collections.Generic;
namespace CTest.BAL.Domain
{
   public class Category
    {
        public int Category_Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
