namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;
    using System.Collections.Generic;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(a=>a.Oxygen>0))
            {
                while (planet.Items.Any())
                {
                    string currentITem = planet.Items.First();
                    astronaut.Breath();
                    planet.Items.Remove(currentITem);
                    astronaut.Bag.Items.Add(currentITem);

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }

                if (!planet.Items.Any())
                {
                    break;
                }
            }
        }
    }
}
