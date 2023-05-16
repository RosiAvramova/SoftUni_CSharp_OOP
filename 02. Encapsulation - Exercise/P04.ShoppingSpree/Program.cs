using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            List<Person> people = new List<Person>();

            foreach (var item in input)
            {
                string[] tokens = item.Split("=");
                try
                {
                    Person person = new Person(tokens[0], decimal.Parse(tokens[1]));
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                string[] tokens = item.Split("=");
                try
                {
                    products.Add(new Product(tokens[0], decimal.Parse(tokens[1])));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                string[] tokens = command.Split();

                string personName = tokens[0];
                string productName = tokens[1];

                Person person = people.Single(x => x.Name == personName);
                Product product = products.Single(x => x.Name == productName);


                if (!person.BayProduct(product))
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
            }

            foreach (var person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - { string.Join(", ", person.Products.Select(p => p.Name))}");
                }
            }
        }
    }
}
