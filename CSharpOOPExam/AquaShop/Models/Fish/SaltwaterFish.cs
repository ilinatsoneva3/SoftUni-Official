namespace AquaShop.Models.Fish
{
    using AquaShop.Models.Fish.Contracts;

    public class SaltwaterFish : Fish, IFish
    {
        //Can only live in SaltwaterAquarium!

        public const int InitialSize = 5;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = InitialSize;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
