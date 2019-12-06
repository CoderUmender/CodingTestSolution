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

        public IEnumerable<Location> GetLocation()
        {
            return HierarichyContext.Locations.Include("Departments");
        }
        public HierarichyContext HierarichyContext
        {
            get { return Context as HierarichyContext; }
        }
    }
}
