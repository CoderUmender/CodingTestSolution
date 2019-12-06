using System.Collections.Generic;

namespace CTest.BAL.Domain
{
  public  class SubCategory
    {
        public int SubCategory_Id { get; set; }
        public string Description { get; set; }
        public int Category_Id { get; set; }
        public virtual Category Category { get; set; }
    }
}
