namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public string Name { get; set; }

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator) => this.gladiators.Add(gladiator);

        public void Remove(string name)
        {
            Gladiator gladiator = this.gladiators.Where(x => x.Name == name).FirstOrDefault();
            this.gladiators.Remove(gladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(x => x.GetStatPower()).First();
            return gladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(x => x.GetWeaponPower()).First();
            return gladiator;
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(x => x.GetTotalPower()).First();
            return gladiator;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.gladiators.Count} gladiators are participating.";
        }
    }
}
