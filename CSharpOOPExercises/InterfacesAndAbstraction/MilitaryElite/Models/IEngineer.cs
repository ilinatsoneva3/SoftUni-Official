namespace MilitaryElite.Models
{
    using System.Collections.Generic;

    interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; }
    }
}
