using CodingTest.BAL.Domain;
using CodingTest.BAL.ViewMoels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.BAL.Repositories
{
  public  interface IDepartmentRepository:IRepository<Department>
    {
       
        IQueryable<DepartmentVM> GetDepartmentsbyLocation(int id);
        Department GetDepartmentsbyLocationAndDepartment(int Locationid,int departmentid);

    }
}
