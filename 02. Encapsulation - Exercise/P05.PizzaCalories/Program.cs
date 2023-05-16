using System;

namespace P05.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split();

                string pizzaName = pizzaArgs[1];

                string[] doughArgs = Console.ReadLine().Split();

                string flourType = doughArgs[1];
                string bakingTechnique = doughArgs[2];
                double weight = double.Parse(doughArgs[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);
              
                Pizza pizza = new Pizza(pizzaName, dough);

                string inputLine = Console.ReadLine();

                while (inputLine != "END")
                {

                    string[] toppingArgs = inputLine.Split();

                    string toppingType = toppingArgs[1];
                    double weightTopping = double.Parse(toppingArgs[2]);

                    Topping topping = new Topping(toppingType, weightTopping);

                    pizza.AddTopping(topping);

                    inputLine = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalcalories():f2} Calories.");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
