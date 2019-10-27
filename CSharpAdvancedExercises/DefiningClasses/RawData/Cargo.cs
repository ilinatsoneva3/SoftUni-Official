namespace RawData
{
    public class Cargo
    {
        public Cargo()
        {
            this.CargoWeight = 0;
            this.CargoType = string.Empty;
        }
        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
