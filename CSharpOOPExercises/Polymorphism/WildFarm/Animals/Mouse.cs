namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Squeak");
        }
    }
}
