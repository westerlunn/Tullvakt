using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tullvakt;

namespace TullTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWeekendForHeavyCar()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 12));

            Assert.AreEqual(2000, tull.CalculatePrice());
        }
        [TestMethod]
        public void TestWeekend()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 11));
            Assert.IsFalse(tull.IsWeekend());
        }

        [TestMethod]
        public void EcoCarTest()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 11));
            Assert.AreEqual(1000, tull.CalculatePrice());
        }

        [TestMethod]
        public void PriceLightWeightCarWeekday()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1000), new DateTime(2018, 05, 11));
            Assert.AreEqual(500, tull.CalculatePrice());
        }

        [TestMethod]
        public void EveningPrice()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 11, 18, 01, 00));
            Assert.AreEqual(500, tull.CalculatePrice());
        }
    }
}
