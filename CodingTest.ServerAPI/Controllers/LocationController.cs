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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                log.Error($"Location Get excution started" + DateTime.Now);
                locations = _unitOfWork.LocationRepository.GetLocation().ToList();                                            
                return  Request.CreateResponse(HttpStatusCode.OK, locations);
               
            }
            catch(Exception ex)
            {
                log.Error($"Location Get Error" + ex);
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }  
        }
        // GET: api/Location/5
        [Route("api/v1/location/{location_id}/department/")]
        public HttpResponseMessage Get(int location_id)
        {
            try
            {
                log.Error($"Department Get excution started" + DateTime.Now);
                List<DepartmentVM > departments  = new List<DepartmentVM>();            
                departments = _unitOfWork.DepartmentRepository.GetDepartmentsbyLocation(location_id).ToList();               
                return Request.CreateResponse(HttpStatusCode.OK, departments);
            }
            catch (Exception ex)
            {
                log.Error($"Department Get Error" +ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ErrorOccured! Please Contact admin");
            }
        }
        [Route("api/v1/location/{location_id}/department/{department_id}/category")]
        public HttpResponseMessage Get(int location_id,int department_id)
        {
            try
            {
                log.Error($"Category Get excution started" + DateTime.Now);
                List<CategoryVM> categories = new List<CategoryVM>();
                 categories = _unitOfWork.CategoryRepository.GetCategoriesbyLocationANdDepartment(location_id,department_id).ToList();              
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {
                log.Error($"Category Get Error" + ex);
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }
        }
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{category_id}/subcategory")]
        public HttpResponseMessage Get(int location_id, int department_id,int category_id)
        {
            try
            {
                log.Error($"SubCategory Get excution started" + DateTime.Now);
                List<SubCategoryVM> subCategories = new List<SubCategoryVM>();       
                subCategories = _unitOfWork.SubCategoryRepository.GetSubCategorybyLocationDepartmentAndCategoty(location_id, department_id,category_id).ToList();            
                return Request.CreateResponse(HttpStatusCode.OK, subCategories);
            }
            catch (Exception ex)
            {
                log.Error($"SubCategory Error" + ex);
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
            }
        }
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{category_id}/subcategory/{subcategory_id}")]
        public HttpResponseMessage Get(int location_id, int department_id, int category_id,int subcategory_id)
        {
            try
            {
                log.Error($"SubCategory by subcategory Get excution started" + DateTime.Now);
                List<SubCategoryVM> subCategories = new List<SubCategoryVM>();          
                subCategories = _unitOfWork.SubCategoryRepository.GetSubCategorybyLocationDepartmentAndCategotySubcategory(location_id, department_id, category_id,subcategory_id).ToList();            
                return Request.CreateResponse(HttpStatusCode.OK, subCategories);
            }
            catch (Exception ex)
            {
                log.Error($"SubCategory Error" + ex);
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
                log.Error($"Location Post Execution started" + DateTime.Now);
                Location locationobj = new Location();
                locationobj.Description = description.Description;
                _unitOfWork.LocationRepository.Add(locationobj);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, description);
            }
            catch(Exception ex)
            {
                log.Error($"Location PostError" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while adding record");
            }

        }
        //Post: Api/Department  
        [Route("api/v1/department/")]
        public HttpResponseMessage Post(Department department)
        {
            //Adding Location..
            try
            {
                log.Error($"Department Post Execution started" + DateTime.Now);
                Department departmentobj = new Department();
                departmentobj.Description = department.Description;
                departmentobj.Location_ID = department.Location_ID;
                _unitOfWork.DepartmentRepository.Add(departmentobj);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, department.Description);
            }
            catch (Exception ex)
            {
                log.Error($"Dept Post Execution error" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while adding record");
            }

        }
        //Post: Api/Category  
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{description}")]
        public HttpResponseMessage Post(Category category)
        {
            //Adding Category..
            try
            {
                log.Error($"Category Post Execution started" + DateTime.Now);
                Category categoryObj   = new Category();
                categoryObj.Description = category.Description;
                categoryObj.Department_ID =category.Department_ID;
                _unitOfWork.CategoryRepository.Add(categoryObj);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, category);
            }
            catch (Exception ex)
            {
                log.Error($"Category Post Execution Error" +ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while adding record");
            }

        }
        //Post: Api/SubCategory  
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}/SubCategory/{description}")]
        public HttpResponseMessage Post(SubCategory subCategory)
        {
            //Adding SubCategory..
            try
            {
                log.Error($"SubCategory Post Execution started" + DateTime.Now);
                SubCategory subcategoryObj = new SubCategory();
                subcategoryObj.Description = subCategory.Description;
                subcategoryObj.Category_Id = subCategory.Category_Id;
                _unitOfWork.SubCategoryRepository.Add(subcategoryObj);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, subCategory);
            }
            catch (Exception ex)
            {
                log.Error($"SUbCategory Post Execution Error" + ex);
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
                log.Error($"Location Put Execution started" + DateTime.Now);
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
                log.Error($"Location Put Execution error" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // PUT: api/Department/5
        [HttpPut]
        [Route("api/v1/department/")]
        public HttpResponseMessage Put(Department department)
        {
            try
            {
                Department departmentobj = _unitOfWork.DepartmentRepository.GetDepartmentsbyLocationAndDepartment(department.Location_ID,department.Department_Id);
                if (departmentobj != null)
                {             
                    departmentobj.Description = department.Description;                   
                    _unitOfWork.DepartmentRepository.Update(departmentobj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.Created, department.Description);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, department);
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
        public HttpResponseMessage Put(Category category,int categoryId)
        {
            try
            {
                log.Error($"Category Put Execution started" + DateTime.Now);
                Category categoryObj = _unitOfWork.CategoryRepository.GetCategoriByLocationDepartmentAndCategory(categoryId, category.Department_ID,category.Category_Id);
                if (categoryObj != null)
                {
                    categoryObj.Description = category.Description;
                    _unitOfWork.CategoryRepository.Update(categoryObj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.Created, category);
                }
                else
                {
                  
                    return Request.CreateResponse(HttpStatusCode.NotFound, category);
                }
            }
            catch (Exception ex)
            {
                log.Error($"Category Put Execution error" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // PUT: api/SubCategory/5
        [HttpPut]
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}/subcategory/{SubCategory_id}/{description}")]
        public HttpResponseMessage Put(SubCategory category,int locationid,int departmentid)
        {
            try
            {
                log.Error($"SubCategory Put Execution Started" + DateTime.Now);
                var subcategoryObj = _unitOfWork.SubCategoryRepository
                    .GetSubCategorybyLocationDepartmentAndCategotySubcategoryID(locationid, departmentid, category.Category_Id, category.SubCategory_Id)
                   .AsEnumerable().FirstOrDefault();
                                          
                  
                if (subcategoryObj != null)
                {
                    subcategoryObj.Description = category.Description;
                    _unitOfWork.SubCategoryRepository.Update(subcategoryObj);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.Created, category);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, category);
                }
            }
            catch (Exception ex)
            {
                log.Error($"SubCategory Put Execution error" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }


        // DELETE: api/Location/5
        [Route("api/v1/location/")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                log.Error($"Location Delete Execution Started" + DateTime.Now);
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
                log.Error($"Location Delete Execution error" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // DELETE: api/Departments/5
        [Route("api/v1/location/{location_id}/department/{department_id}")]
        public HttpResponseMessage Delete(int location_id,int department_id)
        {
            try
            {
                log.Error($"Depatment Delete Execution Started" + DateTime.Now);
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
                log.Error($"Department Delete Execution error" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // DELETE: api/Category/5
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}")]
        public HttpResponseMessage Delete(int location_id, int department_id,int Category_id)
        {
            try
            {
                log.Error($"Category Delete Execution Started" + DateTime.Now);
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
                log.Error($"Category Delete Execution error" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
        // DELETE: api/SubCategory/5
        [Route("api/v1/location/{location_id}/department/{department_id}/category/{Category_id}/subcategory/{SubCategory_id}")]
        public HttpResponseMessage Delete(int location_id, int department_id, int Category_id,int SubCategory_id)
        {
            try
            {
                log.Error($"SubCategory Delete Execution Started" + DateTime.Now);
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
                log.Error($"Subcategory Delete Execution error" + ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured while Updating record");
            }
        }
    }
}
