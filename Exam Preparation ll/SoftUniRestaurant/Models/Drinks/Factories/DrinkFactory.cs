using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Models.Drinks.Factories
{
    public class DrinkFactory
    {
        public IDrink CreateDrink(string typeDrink, string name, int servingSize, string brand)
        {
            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(d => d.Name == typeDrink);

            IDrink drink = (IDrink)Activator.CreateInstance(type, name, servingSize, brand);

            return drink;
        }
    }
}
