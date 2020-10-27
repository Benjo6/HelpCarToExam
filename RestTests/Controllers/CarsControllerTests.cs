using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rest.Controllers.Tests
{
    [TestClass()]
    public class CarsControllerTests
    {
        CarsController cmd = new CarsController();
        [TestMethod()]
        public void GetTest()
        {
            Assert.AreEqual(3 ,cmd.Get().Count());
        }

        [TestMethod()]
        public void GetTest1()
        {
            Assert.AreEqual(2, cmd.Get(2).Id);
            Assert.IsNotNull(cmd.Get(2));
        }

        [TestMethod()]
        public void PostTest()
        {
            Car i = new Car(4, "string", "string", 10);
            cmd.Post(i);
            Assert.AreEqual(4, cmd.Get().Count());
        }

        [TestMethod()]
        public void PutTest()
        {
            Car i = new Car(1, "string", "string", 50);
            cmd.Put(1, i);
            Assert.AreEqual(50, cmd.Get(1).Price);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            cmd.Delete(1);
            Assert.AreEqual(2, cmd.Get().Count());
        }

        [TestMethod()]
        public void VendorToGetByTest()
        {
            Assert.AreEqual(1, cmd.GetFromVendor("Vol").Count());
        }
    }
}