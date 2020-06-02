namespace Vehicles.Models
{
    using System;
    public abstract class Vehicle
    {
        private double distance;
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public virtual string Drive(double km)
        {
            double fuelNeeded = this.FuelConsumption * km;

            if (fuelNeeded >= this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling"; //this needs refactoring
            }
            else
            {
                this.distance += km;
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {km} km";
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double finalFuel = this.FuelQuantity + liters;

            if (finalFuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name + $": {Math.Round(this.FuelQuantity, 2, MidpointRounding.AwayFromZero):F2}";
        }
    }
}
