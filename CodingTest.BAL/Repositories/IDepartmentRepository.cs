using CodingTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.BAL.Repositories
{
  public  interface IDepartmentRepository:IRepository<Department>
    {
       
        Department GetDepartmentsbyLocation(int id);
    }
}
