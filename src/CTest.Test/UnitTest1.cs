using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTest.BAL.Domain;
using CTest.BAL.Repositories;
using CTest.DAL.Repositories;
using CTest.DAL;

namespace CTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var unitOfWork = new UnitOfWork(new HierarichyContext("name=HierarichyContext")))
            {
                // Example1
                // Adding Location via repository..
                unitOfWork.LocationRepository.Add(new Location() {
                    Description = "Hyderabad"
                });
                unitOfWork.Complete();
               
            }

        }
    }
}
