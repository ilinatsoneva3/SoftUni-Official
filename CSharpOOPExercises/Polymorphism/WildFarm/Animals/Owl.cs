namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Hoot Hoot");
        }
    }
}
