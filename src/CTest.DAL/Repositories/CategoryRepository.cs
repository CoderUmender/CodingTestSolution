using CTest.BAL.Domain;
using CTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTest.DAL.Repositories
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
