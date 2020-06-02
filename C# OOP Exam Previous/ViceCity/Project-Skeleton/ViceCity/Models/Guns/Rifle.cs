namespace ViceCity.Models.Guns
{
    using ViceCity.Models.Guns.Contracts;

    public class Rifle : Gun, IGun
    {
        public const int InitialBulletsPerBarrel = 50;
        public const int InitialTotalBulletsPerBarrel = 500;
        public const int CountOfBulletsPerTrigger = 5;

        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBulletsPerBarrel)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel < CountOfBulletsPerTrigger)
            {
                this.Reload(InitialBulletsPerBarrel);
            }

            int result = this.DecreaseBullets(CountOfBulletsPerTrigger);
            return result;
        }
    }
}
