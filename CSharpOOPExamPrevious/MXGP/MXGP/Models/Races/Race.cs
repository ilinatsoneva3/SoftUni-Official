namespace MXGP.Models.Races
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Race : IRace
    {
        public const int MinimumNameLength = 5;
        public const int MinimumLaps = 1;
        private string name;
        private int laps;
        private ICollection<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.laps = laps;
            this.riders = new List<IRider>();
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

        public int Laps 
        {
            get => this.laps;
            private set
            {
                if (value<MinimumLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps,MinimumLaps));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.ToList().AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider==null)
            {
                throw new ArgumentNullException(ExceptionMessages.RiderInvalid);
            }
            else if (!rider.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }
            else if (this.riders.Any(r=>r.Name==rider.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
