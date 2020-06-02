namespace AquaShop.Models.Fish
{
    using AquaShop.Models.Fish.Contracts;

    public class FreshwaterFish : Fish, IFish
    {
        //Can only live in FreshwaterAquarium!
        public const int InitialSize = 3;
        public const string aquarium = "FreshwaterAquarium";

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = InitialSize;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
