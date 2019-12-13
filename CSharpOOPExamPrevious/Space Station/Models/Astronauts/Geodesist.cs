namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public class Geodesist : Astronaut, IAstronaut
    {
        public const int InitialOxygen = 50;
        public Geodesist(string name) 
            : base(name, InitialOxygen)
        {
        }
    }
}
