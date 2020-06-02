namespace Rabbits
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    class Cage
    {
        private List<Rabbit> rabbits;
        public Cage(string name, int capacity)
        {
            this.rabbits = new List<Rabbit>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.rabbits.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.rabbits.Count < this.Capacity)
            {
                this.rabbits.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = this.rabbits.Where(r => r.Name == name).FirstOrDefault();

            if (rabbit != null)
            {
                this.rabbits.Remove(rabbit);
                return true;
            }

            return false;
        }

        public void RemoveSpecies(string species)
        {
            this.rabbits = this.rabbits.Where(r => r.Species != species).ToList();
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = this.rabbits.Where(r => r.Name == name).FirstOrDefault();
            rabbit.Available = false;
            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbitsBySpecies = this.rabbits.Where(r => r.Species == species).ToArray();

            foreach (var rabbit in rabbitsBySpecies)
            {
                rabbit.Available = false;
            }

            return rabbitsBySpecies;
        }

        public string Report()
        {
            List<Rabbit> rabbitsToPrint = this.rabbits.Where(r => r.Available == true).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in rabbitsToPrint)
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
