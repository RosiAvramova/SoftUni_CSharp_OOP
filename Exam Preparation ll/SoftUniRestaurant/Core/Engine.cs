using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController restaurant;

        public Engine(RestaurantController restaurantRestaurant)
        {
            this.restaurant = restaurantRestaurant;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    MoveCommand(input, restaurant);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetBaseException().Message}");
                }

                input = Console.ReadLine();
            }
        }

        private void MoveCommand(string inputArgs, RestaurantController restaurant)
        {
            string[] input = inputArgs.Split();
            string command = input[0];

            switch (command)
            {
                case "AddFood":
                    Console.WriteLine(restaurant.AddFood(input[1], input[2], decimal.Parse(input[3]))); break;
                case "AddDrink":
                    Console.WriteLine(restaurant.AddDrink(input[1], input[2], int.Parse(input[3]), input[4])); break;
                case "AddTable":
                    Console.WriteLine(restaurant.AddTable(input[1], int.Parse(input[2]), int.Parse(input[3]))); break;
                case "ReserveTable":
                    Console.WriteLine(restaurant.ReserveTable(int.Parse(input[1]))); break;
                case "OrderFood":
                    Console.WriteLine(restaurant.OrderFood(int.Parse(input[1]), input[2])); break;
                case "OrderDrink":
                    Console.WriteLine(restaurant.OrderDrink(int.Parse(input[1]), input[2], input[3])); break;
                case "LeaveTable":
                    Console.WriteLine(restaurant.LeaveTable(int.Parse(input[1]))); break;
                case "GetFreeTablesInfo":
                    Console.WriteLine(restaurant.GetFreeTablesInfo()); break;
                case "GetOccupiedTablesInfo":
                    Console.WriteLine(restaurant.GetOccupiedTablesInfo()); break;
                default: break;
            }
        }
    }
}
