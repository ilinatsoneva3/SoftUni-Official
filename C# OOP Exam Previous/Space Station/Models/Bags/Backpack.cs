namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        private IList<string> items;

        public Backpack()
        {
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; private set; }
    }
}
