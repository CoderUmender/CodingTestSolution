namespace CTest.BAL.Domain
{
  public  class SubCategory
    {
        public int SubCategory_Id { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
    }
}
