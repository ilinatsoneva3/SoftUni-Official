namespace AquaShop.Models.Decorations
{
    using AquaShop.Models.Decorations.Contracts;

    public class Plant : Decoration, IDecoration
    {
        public const int InitialComfort = 5;
        public const decimal InitialPrice = 10M;

        public Plant()
            : base(InitialComfort, InitialPrice)
        {
        }
    }
}
