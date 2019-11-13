namespace MilitaryElite.Models
{
    using MilitaryElite.Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
