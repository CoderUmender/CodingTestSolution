using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using CodingTest.BAL.ViewMoels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CodingTest.DAL.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(HierarichyContext context) : base(context)
        {

        }

        public IQueryable<DepartmentVM> GetDepartmentsbyLocation(int id)
        {
            var data= from dept in HierarichyContext.Departments
                      join loc in HierarichyContext.Locations.Where(c=>c.Location_Id==id) on dept.Location_ID equals loc.Location_Id
                     
                      select new DepartmentVM()
                      {
                         DepartmentID=dept.Department_Id,
                         DepartmentName=dept.Description,
                         LocationName=loc.Description
                      };

            return data;
        }
        public HierarichyContext HierarichyContext
        {
            get { return Context as HierarichyContext; }
        }
    }
}
