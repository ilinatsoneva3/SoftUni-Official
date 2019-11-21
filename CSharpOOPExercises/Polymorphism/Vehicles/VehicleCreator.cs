namespace Vehicles
{
    using System;
    using System.Linq;
    public class VehicleCreator
    {
        public double Fuel { get; private set; }
        public double Consumption { get; private set; }

        public double TankCapacity { get; private set; }

        public void Generate()
        {
            var information = Console.ReadLine().Split().ToList();
            var fuelQuantity = double.Parse(information[1]);
            var consumption = double.Parse(information[2]);
            var capacity = double.Parse(information[3]);
            this.Fuel = fuelQuantity;
            this.Consumption = consumption;
            this.TankCapacity = capacity;
        }
    }
}
