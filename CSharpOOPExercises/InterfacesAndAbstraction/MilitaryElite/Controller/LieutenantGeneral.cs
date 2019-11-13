namespace MilitaryElite.Controller
{
    using MilitaryElite.Models;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastNAme, decimal salary, ICollection<IPrivate> privates) 
            : base(id, firstName, lastNAme, salary)
        {
            this.Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var currPrivate in this.Privates)
            {
                sb.AppendLine("  " + currPrivate.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
