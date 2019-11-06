namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }

        public virtual int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be a positive number");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString();
        }
    }
}
