namespace _08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ICommando : ISoldier
    {
        ICollection<IMission> Missions { get; }
    }
}
