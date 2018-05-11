namespace Tullvakt
{
    public class Vehicle
    {
        public VehicleType Type { get; set; }
        public int Weight { get; set; }

        public enum VehicleType
        {
            Car,
            Truck,
            MC,
            EcoCar
        }

        public Vehicle(VehicleType type, int weight)
        {
            Type = type;
            Weight = weight;
        }
    }
}