namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavoriteFood = favoriteFood;
        }

        public string Name { get; protected set; }
        public string FavoriteFood { get; protected set; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavoriteFood}";
        }
    }
}
