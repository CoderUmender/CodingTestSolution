using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.DAL.Repositories
{
  public  class LocationRepository :Repository<Location>,ILocationRepository
    {
        public LocationRepository(HierarichyContext context):base(context)
        {

        }

        public IQueryable<Location> GetLocation()
        {
            return HierarichyContext.Locations;
        }
        public HierarichyContext HierarichyContext
        {
            get { return Context as HierarichyContext; }
        }
    }
}
