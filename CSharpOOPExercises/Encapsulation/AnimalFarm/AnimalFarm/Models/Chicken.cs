namespace AnimalFarm.Models
{
    using System;
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age 
        {
            get => this.age;

            private set
            {
                if (value< MinAge || value>MaxAge)
                {
                    throw new ArgumentException(Exceptions.AgeInvalidException);
                }

                this.age = value;
            }
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Exceptions.NameInvalidException);
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            return $"Chicken {this.name} (age { this.age}) can produce { this.CalculateProductPerDay()} eggs per day.";
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
