namespace WildFarm.Animals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }
    }
}
