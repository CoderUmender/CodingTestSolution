using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodingTest.BAL;
using CodingTest.BAL.Domain;
using CodingTest.BAL.Repositories;
using CodingTest.BAL.ViewMoels;
using CodingTest.ServerAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Codingtest.Test
{
    [TestClass]
    public class LocationTest
    {
      
        private LocationController _locationController;
        private Mock<IUnitOfWork> _mock;
        private HttpResponseMessage _httpResponseMessage;
      
        public LocationTest()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            //mocking reposss
            Mock<ILocationRepository> moclLocationrepo = new Mock<ILocationRepository>();
            Mock<IDepartmentRepository> mocDepartment = new Mock<IDepartmentRepository>();
            Mock<ICategoryRepository> mocCategory = new Mock<ICategoryRepository>();
            Mock<ISubCategoryRepository> mocSubCategory = new Mock<ISubCategoryRepository>();

          
            List<Location> locations = new List<Location>();         
            IQueryable<Location> queryablelocations = locations.AsQueryable();
            moclLocationrepo.Setup(x => x.GetLocation()).Returns(queryablelocations);

            List<DepartmentVM> departments = new List<DepartmentVM>();
            IQueryable<DepartmentVM> queryabledepts = departments.AsQueryable();
            List<Department> departments1 = new List<Department>();
            IQueryable<Department> queryabledepts1 = departments1.AsQueryable();

            mocDepartment.Setup(x => x.GetDepartmentsbyLocation(1)).Returns(queryabledepts);
            mocDepartment.Setup(x => x.GetDepartmentsbyLocationAndDepartment(2,1)).Returns(departments1.AsQueryable().FirstOrDefault());

            List<CategoryVM > Category = new List<CategoryVM>();
            IQueryable<CategoryVM> queryableCategory = Category.AsQueryable();
            mocCategory.Setup(x => x.GetCategoriesbyLocationANdDepartment(1,2)).Returns(queryableCategory);

            IQueryable<Category> cat = new List<Category>().AsQueryable();
            mocCategory.Setup(x => x.GetCategoriByLocationDepartmentAndCategory(1, 2,2)).Returns(cat.FirstOrDefault());


            List<SubCategoryVM> subCategoryVMs = new List<SubCategoryVM>();
            IQueryable<SubCategoryVM> queryablesubCategoryVMs = subCategoryVMs.AsQueryable();
            mocSubCategory.Setup(x => x.GetSubCategorybyLocationDepartmentAndCategoty(1,2,3)).Returns(queryablesubCategoryVMs);

            IQueryable<SubCategory> subcats =new List<SubCategory>().AsQueryable();
            mocSubCategory.Setup(x => x.GetSubCategorybyLocationDepartmentAndCategotySubcategory(1,2,3,4)).Returns(queryablesubCategoryVMs);

            mocSubCategory.Setup(x => x.GetSubCategorybyLocationDepartmentAndCategotySubcategoryID(1, 2, 3, 4)).Returns(subcats);

            // Set Up Repos
            mock.Setup(c=>c.LocationRepository).Returns(moclLocationrepo.Object);
            mock.Setup(c => c.DepartmentRepository).Returns(mocDepartment.Object);
            mock.Setup(c => c.CategoryRepository).Returns(mocCategory.Object);
            mock.Setup(c => c.SubCategoryRepository).Returns(mocSubCategory.Object);

            _locationController = new LocationController(mock.Object);
           _locationController.Request = new HttpRequestMessage();
            _locationController.Configuration = new HttpConfiguration();
            _mock = mock;
            
        }
        [TestMethod]
        public void LocationGetTest()
        {
            //[Route("api/v1/location/")]
            _httpResponseMessage = _locationController.Get();
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.OK, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void LocationDepartmentGetTest()
        {
            //api / v1 / location /{ location_id}/ department /
            // inputs//
            int LocationID = 0;
            _httpResponseMessage = _locationController.Get(LocationID);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.OK, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void LocationDepartmentbyLocationAnddept()
        {
            //api / v1 / location /{ location_id}/ department /
            // inputs//
            int LocationID = 0;
            int Department = 0;
            _httpResponseMessage = _locationController.Get(LocationID,Department);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.OK, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void LocationGetbyLocationAnddeptCategory()
        {
            //api / v1 / location /{ location_id}/ department /
            // inputs//
            int LocationID = 0;
            int Department = 0;
            int Category = 0;
            _httpResponseMessage = _locationController.Get(LocationID, Department, Category);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.OK, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void LocationGetbyLocationAnddeptCategoryAndSubCatogory()
        {
            //api / v1 / location /{ location_id}/ department /
            // inputs//
            int LocationID = 0;
            int Department = 0;
            int Category = 0;
            int SubCategoryID = -1;
            _httpResponseMessage = _locationController.Get(LocationID, Department, Category, SubCategoryID);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.OK, _httpResponseMessage.StatusCode);
        }

        [TestMethod]
        public void LocationPostTest()
        {
            //api / v1 / location /{ location_id}/ department /
           Location location=new Location();
            _httpResponseMessage = _locationController.Post(location);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.Created, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void DepartmentPostTest()
        {
            //api / v1 / location /{ location_id}/ department /
            Department  department = new Department();
            _httpResponseMessage = _locationController.Post(department);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.Created, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void CategoryPostTest()
        {
            //api / v1 / location /{ location_id}/ department /
            Category cat = new Category();
            _httpResponseMessage = _locationController.Post(cat);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.Created, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void SubCategoryPostTest()
        {
            //api / v1 / location /{ location_id}/ department /
            SubCategory subCategory = new SubCategory();
            _httpResponseMessage = _locationController.Post(subCategory );
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = true;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.Created, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void LocationPut()
        {
            //api / v1 / location /{ location_id}/ department /
            Location  location = new Location();
            _httpResponseMessage = _locationController.Put(location);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = false;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.NotFound, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void DepartmentPut()
        {
            //api / v1 / location /{ location_id}/ department /
            Department dept = new Department();
            
            _httpResponseMessage = _locationController.Put(dept);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = false;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.NotFound, _httpResponseMessage.StatusCode);
        }

        [TestMethod]
        public void CategorytPut()
        {
            //api / v1 / location /{ location_id}/ department /
           Category cat = new Category();

            _httpResponseMessage = _locationController.Put(cat,1);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = false;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.NotFound, _httpResponseMessage.StatusCode);
        }

        [TestMethod]
        public void SubCategorytPut()
        {
            //api / v1 / location /{ location_id}/ department /
            SubCategory sub = new SubCategory();

            _httpResponseMessage = _locationController.Put(sub,2,3);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = false;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.NotFound, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void LocationDelete()
        {
            //api / v1 / location /{ location_id}/ department /
            SubCategory sub = new SubCategory();

            _httpResponseMessage = _locationController.Delete(1);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = false;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.NotFound, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void DepartmentDelete()
        {
            //api / v1 / location /{ location_id}/ department /
            SubCategory sub = new SubCategory();

            _httpResponseMessage = _locationController.Delete(1,2);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = false;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.NotFound, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void catDelete()
        {
            //api / v1 / location /{ location_id}/ department /
            SubCategory sub = new SubCategory();

            _httpResponseMessage = _locationController.Delete(1, 2,3);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = false;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.NotFound, _httpResponseMessage.StatusCode);
        }
        [TestMethod]
        public void SubCatDelete()
        {
            //api / v1 / location /{ location_id}/ department /
            SubCategory sub = new SubCategory();

            _httpResponseMessage = _locationController.Delete(1, 2,3);
            var actul = _httpResponseMessage.IsSuccessStatusCode;
            var expected = false;
            Assert.AreEqual(expected, actul);
            Assert.AreEqual(HttpStatusCode.NotFound, _httpResponseMessage.StatusCode);
        }
    }
}
