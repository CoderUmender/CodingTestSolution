using CTest.BAL.Domain;
using CTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTest.DAL.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(HierarichyContext context) : base(context)
        {

        }
        public Department GetDepartmentsbyLocation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
