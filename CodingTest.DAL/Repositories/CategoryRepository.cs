using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using CodingTest.BAL.ViewMoels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.DAL.Repositories
{
  public   class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(HierarichyContext context ):base(context)
        {

        }

        public IQueryable<CategoryVM> GetCategoriesbyLocationANdDepartment(int location_id, int department_id)
        {
            var data = from dept in HierarichyContext.Departments.Where(c=>c.Department_Id==department_id)
                       join loc in HierarichyContext.Locations.Where(c=>c.Location_Id==location_id) on dept.Location_ID equals loc.Location_Id
                       join cat in HierarichyContext.Categories on  dept.Department_Id equals cat.Department_ID
                       select new CategoryVM()
                       {
                           CategoryID  = cat.Category_Id,
                           CategoryName = cat .Description,
                           DepartmentName=dept.Description,
                           LocationName = loc.Description
                       };

            return data;
        }

        public Category GetCategoriByLocationDepartmentAndCategory(int location_id, int department_id, int Category_id)
        {
            var data = HierarichyContext.Categories.
               Where(c => c.Department_ID == department_id && c.Category_Id == Category_id).SingleOrDefault();


            return data;
        }

        public HierarichyContext HierarichyContext
        {
            get { return Context as HierarichyContext; }
        }


    }
}
