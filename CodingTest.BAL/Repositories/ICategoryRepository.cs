using CodingTest.BAL.Domain;
using CodingTest.BAL.ViewMoels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.BAL.Repositories
{
   public interface ICategoryRepository:IRepository<Category>
    {
        IQueryable<CategoryVM> GetCategoriesbyLocationANdDepartment(int location_id, int department_id);
        Category GetCategoriByLocationDepartmentAndCategory(int location_id, int department_id, int Category_id);
    }
}
