namespace AquariumAdventure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    class Aquarium
    {
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.fishInPool = new List<Fish>();
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public void Add(Fish fish)
        {
            if (this.fishInPool.Count + 1 <= this.Capacity)
            {
                this.fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            Fish fish = this.fishInPool.Where(x => x.Name == name).First();

            if (fish != null)
            {
                this.fishInPool.Remove(fish);
                return true;
            }

            return false;
        }

        public Fish FindFish(string name)
        {
            Fish fish = this.fishInPool.Where(x => x.Name == name).First();
            return fish;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (var fish in this.fishInPool)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
