using CTest.BAL.Domain;
using CTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTest.DAL.Repositories
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
