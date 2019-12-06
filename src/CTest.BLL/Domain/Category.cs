using System;
using System.Collections.Generic;
namespace CTest.BAL.Domain
{
   public class Category
    {
        public int Category_Id { get; set; }
        public string Description { get; set; }
        public virtual Department Department  { get; set; }
        public int Department_ID { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
