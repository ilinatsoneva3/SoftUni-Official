namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public class Meteorologist : Astronaut, IAstronaut
    {
        public const int InitialOxygen = 90;

        public Meteorologist(string name) 
            : base(name, InitialOxygen)
        {
        }
    }
}
