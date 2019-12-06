using CodingTest.BAL.Domain;
using CodingTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTest.ServerAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
            {
                unitOfWork.LocationRepository.Add(new Location() { Description = "Hjh" });
                unitOfWork.Complete();
            }

            return View();
        }
    }
}
