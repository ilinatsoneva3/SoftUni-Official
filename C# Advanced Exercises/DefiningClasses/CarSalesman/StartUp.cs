namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            var numOfEngines = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();

            for (int i = 0; i < numOfEngines; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var engine = Engine.CreateEngine(input);
                engines.Add(engine);
            }

            var cars = new List<Car>();
            var numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var car = Car.CreateCar(input, engines);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
