namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private double additionalConsumption = 1.4;
        private double defaultFuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.defaultFuelConsumption = fuelConsumption;
            this.additionalConsumption += fuelConsumption;
        }

        public bool IsEmpty { get; set; }

        public override string Drive(double km)
        {
            if (!IsEmpty)
            {
                this.FuelConsumption = additionalConsumption;
            }
            else
            {
                this.FuelConsumption = defaultFuelConsumption;
            }           
            return base.Drive(km);
        }
    }
}
