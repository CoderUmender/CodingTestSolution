using CTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using CTest.BAL.Repositories;

namespace CTest.BAL
{
    public interface IUnitOfWork : IDisposable
    {
       IDepartmentRepository departmentRepository   { get; set; }
        ICategoryRepository categoryRepository { get; set; }
        ISubCategoryRepository subCategoryRepository { get; set; }
        int Complete();
    }
}
