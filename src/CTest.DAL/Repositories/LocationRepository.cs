using CTest.BAL.Domain;
using CTest.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTest.DAL.Repositories
{
  public  class LocationRepository :Repository<Location>
    {
        public LocationRepository(HierarichyContext context):base(context)
        {

        }
    }
}
