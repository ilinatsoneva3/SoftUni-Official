namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;

    public class SaltwaterAquarium : Aquarium, IAquarium
    {
        public const int InitialCapacity = 25;
        public SaltwaterAquarium(string name) 
            : base(name, InitialCapacity)
        {
        }
    }
}
