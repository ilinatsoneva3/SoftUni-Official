namespace AquaShop.Models.Decorations
{
    using AquaShop.Models.Decorations.Contracts;

    public class Ornament : Decoration, IDecoration
    {
        public const int InitialComfort = 1;
        public const decimal InitialPrice = 5M;

        public Ornament() 
            : base(InitialComfort, InitialPrice)
        {
        }
    }
}
