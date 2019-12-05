using CTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTest.BAL.Repositories
{
   public interface ICategoryRepository:IRepository<Category>
    {
        Category GetCategorybyDepartments(int Id);
    }
}
