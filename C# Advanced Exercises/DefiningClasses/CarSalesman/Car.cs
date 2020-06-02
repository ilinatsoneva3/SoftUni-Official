namespace CarSalesman
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }


        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public static Car CreateCar(List<string> input, List<Engine> engines)
        {
            string model = input[0];
            string typeOfEngine = input[1];
            Engine engine = engines.Where(x => x.Model == typeOfEngine).First();
            Car car = new Car(model, engine);

            if (input.Count == 4)
            {
                car.Weight = input[2];
                car.Color = input[3];
            }
            else if (input.Count == 3)
            {
                bool isEight = int.TryParse(input[2], out int result);

                if (isEight)
                {
                    car.Weight = input[2];
                }
                else
                {
                    car.Color = input[2];
                }
            }

            return car;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(this.Model + ":");
            result.AppendLine($"  {this.Engine.Model}:");
            result.AppendLine($"    Power: {this.Engine.Power}");
            result.AppendLine($"    Displacement: {this.Engine.Displacement}");
            result.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            result.AppendLine($"  Weight: {this.Weight}");
            result.AppendLine($"  Color: {this.Color}");
            return result.ToString().TrimEnd();
        }
    }
}
