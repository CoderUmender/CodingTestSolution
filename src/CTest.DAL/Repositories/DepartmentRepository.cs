using CTest.BAL.Domain;
using CTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTest.DAL.Repositories
{
   public class DepartmentRepository :Repository<Category>,IDepartmentRepository
    {
        public DepartmentRepository(HierarichyContext context ):base(context)
        {

        }

        public void Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Department> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Find(Expression<Func<Department, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Category GetDepartmentsbyLocation(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Department entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Department> entities)
        {
            throw new NotImplementedException();
        }

        public Department SingleOrDefault(Expression<Func<Department, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Department IRepository<Department>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Department> IRepository<Department>.GetAll()
        {
            throw new NotImplementedException();
        }

        Department IDepartmentRepository.GetDepartmentsbyLocation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
