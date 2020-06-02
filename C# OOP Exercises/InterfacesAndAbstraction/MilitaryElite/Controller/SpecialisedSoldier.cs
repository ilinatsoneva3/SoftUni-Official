namespace MilitaryElite.Controller
{
    using MilitaryElite.Enums;
    using MilitaryElite.Models;
    using System;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastNAme, decimal salary, Corps corps)
            : base(id, firstName, lastNAme, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
