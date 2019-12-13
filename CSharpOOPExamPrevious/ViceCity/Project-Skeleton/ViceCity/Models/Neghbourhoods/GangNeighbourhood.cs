namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                foreach (var currentCivilPlayer in civilPlayers)
                {
                    while (currentCivilPlayer.IsAlive && gun.CanFire)
                    {
                        currentCivilPlayer.TakeLifePoints(gun.Fire());
                    }

                    if (!gun.CanFire)
                    {
                        break;
                    }
                }
            }

            foreach (var currentCivilPlayer in civilPlayers)
            {
                if (!currentCivilPlayer.IsAlive)
                {
                    continue;
                }

                foreach (var gun in currentCivilPlayer.GunRepository.Models)
                {                    
                    while (gun.CanFire && mainPlayer.IsAlive)
                    {
                        mainPlayer.TakeLifePoints(gun.Fire());
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}
