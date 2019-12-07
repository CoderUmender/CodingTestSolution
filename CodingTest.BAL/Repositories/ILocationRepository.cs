using CodingTest.BAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.BAL.Repositories
{
   public interface ILocationRepository: IRepository<Location>
    {
        IQueryable<Location> GetLocation();
    }
}
