using CodingTest.BAL.Domain;
using CodingTest.BAL.ViewMoels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.BAL.Repositories
{
    public interface ISubCategoryRepository :IRepository<SubCategory>
    {
        IQueryable<SubCategoryVM> GetSubCategorybyLocationDepartmentAndCategoty(int location_id, int department_id, int Category_id);
        IQueryable<SubCategoryVM> GetSubCategorybyLocationDepartmentAndCategotySubcategory(int location_id, int department_id, int Category_id, int SubCategory_id);
    }
}
