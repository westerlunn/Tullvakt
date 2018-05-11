using System;
using System.Collections.Generic;

namespace Tullvakt
{
    public class Tull
    {
        public Vehicle Vehicle { get; set; }
        public DateTime DateTime { get; set; }

        public Tull(Vehicle vehicle, DateTime dateTime)
        {
            Vehicle = vehicle;
            DateTime = dateTime;
        }

        private const int lightWeightCarPrice = 500;
        private const int heavyCarPrice = 1000;
        const double eveningPriceAdjustment = 0.5;
        private const int truckPrice = 2000;
        const double priceAdjustmentForMC = 0.7;
        private const double weekendPriceAdjustment = 2;

        public double TotalPriceCalculator()
        {
            
            double price = 0;
            double basePrice = BasePriceCalculator();
            bool isWeekend = IsWeekend();
            bool isEvening = IsEvening();
            if (!isEvening && !isWeekend)
            {
                price = basePrice;
            }
            
            if (isWeekend)
            {
                price = basePrice * weekendPriceAdjustment;
            }
            
            if (isEvening)
            {
                price = basePrice * eveningPriceAdjustment;
            }
            return price;
        }

        public double BasePriceCalculator()
        {
            double basePrice = 0;
            if (Vehicle.Type == Vehicle.VehicleType.EcoCar)
            {
                basePrice = 0;
            }
            else if (Vehicle.Type == Vehicle.VehicleType.Car && Vehicle.Weight > 1000)
            {
                basePrice = heavyCarPrice;
            }
            else if (Vehicle.Type == Vehicle.VehicleType.Car && Vehicle.Weight <= 1000)
            {
                basePrice = lightWeightCarPrice;
            }
            else if (Vehicle.Type == Vehicle.VehicleType.Truck)
            {
                basePrice = truckPrice;
            }
            else if (Vehicle.Type == Vehicle.VehicleType.MC && Vehicle.Weight > 1000)
            {
                basePrice = heavyCarPrice * priceAdjustmentForMC;
            }
            else if (Vehicle.Type == Vehicle.VehicleType.MC && Vehicle.Weight <= 1000)
            {
                basePrice = lightWeightCarPrice * priceAdjustmentForMC;
            }

                return basePrice;
        }
        public bool IsWeekend()
        {
            bool isWeekend;
            if (DateTime.DayOfWeek == DayOfWeek.Saturday || DateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                isWeekend = true;
            }
            else
            {
                isWeekend = false;
            }
            return isWeekend;
        }

        public bool IsEvening()
        {
            bool isWeekend = IsWeekend();
            bool isEvening;
            if (isWeekend)
            {
                isEvening = false;
            }
            else if (DateTime.Hour >= 18 || DateTime.Hour < 6)
            {
                isEvening = true;
            }
            else
            {
                isEvening = false;
            }

            return isEvening;
        }
    }
}