using System;
using System.Collections.Generic;

//TODO klasser har substantiv, metoder verb.
namespace Tullvakt
{
    public class Tull
    {
        public Vehicle Vehicle { get; set; }
        public DateTime DateTime { get; set; }

        //TODO döp om till PassingTollDateTime
        public Tull(Vehicle vehicle, DateTime dateTime)
        {
            Vehicle = vehicle;
            DateTime = dateTime; 
        }
        //TODO underscore, fast följ rescharper, kolla på triangeln över scrollen.
        //TODO Gör alla metoder utom calculatePrice till private. Ha så mycket private som möjligt.
        //TODO decimal ist för double

        private const int LightWeightCarPrice = 500;
        private const int HeavyCarPrice = 1000;
        const double EveningPriceAdjustment = 0.5;
        private const int TruckPrice = 2000;
        const double PriceAdjustmentForMc = 0.7;
        private const double WeekendPriceAdjustment = 2;

        //TODO kan ha krav i metoderna isWeekend och isEvening så att de vet vad som ska hända om det är kväll eller helg.
        //TODO ta in Vehicle och DateTime i metoden för att slippa skapa tull i varje test.
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
                price = basePrice * WeekendPriceAdjustment;
            }
            
            if (isEvening)
            {
                price = basePrice * EveningPriceAdjustment;
            }
            return price;
        }

        //TODO returnera så fort som möjligt (i övriga metoder också)
        private double BasePriceCalculator()
        {
            double basePrice = 0;
            if (Vehicle.Type == Vehicle.VehicleType.EcoCar)
                return basePrice = 0;
            if (Vehicle.Type == Vehicle.VehicleType.Car && Vehicle.Weight > 1000)
                return basePrice = HeavyCarPrice;
            if (Vehicle.Type == Vehicle.VehicleType.Car && Vehicle.Weight <= 1000)
                return basePrice = LightWeightCarPrice;
            if (Vehicle.Type == Vehicle.VehicleType.Truck)
                return basePrice = TruckPrice;
            if (Vehicle.Type == Vehicle.VehicleType.MC && Vehicle.Weight > 1000)
                return basePrice = HeavyCarPrice * PriceAdjustmentForMc;
            if (Vehicle.Type == Vehicle.VehicleType.MC && Vehicle.Weight <= 1000)
                return basePrice = LightWeightCarPrice * PriceAdjustmentForMc;
            return basePrice;
        }
        private bool IsWeekend()
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

        private bool IsEvening()
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