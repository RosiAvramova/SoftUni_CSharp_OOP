using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;
using System;

namespace MortalEngines.Entities
{
    public class TankFactory
    {
        public static IMachine CreateTank(string name, double attackPoints, double defensePoints)
        {
            IMachine tank;
            try
            {
                tank = new Tank(name, attackPoints, defensePoints);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return tank;
        }
    }
}