using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using CodingTest.BAL.ViewMoels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.DAL.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {//test
        public SubCategoryRepository(HierarichyContext context ):base(context)
        {

        }
        public IQueryable<SubCategoryVM> GetSubCategorybyLocationDepartmentAndCategoty(int location_id, int department_id, int Category_id)
        {
            var data = from loc in HierarichyContext.Locations.Where(c=>c.Location_Id==location_id)
                       join dept in HierarichyContext.Departments.Where(c=>c.Department_Id==department_id) on loc.Location_Id equals dept.Location_ID
                       join cat in HierarichyContext.Categories.Where(c=>c.Category_Id==Category_id) on dept.Department_Id equals cat.Department_ID
                       join subcat in HierarichyContext.SubCategories on cat.Category_Id equals subcat.Category_Id
                       select new SubCategoryVM()
                       {
                           SubCategoryID = subcat.SubCategory_Id,
                           SubCategoryName=subcat.Description,
                           CategoryName = cat.Description,
                           DepartmentName = dept.Description,
                           LocationName = loc.Description
                       };

            return data;
        }

        public IQueryable<SubCategoryVM> GetSubCategorybyLocationDepartmentAndCategotySubcategory(int location_id, int department_id, int Category_id, int SubCategory_id)
        {
            var data = from loc in HierarichyContext.Locations.Where(c => c.Location_Id == location_id)
                       join dept in HierarichyContext.Departments.Where(c => c.Department_Id == department_id) on loc.Location_Id equals dept.Location_ID
                       join cat in HierarichyContext.Categories.Where(c => c.Category_Id == Category_id) on dept.Department_Id equals cat.Department_ID
                       join subcat in HierarichyContext.SubCategories.Where(c=>c.SubCategory_Id==SubCategory_id) on cat.Category_Id equals subcat.Category_Id
                       select new SubCategoryVM()
                       {
                           SubCategoryID = subcat.SubCategory_Id,
                           SubCategoryName = subcat.Description,
                           CategoryName = cat.Description,
                           DepartmentName = dept.Description,
                           LocationName = loc.Description
                       };

            return data;
        }

        public HierarichyContext HierarichyContext
        {
            get { return Context as HierarichyContext; }
        }
    }
}
