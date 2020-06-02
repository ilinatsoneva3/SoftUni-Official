namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Races;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        public const int MinimumRidersInRace = 3;
        private RiderRepository riders;
        private MotorcycleRepository motors;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.riders = new RiderRepository();
            this.motors = new MotorcycleRepository();
            this.races = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riders.GetByName(riderName);

            if (rider is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var motor = this.motors.GetByName(motorcycleModel);

            if (motor is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motor);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.races.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var rider = this.riders.GetByName(riderName);

            if (rider is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motors.GetByName(model) != null)
            {
                throw new ArgumentException(ExceptionMessages.MotorcycleExists, model);
            }

            Motorcycle motor = null;

            if (type=="Speed")
            {
                motor = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motor = new PowerMotorcycle(model, horsePower);
            }

            this.motors.Add(motor);

            return string.Format(OutputMessages.MotorcycleCreated, motor.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);
            this.races.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (riders.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }
            var rider = new Rider(riderName);
            this.riders.Add(rider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < MinimumRidersInRace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MinimumRidersInRace));
            }

            List<IRider> finalists = race
                .Riders
                .OrderByDescending(m => m.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();
            var firstRider = finalists[0];
            firstRider.WinRace();
            this.races.Remove(race);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, finalists[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, finalists[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, finalists[2].Name, race.Name));

            return sb.ToString().TrimEnd();
        }
    }
}

