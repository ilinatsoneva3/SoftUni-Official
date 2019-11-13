namespace MilitaryElite.Controller
{
    using MilitaryElite.Enums;
    using MilitaryElite.Models;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastNAme, decimal salary, Corps corps, ICollection<IRepair> repairs) 
            : base(id, firstName, lastNAme, salary, corps)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
