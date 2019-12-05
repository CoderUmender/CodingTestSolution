using CTest.BAL;
using CTest.BAL.Repositories;
using CTest.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTest.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly HierarichyContext _context;

        public UnitOfWork(HierarichyContext context)
        {
            _context = context;
            DepartmentRepository = new DepartmentRepository(context);
            CategoryRepository = new CategoryRepository(context);
            SubCategoryRepository = new SubCategoryRepository(context);

         
        }

        public IDepartmentRepository DepartmentRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICategoryRepository CategoryRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISubCategoryRepository SubCategoryRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
