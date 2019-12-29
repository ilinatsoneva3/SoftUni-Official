namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;

    public class FreshwaterAquarium : Aquarium, IAquarium
    {
        public const int InitialCapacity = 50;

        public FreshwaterAquarium(string name) 
            : base(name, InitialCapacity)
        {
        }
    }
}
