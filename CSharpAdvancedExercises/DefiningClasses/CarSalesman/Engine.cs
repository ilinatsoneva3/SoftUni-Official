namespace CarSalesman
{
    using System.Collections.Generic;
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }
        
        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public static Engine CreateEngine(List<string> input)
        {            
            string model = input[0];
            int power = int.Parse(input[1]);
            Engine engine = new Engine(model, power);

            if (input.Count == 4)
            {
                engine.Displacement = input[2];
                engine.Efficiency = input[3];
            }
            else if (input.Count == 3)
            {
                bool isDisplacement = int.TryParse(input[2], out int result);

                if (isDisplacement)
                {
                    engine.Displacement = input[2];
                }
                else
                {
                    engine.Efficiency = input[2];
                }
            }

            return engine;
        }
    }
}
