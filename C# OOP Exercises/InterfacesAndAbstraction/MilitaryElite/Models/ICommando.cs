namespace MilitaryElite.Models
{
    using System.Collections.Generic;

    public interface ICommando: ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; }
    }
}
