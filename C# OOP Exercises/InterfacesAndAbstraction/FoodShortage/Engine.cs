namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<IBuyer> list;
        private int foodPurchased;

        public Engine()
        {
            this.list = new List<IBuyer>();
        }

        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToList();
                this.AddToList(input);
            }

            var name = Console.ReadLine();

            while (name != "End")
            {
                var buyer = this.CheckIfNameExists(name);

                if (buyer != null)
                {
                    this.foodPurchased += buyer.BuyFood();
                }

                name = Console.ReadLine();
            }

            Console.WriteLine(this.foodPurchased);
        }

        private IBuyer CheckIfNameExists(string name)
        {
            return this.list.Where(x => x.Name == name).FirstOrDefault();
        }

        private void AddToList(List<string> input)
        {
            if (input.Count == 4)
            {
                var name = input[0];
                var age = int.Parse(input[1]);
                var id = input[2];
                var birthdate = input[3];
                this.list.Add(new Citizen(name, age, id, birthdate));
            }
            else
            {
                var name = input[0];
                var age = int.Parse(input[1]);
                var group = input[2];
                this.list.Add(new Rebel(name, age, group));
            }
        }
    }
}
