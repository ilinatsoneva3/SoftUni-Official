namespace SpaceStationRecruitment
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.data = new List<Astronaut>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Astronaut astronaut)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            var astronaut = this.data.Where(x => x.Name == name).FirstOrDefault();

            if (astronaut != null)
            {
                this.data.Remove(astronaut);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut astronaut = this.data.OrderByDescending(x => x.Age).First();
            return astronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.Where(x => x.Name == name).First();
        }

        public int Count => this.data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
