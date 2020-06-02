namespace Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string name)
        {
            this.DriverName = name;
        }

        public string DriverName { get; private set; }
        public string Model { get; private set; } = "488-Spider";

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            //488-Spider/Brakes!/Gas!/George
            return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.DriverName}";
        }
    }
}
