namespace WildFarm.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }
    }
}
