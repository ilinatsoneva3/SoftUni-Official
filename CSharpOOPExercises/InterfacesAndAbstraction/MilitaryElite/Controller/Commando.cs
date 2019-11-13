namespace MilitaryElite.Controller
{
    using MilitaryElite.Enums;
    using MilitaryElite.Models;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastNAme, decimal salary, Corps corps, ICollection<IMission> missions)
            : base(id, firstName, lastNAme, salary, corps)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
