using CTest.BAL.Domain;
using CTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTest.DAL.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(HierarichyContext context ):base(context)
        {

        }

        public SubCategory GetSubCategorybyCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
