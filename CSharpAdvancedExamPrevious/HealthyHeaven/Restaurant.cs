namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Restaurant
    {
        private List<Salad> salads;

        public Restaurant(string name)
        {
            this.Name = name;
            this.salads = new List<Salad>();
        }
        public string Name { get; set; }

        public void Add(Salad salad)
        {
            this.salads.Add(salad);
        }
        public bool Buy(string name)
        {
            Salad salad = this.salads.Where(x => x.Name == name).FirstOrDefault();

            if (salad != null)
            {
                this.salads.Remove(salad);
                return true;
            }

            return false;
        }

        public Salad GetHealthiestSalad()
        {
            Salad salad = this.salads.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
            return salad;
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} have {this.salads.Count} salads:");

            foreach (var salad in this.salads)
            {
                sb.AppendLine(salad.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
