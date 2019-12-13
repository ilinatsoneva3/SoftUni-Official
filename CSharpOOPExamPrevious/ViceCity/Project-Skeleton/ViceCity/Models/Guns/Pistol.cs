namespace ViceCity.Models.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViceCity.Models.Guns.Contracts;

    public class Pistol : Gun, IGun
    {
        public const int InitialBulletsPerBarrel = 10;
        public const int InitialTotalBullets = 100;
        public const int CountOfBulletsPerTrigger = 1;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel<CountOfBulletsPerTrigger)
            {
                this.Reload(InitialBulletsPerBarrel);
            }

            int result = this.DecreaseBullets(CountOfBulletsPerTrigger);
            return result;
        }
    }
}
