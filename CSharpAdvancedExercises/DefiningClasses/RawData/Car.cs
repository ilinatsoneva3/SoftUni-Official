namespace RawData
{
    using System;
    using System.Collections.Generic;
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

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tires;
        }

        public Car(List<string> input)
        {
            this.Model = input[0];
            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            this.Engine = new Engine(engineSpeed, enginePower);
            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];
            this.Cargo = new Cargo(cargoWeight, cargoType);
            double tirePressure = 0.0;
            int tireAge = 0;
            List<Tire> listOfTires = new List<Tire>();

            for (int j = 5; j < input.Count; j++)
            {
                if (j % 2 != 0)
                {
                    tirePressure = double.Parse(input[j]);
                }
                else
                {
                    tireAge = int.Parse(input[j]);
                    Tire tire = new Tire(tireAge, tirePressure);
                    listOfTires.Add(tire);
                }
            }
            this.Tire = listOfTires;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; } = 0;

        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tire { get; set; }

        public void Drive(int amountOfKM)
        {
            double fuelNeeded = amountOfKM * this.FuelConsumptionPerKilometer;

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
