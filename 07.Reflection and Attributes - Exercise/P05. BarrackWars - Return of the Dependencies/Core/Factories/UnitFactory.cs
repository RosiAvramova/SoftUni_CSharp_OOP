namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = typeof(AppEntryPoint).Assembly;

            Type currentUnitType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == unitType);

            if (currentUnitType == null)
            {
                throw new ArgumentException("Not valid Unit");
            }

            return (IUnit)Activator.CreateInstance(currentUnitType);

            //Type classType = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            //return (IUnit)Activator.CreateInstance(classType);

        }
    }
}
