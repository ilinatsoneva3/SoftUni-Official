namespace SpeedRacing
{
    using System;
    public class Car
    {
        public Car()
        {
            this.Model = Model;
            this.FuelAmount = FuelAmount;
            this.FuelConsumptionPerKilometer = FuelConsumptionPerKilometer;
        }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; } = 0;

        public void Drive(int amountOfKM)
        {
            var fuelNeeded = amountOfKM * this.FuelConsumptionPerKilometer;

            if (fuelNeeded > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.TraveledDistance += amountOfKM;
                this.FuelAmount -= fuelNeeded;
            }
        }
    }
}
