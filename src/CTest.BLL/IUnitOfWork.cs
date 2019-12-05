using CTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using CTest.BAL.Repositories;

namespace CTest.BAL
{
    public interface IUnitOfWork : IDisposable
    {
       IDepartmentRepository DepartmentRepository   { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        ISubCategoryRepository SubCategoryRepository { get; set; }
        int Complete();
    }
}
