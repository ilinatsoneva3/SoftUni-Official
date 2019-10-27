namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var input = Console.ReadLine().Split();
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumption = double.Parse(input[2]);
                var car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                var currentCommand = command.Split();
                var model = currentCommand[1];
                var distance = int.Parse(currentCommand[2]);
                var currentCar = cars.Where(x => x.Model == model).First();
                currentCar.Drive(distance);
                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}
