using CodingTest.BAL.Domain;
using CodingTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodingTest.ServerAPI.Controllers
{
    public class LocationController : ApiController
    {
        // GET: api/Location
       
            [Route("api/v1/location/")]
        public HttpResponseMessage Get()
        {
            try
            {
                List<Location> locations = new List<Location>();

                using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
                {
                    locations =  unitOfWork.LocationRepository.GetLocation().ToList();
                }
                return  Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }  
        }


        // GET: api/Location/5
        [Route("api/v1/location/{location_id}/departments/")]
        public HttpResponseMessage Get(int location_id)
        {
            try
            {
                List<Department> departments  = new List<Department>();

                using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
                {
                    departments = unitOfWork.DepartmentRepository.GetAll().ToList().Where(c=>c.Location_ID== location_id).ToList() ;
                }
                return Request.CreateResponse(HttpStatusCode.OK, departments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }
        }

        // POST: api/Location
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Location/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
        }
    }
}
