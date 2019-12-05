using CTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTest.BAL.Repositories
{
  public  interface IDepartmentRepository:IRepository<Department>
    {
       
        Department GetDepartmentsbyLocation(int id);
    }
}
