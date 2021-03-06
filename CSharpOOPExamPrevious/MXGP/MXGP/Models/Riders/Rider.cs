﻿namespace MXGP.Models.Riders
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;
    using System;

    public class Rider : IRider
    {
        public const int MinimumNameLength = 5;
        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinimumNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinimumNameLength));
                }
                this.name = value;
            }
        }
        
        public IMotorcycle Motorcycle {get; private set;}

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;
        
        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle==null)
            {
                throw new ArgumentException(ExceptionMessages.MotorcycleInvalid);
            }
            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
