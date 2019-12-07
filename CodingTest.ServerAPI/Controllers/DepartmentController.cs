using CodingTest.BAL;
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
    public class DepartmentController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public DepartmentController()
        {
            _unitOfWork = new UnitOfWork(new HierarichyContext());
        }
        // GET: api/Department
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Department/5
        [Route("api/v1/location/{location_id}/department/")]
        public HttpResponseMessage Get(int location_id)
        {
            try
            {
                List<DepartmentVM> departments = new List<DepartmentVM>();
                departments = _unitOfWork.DepartmentRepository.GetDepartmentsbyLocation(location_id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, departments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ErrorOccured! Please Contact admin");
            }
        }

        // POST: api/Department
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Department/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Department/5
        public void Delete(int id)
        {
        }
    }
}
