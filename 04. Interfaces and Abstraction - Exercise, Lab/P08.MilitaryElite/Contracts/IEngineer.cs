namespace _08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

   public interface IEngineer<T>: ISoldier
    {
        ICollection<T> Repairs { get; }
    }
}
