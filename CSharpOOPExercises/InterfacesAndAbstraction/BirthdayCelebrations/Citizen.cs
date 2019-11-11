namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable, IBirthable
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
    }
}
