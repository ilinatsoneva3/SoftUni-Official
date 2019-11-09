namespace PersonsInfo
{
    using System;

    public class Person
    {
        private const decimal salaryMinimum = 460;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Person(string firstName, string lastName, int age, decimal salary)
            : this(firstName, lastName, age)
        {
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(FirstName, "First name cannot contain fewer than 3 symbols!");
                }
                else if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(LastName, "Last name cannot contain fewer than 3 symbols!");
                }
                else if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }
        public decimal Salary
        {
            get => this.salary;

            private set
            {
                if (value<salaryMinimum)
                {
                    throw new ArgumentException($"Salary cannot be less than {salaryMinimum} leva!");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage /= 2;
            }

            this.Salary += this.Salary * percentage / 100;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
    }
}
