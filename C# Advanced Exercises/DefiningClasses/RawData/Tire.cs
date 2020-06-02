namespace RawData
{
    public class Tire
    {
        public Tire()
        {
            this.TireAge = 0;
            this.TirePressure = 0.0;
        }
        public Tire(int age, double pressure)
        {
            this.TireAge = age;
            this.TirePressure = pressure;
        }

        public int TireAge { get; set; }
        public double TirePressure { get; set; }
    }
}
