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
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 12, 17,00,00));

            Assert.AreEqual(2000, tull.TotalPriceCalculator());
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
            Assert.AreEqual(1000, tull.TotalPriceCalculator());
        }

        [TestMethod]
        public void PriceLightWeightCarWeekday()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1000), new DateTime(2018, 05, 11, 17,00,00));
            Assert.AreEqual(500, tull.TotalPriceCalculator());
        }

        [TestMethod]
        public void EveningPrice()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 11, 18, 01, 00));
            Assert.AreEqual(500, tull.TotalPriceCalculator());
        }

        [TestMethod]
        public void EveningAndWeekendHeavyCar()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 12, 19, 00, 00));
            Assert.AreEqual(2000, tull.TotalPriceCalculator());
        }

        [TestMethod]
        public void EveningPriceMC()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.MC, 1500), new DateTime(2018, 05, 11, 19, 00, 00));
            Assert.AreEqual(350, tull.TotalPriceCalculator());
        }

        [TestMethod]
        public void PriceTruck()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Truck, 1500), new DateTime(2018, 05, 11, 15,00,00));
            Assert.AreEqual(2000, tull.TotalPriceCalculator());
        }
    }
}
