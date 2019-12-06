using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CodingTest.DAL;
using CodingTest.BAL.Domain;

namespace CodingTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var unitOfWork = new UnitOfWork(new HierarichyContext()))
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
