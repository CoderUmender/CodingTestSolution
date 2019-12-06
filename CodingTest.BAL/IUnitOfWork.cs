using CodingTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using CodingTest.BAL.Repositories;

namespace CodingTest.BAL
{
    public interface IUnitOfWork : IDisposable
    {
       ILocationRepository LocationRepository { get; set; }
       IDepartmentRepository DepartmentRepository   { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        ISubCategoryRepository SubCategoryRepository { get; set; }
        int Complete();
    }
}
