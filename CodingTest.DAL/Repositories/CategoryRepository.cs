using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.DAL.Repositories
{
  public   class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(HierarichyContext context ):base(context)
        {

        }

        public Category GetCategorybyDepartments(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
