using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.DAL.Repositories
{
  public  class LocationRepository :Repository<Location>,ILocationRepository
    {
        public LocationRepository(HierarichyContext context):base(context)
        {

        }

        public Location GetLocation()
        {
            throw new NotImplementedException();
        }
    }
}
