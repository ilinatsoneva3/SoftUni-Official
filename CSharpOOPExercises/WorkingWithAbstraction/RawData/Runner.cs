namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Runner
    {
        private List<Car> cars;

        public Runner()
        {
            this.cars = new List<Car>();
        }

        public void Start()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);

                this.cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.CargoType == "fragile" && x.Tires.Any(y => y.TirePressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                this.PrintInfo(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                this.PrintInfo(flamable);
            }
        }

        private void PrintInfo(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private Car CreateCar(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            double firstTirePressure = double.Parse(parameters[5]);
            int firstTireAge = int.Parse(parameters[6]);
            Tire firstTire = new Tire(firstTirePressure, firstTireAge);

            double secondTirePressure = double.Parse(parameters[7]);
            int secondTireAge = int.Parse(parameters[8]);
            Tire secondTire = new Tire(secondTirePressure, secondTireAge);

            double thirdTirePressure = double.Parse(parameters[9]);
            int thirdTireAge = int.Parse(parameters[10]);
            Tire thirdTire = new Tire(thirdTirePressure, thirdTireAge);

            double tireFourPressure = double.Parse(parameters[11]);
            int tireFourAge = int.Parse(parameters[12]);
            Tire fourthTire = new Tire(tireFourPressure, tireFourAge);

            Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, firstTire, secondTire, thirdTire, fourthTire);

            return car;
        }

    }
}
