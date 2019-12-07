using CodingTest.BAL.Domain;
using CodingTest.BAL.ViewMoels;
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
            IEnumerable<Location> locations = new List<Location>();
            try
            {
              using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
                {
                     locations = unitOfWork.LocationRepository.GetLocation().ToList();              
                    
                }
                return  Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }  
        }
        // GET: api/Location/5
        [Route("api/v1/location/{location_id}/department/")]
        public HttpResponseMessage Get(int location_id)
        {
            try
            {  
                List<DepartmentVM > departments  = new List<DepartmentVM>();

                using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
                {
                    departments = unitOfWork.DepartmentRepository.GetDepartmentsbyLocation(location_id).ToList();
                }
                return Request.CreateResponse(HttpStatusCode.OK, departments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ErrorOccured! Please Contact admin");
            }
        }
        [Route("api/v1/location/{location_id}/department/{department_id}/category")]
        public HttpResponseMessage Get(int location_id,int department_id)
        {
            try
            {
                List<CategoryVM> categories = new List<CategoryVM>();
                using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
                {
                    categories = unitOfWork.CategoryRepository.GetCategoriesbyLocationANdDepartment(location_id,department_id).ToList();
                }
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }
        }
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{category_id}/subcategory")]
        public HttpResponseMessage Get(int location_id, int department_id,int category_id)
        {
            try
            {
                List<SubCategoryVM> subCategories = new List<SubCategoryVM>();
                using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
                {
                    subCategories = unitOfWork.SubCategoryRepository.GetSubCategorybyLocationDepartmentAndCategoty(location_id, department_id,category_id).ToList();
                }
                return Request.CreateResponse(HttpStatusCode.OK, subCategories);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }
        }
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{category_id}/subcategory/{subcategory_id}")]
        public HttpResponseMessage Get(int location_id, int department_id, int category_id,int subcategory_id)
        {
            try
            {
                List<SubCategoryVM> subCategories = new List<SubCategoryVM>();
                using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
                {
                    subCategories = unitOfWork.SubCategoryRepository.GetSubCategorybyLocationDepartmentAndCategotySubcategory(location_id, department_id, category_id,subcategory_id).ToList();
                }
                return Request.CreateResponse(HttpStatusCode.OK, subCategories);
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
