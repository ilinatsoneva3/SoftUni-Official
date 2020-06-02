namespace Person
{
    using System;
    class Child : Person
    {
        private int age;

        public Child(string name, int age) : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (value>15)
                {
                    throw new ArgumentException("A child cannot be more 15 years old");
                }
                base.Age = value;
            }
        }
    }
}
