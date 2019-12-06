using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.DAL.Repositories
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
