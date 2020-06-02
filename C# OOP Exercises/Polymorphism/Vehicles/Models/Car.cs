namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AdditionalConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AdditionalConsumption;
        }
    }
}
