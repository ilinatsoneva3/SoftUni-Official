namespace ViceCity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;

    public class Controller : IController
    {
        private readonly MainPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (nameof(Pistol)==type)
            {
                gun = new Pistol(name);
            }
            else if (nameof(Rifle)==type)
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.guns.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (!this.guns.Any())
            {
                return "There are no guns in the queue!";
            }
            else if (name == "Vercetti")
            {
                var gun = this.guns.First();
                this.mainPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (this.civilPlayers.FirstOrDefault(p=>p.Name==name)==null)
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                var gun = this.guns.First();
                var civilPlayer = this.civilPlayers.First(p => p.Name == name);
                civilPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            this.civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var sb = string.Empty;
            int mainPlayerLifePoints = this.mainPlayer.LifePoints;
            var civilPlayersLifePoints = this.civilPlayers.Sum(p => p.LifePoints);

            this.gangNeighbourhood.Action(mainPlayer, civilPlayers);

            int mainPlayerLifePointsAfterFight = this.mainPlayer.LifePoints;
            var civilPlayersLifePointsAfterFight = this.civilPlayers.Sum(p => p.LifePoints);
            int aliveCivilPlayers = this.civilPlayers.Count(p => p.IsAlive);

            if (mainPlayerLifePoints==mainPlayerLifePointsAfterFight
                && civilPlayersLifePoints == civilPlayersLifePointsAfterFight)
            {
               sb = "Everything is okay!";
            }
            else
            {
                sb = "A fight happened:" + Environment.NewLine 
                    + $"Tommy live points: {mainPlayerLifePointsAfterFight}!" + Environment.NewLine
                    + $"Tommy has killed: {this.civilPlayers.Count - aliveCivilPlayers} players!" + Environment.NewLine
                    + $"Left Civil Players: {aliveCivilPlayers}!";
            }

            return sb;
        }
    }
}
