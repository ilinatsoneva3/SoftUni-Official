namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            int sum = this.Stat.Sum() + this.Weapon.Sum();
            return sum;
        }

        public int GetWeaponPower()
        {
            return this.Weapon.Sum();
        }

        public int GetStatPower()
        {
            return this.Stat.Sum();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.GetTotalPower()}");
            sb.AppendLine($"  Weapon Power: {this.GetWeaponPower()}");
            sb.AppendLine($"  Stat Power: {this.GetStatPower()}");
            return sb.ToString().TrimEnd();
        }
    }
}
