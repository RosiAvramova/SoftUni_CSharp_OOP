using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Foods.Factories
{
   public class FoodFactory
   {
       public IFood CreateFood(string foodType, string name, decimal price)
       {
           Type type = Assembly
               .GetCallingAssembly()
               .GetTypes()
               .FirstOrDefault(f => f.Name == foodType);

           IFood food = (IFood)Activator.CreateInstance(type, name, price);

           return food;
       }
   }
}
