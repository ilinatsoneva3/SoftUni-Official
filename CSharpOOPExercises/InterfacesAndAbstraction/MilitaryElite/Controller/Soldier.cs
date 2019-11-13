namespace MilitaryElite.Controller
{
    using MilitaryElite.Models;
    using System.Text;

    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastNAme)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastNAme;
        }

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
