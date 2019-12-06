using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.DAL.Repositories
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
