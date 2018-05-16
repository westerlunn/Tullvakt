using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tullvakt;

namespace TullTest
{
    //TODO bättre namn på testerna. Man ska se exakt vad som testas.
    //TODO magic numbers i testmetoderna. Deklarera variablerna.
    [TestClass]
    public class TestRulesForTull
    {
        [TestMethod]
        public void TestWeekendPriceForHeavyCar()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 12, 17,00,00));

            Assert.AreEqual(2000, tull.TotalPriceCalculator());
        }
        [TestMethod]
        public void TestWeekendPrice()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Car, 1500), new DateTime(2018, 05, 11,19,00,00));
            Assert.IsFalse(tull.IsWeekend());
        }

        [TestMethod]
        public void EcoCarPriceTest()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.EcoCar, 1500), new DateTime(2018, 05, 11, 17,00,00));
            Assert.AreEqual(0, tull.TotalPriceCalculator());
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
        public void MCPrice()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.MC, 900), new DateTime(2018, 05, 11, 15, 00, 00));
            Assert.AreEqual(350, tull.TotalPriceCalculator());
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

        [TestMethod]
        public void IsWeekendTest()
        {
            Tull tull = new Tull(new Vehicle(Vehicle.VehicleType.Truck, 1500), new DateTime(2018, 05, 13, 19, 00, 00));
            Assert.IsTrue(tull.IsWeekend());
        }
    }
}
