namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public override string ToString()
        {
            string result = $"Hero: {this.Name} - Level: {this.Level}lvl" + Environment.NewLine + this.Item.ToString();
            return result;
        }
    }
}
