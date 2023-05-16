namespace P07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] buyersArgs = Console.ReadLine().Split();

                if (buyersArgs.Length == 4)
                {
                    buyers.Add(new Citizen(buyersArgs[0], int.Parse(buyersArgs[1]), buyersArgs[2], buyersArgs[3]));
                }
                else if (buyersArgs.Length == 3)
                {
                    buyers.Add(new Rebel(buyersArgs[0], int.Parse(buyersArgs[1]), buyersArgs[2]));
                }
            }

            while (true)
            {
                string whoBoughtFood = Console.ReadLine();

                if (whoBoughtFood == "End")
                {
                    break;
                }

                IBuyer buyer = buyers.SingleOrDefault(b => b.Name == whoBoughtFood);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
