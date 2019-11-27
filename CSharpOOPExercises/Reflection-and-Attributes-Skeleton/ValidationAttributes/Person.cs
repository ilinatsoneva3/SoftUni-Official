namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.FullName = name;
            this.Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }

        [MyRangeAtrribute(18,65)]
        public int Age { get; set; }
    }
}
