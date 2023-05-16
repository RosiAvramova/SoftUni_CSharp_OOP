namespace _08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenant : ISoldier
    {
        ICollection<ISoldier> Privates { get; }
    }
}
