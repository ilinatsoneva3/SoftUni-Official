namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var carList = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var input = Console.ReadLine().Split().ToList();
                var car = new Car(input);
                carList.Add(car);
            }

            var criteria = Console.ReadLine();

            if (criteria == "fragile")
            {
                carList
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tire.Any(p => p.TirePressure < 1))
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Model));
            }
            else
            {
                carList
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Model));
            }
        }
    }
}
