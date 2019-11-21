namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Cluck");
        }
    }
}
