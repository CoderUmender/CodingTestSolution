using CodingTest.BAL.Domain;
using CodingTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTest.Web.ServerAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
            {
                // Example1
                // Adding Location via repository..
                unitOfWork.LocationRepository.Add(new Location()
                {
                    Description = "Hyderabad"
                });
                unitOfWork.Complete();

            }

            return View();
        }
    }
}
