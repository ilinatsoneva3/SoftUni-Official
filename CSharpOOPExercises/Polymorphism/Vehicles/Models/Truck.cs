namespace Vehicles.Models
{
    using System;

    public class Truck : Vehicle
    {
        private const double AdditionalConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AdditionalConsumption;
        }

        public override void Refuel(double liters)
        {
            if ((liters+this.FuelQuantity) >= this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            liters *= 0.95;
            base.Refuel(liters);
        }
    }
}
