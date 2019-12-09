using CodingTest.BAL;
using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
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

        private IUnitOfWork _unitOfWork;
       public LocationController()
        {
            _unitOfWork = new UnitOfWork(new HierarichyContext());         
        }
        public LocationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("api/v1/location/")]
        public HttpResponseMessage Get()
        {
            IEnumerable<Location> locations = new List<Location>();
            try
            {          
                   locations = _unitOfWork.LocationRepository.GetLocation().ToList();                                            
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
                departments = _unitOfWork.DepartmentRepository.GetDepartmentsbyLocation(location_id).ToList();               
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
                 categories = _unitOfWork.CategoryRepository.GetCategoriesbyLocationANdDepartment(location_id,department_id).ToList();              
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
                subCategories = _unitOfWork.SubCategoryRepository.GetSubCategorybyLocationDepartmentAndCategoty(location_id, department_id,category_id).ToList();            
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
                subCategories = _unitOfWork.SubCategoryRepository.GetSubCategorybyLocationDepartmentAndCategotySubcategory(location_id, department_id, category_id,subcategory_id).ToList();            
                return Request.CreateResponse(HttpStatusCode.OK, subCategories);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }
        }




        // POST: api/Location

        [Route("api/v1/location/")]
        public HttpResponseMessage Post(Location description)
        {
            //Adding Location..
            try
            {
                 Location locationobj = new Location();
                locationobj.Description = description.Description;
                _unitOfWork.LocationRepository.Add(locationobj);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, description);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while adding record");
            }

        }
        //Post: Api/Department  
        [Route("api/v1/location/{location_id}/department/{description}")]
        public HttpResponseMessage Post(int location_id,string description)
        {
            //Adding Location..
            try
            {
                Department departmentobj = new Department();
                departmentobj.Description = description;
                departmentobj.Location_ID = location_id;
                _unitOfWork.DepartmentRepository.Add(departmentobj);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, description);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while adding record");
            }

        }
        //Post: Api/Category  
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{description}")]
        public HttpResponseMessage Post(int location_id, int department_id,string description)
        {
            //Adding Category..
            try
            {
                Category categoryObj   = new Category();
                categoryObj.Description = description;
                categoryObj.Department_ID = department_id;
                _unitOfWork.CategoryRepository.Add(categoryObj);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, description);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while adding record");
            }

        }
        //Post: Api/SubCategory  
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}/SubCategory/{description}")]
        public HttpResponseMessage Post(int location_id, int department_id,int Category_id, string description)
        {
            //Adding SubCategory..
            try
            {
                SubCategory subcategoryObj = new SubCategory();
                subcategoryObj.Description = description;
                subcategoryObj.Category_Id = Category_id;
                _unitOfWork.SubCategoryRepository.Add(subcategoryObj);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, description);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while adding record");
            }

        }




        // PUT: api/Location/5
        [HttpPut]
        [Route("api/v1/location/")]
        public HttpResponseMessage Put(Location description)
        {
            try
            {            
                Location locationobj= _unitOfWork.LocationRepository.Get(description.Location_Id);
                if (locationobj != null)
                {
                    locationobj.Description = description.Description;
                    _unitOfWork.LocationRepository.Update(locationobj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.Created, description);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, description);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // PUT: api/Department/5
        [HttpPut]
        [Route("api/v1/location/{location_id}/department/{department_id}/{description}")]
        public HttpResponseMessage Put(int location_id,int department_id, string description)
        {
            try
            {
                Department departmentobj = _unitOfWork.DepartmentRepository.GetDepartmentsbyLocationAndDepartment(location_id,department_id);
                if (departmentobj != null)
                {             
                    departmentobj.Description = description;                   
                    _unitOfWork.DepartmentRepository.Update(departmentobj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.Created, description);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, description);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // PUT: api/Category/5
        [HttpPut]
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}/{description}")]
        public HttpResponseMessage Put(int location_id, int department_id, int Category_id, string description)
        {
            try
            {
                Category categoryObj = _unitOfWork.CategoryRepository.GetCategoriByLocationDepartmentAndCategory(location_id, department_id,Category_id);
                if (categoryObj != null)
                {
                    categoryObj.Description = description;
                    _unitOfWork.CategoryRepository.Update(categoryObj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.Created, description);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, description);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // PUT: api/SubCategory/5
        [HttpPut]
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}/subcategory/{SubCategory_id}/{description}")]
        public HttpResponseMessage Put(int location_id, int department_id, int Category_id,int  SubCategory_id, string description)
        {
            try
            {
                var subcategoryObj = _unitOfWork.SubCategoryRepository
                    .GetSubCategorybyLocationDepartmentAndCategotySubcategoryID(location_id, department_id, Category_id, SubCategory_id)
                   .AsEnumerable().FirstOrDefault();
                                          
                  
                if (subcategoryObj != null)
                {
                    subcategoryObj.Description = description;
                    _unitOfWork.SubCategoryRepository.Update(subcategoryObj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.Created, description);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, description);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }


        // DELETE: api/Location/5
        [Route("api/v1/location/")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Location locationobj = _unitOfWork.LocationRepository.Get(id);
                if (locationobj != null)
                {
                    _unitOfWork.LocationRepository.Remove(locationobj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, id);
                }              
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // DELETE: api/Departments/5
        [Route("api/v1/location/{location_id}/department/{department_id}")]
        public HttpResponseMessage Delete(int location_id,int department_id)
        {
            try
            {
                Department departmentobj = _unitOfWork.DepartmentRepository.GetDepartmentsbyLocationAndDepartment(location_id,department_id);
                if (departmentobj != null)
                {
                    _unitOfWork.DepartmentRepository.Remove(departmentobj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.OK, location_id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, location_id);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // DELETE: api/Category/5
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}")]
        public HttpResponseMessage Delete(int location_id, int department_id,int Category_id)
        {
            try
            {
                Category categoryobj = _unitOfWork.CategoryRepository.GetCategoriByLocationDepartmentAndCategory(location_id, department_id,Category_id);
                if (categoryobj != null)
                {
                    _unitOfWork.CategoryRepository.Remove(categoryobj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.OK, location_id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, location_id);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // DELETE: api/SubCategory/5
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}/subcategory/{SubCategory_id}")]
        public HttpResponseMessage Delete(int location_id, int department_id, int Category_id,int SubCategory_id)
        {
            try
            {
                var subCategoryObj = _unitOfWork.SubCategoryRepository
                    .GetSubCategorybyLocationDepartmentAndCategotySubcategoryID(location_id, department_id, Category_id, SubCategory_id)
                    .AsEnumerable().FirstOrDefault();
                if (subCategoryObj != null)
                {
                    _unitOfWork.SubCategoryRepository.Remove(subCategoryObj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.OK, location_id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, location_id);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
    }
}
