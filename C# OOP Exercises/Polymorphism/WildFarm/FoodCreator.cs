namespace WildFarm
{
    using System;
    using System.Collections.Generic;
   using WildFarm.Foods;
   public class FoodCreator
    {
        public Food CreateFood(IList<string> args)
        {
            string type = args[0];
            var quantity = int.Parse(args[1]);

            switch (type)
            {
                case nameof(Vegetable):
                    return new Vegetable(quantity);
                case nameof(Seeds):
                    return new Seeds(quantity);
                case nameof(Meat):
                    return new Meat(quantity);
                case nameof(Fruit):
                    return new Fruit(quantity);
                default:
                   throw new ArgumentException( $"{type} is invalid type of food!");
            }
        }
    }
}
