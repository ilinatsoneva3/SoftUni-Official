namespace FoodShortage
{
    public interface IBuyer
    {
        string Name { get; }

        int Food { get; }

        int BuyFood();
    }
}
