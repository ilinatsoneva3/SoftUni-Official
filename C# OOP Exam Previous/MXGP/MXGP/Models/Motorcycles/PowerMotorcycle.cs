namespace MXGP.Models.Motorcycles
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;
    using System;

    public class PowerMotorcycle : Motorcycle, IMotorcycle
    {
        public const int MinimumHorsePower = 70;
        public const int MaximumHorsePower = 100;
        public const double InitialCubicCentimeters = 450;
        private int horsePower;
                
        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value<MinimumHorsePower||value>MaximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
    }
}
