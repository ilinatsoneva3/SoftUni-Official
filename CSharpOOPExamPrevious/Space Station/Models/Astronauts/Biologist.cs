namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using System;

    public class Biologist : Astronaut, IAstronaut
    {
        public const int InitialOxygen = 70;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen = Math.Max(this.Oxygen - 5,0);
        }
    }
}
