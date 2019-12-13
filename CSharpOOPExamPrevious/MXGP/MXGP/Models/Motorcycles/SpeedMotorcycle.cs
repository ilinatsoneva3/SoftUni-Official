namespace MXGP.Models.Motorcycles
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;
    using System;

    public class SpeedMotorcycle : Motorcycle, IMotorcycle
    {
        public const int MinimumHorsePower = 50;
        public const int MaximumHorsePower = 69;
        public const double InitialCubicCentimeters = 125;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MinimumHorsePower || value > MaximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
    }
}
