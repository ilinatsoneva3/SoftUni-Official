namespace Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Vehicles.Models;

    public class Engine
    {
        private Car car;
        private Truck truck;
        private Bus bus;

        public void Run()
        {
            var vehicleCreator = new VehicleCreator();
            vehicleCreator.Generate();
            this.car = new Car(vehicleCreator.Fuel, vehicleCreator.Consumption, vehicleCreator.TankCapacity);
            vehicleCreator.Generate();
            this.truck = new Truck(vehicleCreator.Fuel, vehicleCreator.Consumption, vehicleCreator.TankCapacity);
            vehicleCreator.Generate();
            this.bus = new Bus(vehicleCreator.Fuel, vehicleCreator.Consumption, vehicleCreator.TankCapacity);

            var numberOfRuns = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRuns; i++)
            {
                var args = Console.ReadLine().Split().ToList();
                var result = string.Empty;

                if (args[0] == "Drive")
                {
                    result = DriveVehicle(args);
                }
                else if (args[0] == "Refuel")
                {
                    try
                    {
                        RefuelVehicle(args);
                    }
                    catch (ArgumentException ae)
                    {
                        result = ae.Message;
                    }                    
                }
                else if (args[0]=="DriveEmpty")
                {
                    this.bus.IsEmpty = false;
                    result = DriveVehicle(args);
                }

                if (result.Any())
                {
                    Console.WriteLine(result);
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }

        private void RefuelVehicle(List<string> args)
        {
            var fuel = double.Parse(args[2]);

            if (args[1] == "Car")
            {
                this.car.Refuel(fuel);
            }
            else if (args[1]=="Truck")
            {
                this.truck.Refuel(fuel);
            }
            else
            {
                this.bus.Refuel(fuel);
            }
        }

        private string DriveVehicle(List<string> args)
        {
            var km = double.Parse(args[2]);

            if (args[1] == "Car")
            {
                return this.car.Drive(km);
            }
            else if (args[1] == "Truck")
            {
                return this.truck.Drive(km);
            }
            else
            {
                return this.bus.Drive(km);
            }
        }
    }
}
