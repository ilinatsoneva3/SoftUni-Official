namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Woof!");
        }
    }
}
