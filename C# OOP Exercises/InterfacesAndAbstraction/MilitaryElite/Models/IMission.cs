namespace MilitaryElite.Models
{
    using MilitaryElite.Enums;

    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
