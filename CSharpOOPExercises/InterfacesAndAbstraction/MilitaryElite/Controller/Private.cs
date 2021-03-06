﻿namespace MilitaryElite.Controller
{
    using MilitaryElite.Models;
    using System.Text;

    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastNAme, decimal salary) 
            : base(id, firstName, lastNAme)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString() + $" Salary: {this.Salary:F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
