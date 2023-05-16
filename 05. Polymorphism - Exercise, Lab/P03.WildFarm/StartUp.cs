
using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] animalArgs = input.Split();

            Animal animal = AnimalFactory.Create(animalArgs);           

            string[] foodArgs = Console.ReadLine().Split();

            Food food = FoodFactory.Create(foodArgs);

            Console.WriteLine(animal.ProduceSound());

            try
            {
                animal.Eat(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            animals.Add(animal);

            input = Console.ReadLine();
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}

