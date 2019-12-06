using CodingTest.BAL;
using CodingTest.BAL.Repositories;
using CodingTest.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.DAL
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
            LocationRepository = new LocationRepository(context);


        }

        public IDepartmentRepository DepartmentRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public ISubCategoryRepository SubCategoryRepository { get; set; }
        public ILocationRepository LocationRepository { get; set; }

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
