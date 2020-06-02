namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count => this.heroes.Count;

        public void Add(Hero hero) => this.heroes.Add(hero);

        public void Remove(string name)
        {
            Hero hero = this.heroes.Where(x => x.Name == name).FirstOrDefault();
            this.heroes.Remove(hero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = this.heroes.OrderByDescending(x => x.Item.Strength).First();
            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = this.heroes.OrderByDescending(x => x.Item.Ability).First();
            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = this.heroes.OrderByDescending(x => x.Item.Intelligence).First();
            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.heroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
