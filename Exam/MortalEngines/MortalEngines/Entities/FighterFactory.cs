using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class FighterFactory
    {
        public static IMachine CreateFighter(string name, double attackPoints, double defensePoints)
        {
            IMachine tank;
            try
            {
                tank = new Fighter(name, attackPoints, defensePoints);

            }
            catch (Exception ex)
            {
                throw ex.InnerException;

            }

            return tank;
        }
    }
}