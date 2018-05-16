namespace Tullvakt
{
    public class Vehicle
    {
        public VehicleType Type { get; set; }
        public int Weight { get; set; }

        //TODO kicka ut VehicleType, den är gömd här. Egen klass?
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