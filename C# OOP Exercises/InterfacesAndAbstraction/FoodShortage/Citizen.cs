namespace FoodShortage
{
    class Citizen : IIdentifiable, IBuyer
    {
        public Citizen(string name, int age, string iD, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = iD;
            this.BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }

        public string BirthDate { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            this.Food += 10;
            return 10;
        }
    }
}
