namespace P5.Mordor_sCruelPlan
{
    using P5.Mordor_sCruelPlan.Foods;
    using P5.Mordor_sCruelPlan.Moods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Food> foodsEaten = new List<Food>();

            string[] foods = Console.ReadLine().Split();

            foreach (var food in foods)
            {
                switch (food.ToLower())
                {
                    case "apple":
                        foodsEaten.Add(new Apple());
                        break;
                    case "cram":
                        foodsEaten.Add(new Cram());
                        break;
                    case "honeycake":
                        foodsEaten.Add(new HoneyCake());
                        break;
                    case "lembas":
                        foodsEaten.Add(new Lembas());
                        break;
                    case "melon":
                        foodsEaten.Add(new Melon());
                        break;
                    case "mushrooms":
                        foodsEaten.Add(new Mushrooms());
                        break;
                   
                    default:
                        foodsEaten.Add(null);
                        break;
                }
            }

            int happinesFood = foodsEaten
                //.Where(c => c!= null)
                //.Select(x => x.Happines)
                .Select(x => x == null ? -1 : x.Happines)
                .Sum();

            Console.WriteLine(happinesFood);

            if (happinesFood < -5)
            {
                Console.WriteLine(nameof(Angry));
            }
            else if (happinesFood >= -5 && happinesFood <=0)
            {
                Console.WriteLine(nameof(Sad));
            }
            else if (happinesFood >= 1 && happinesFood <= 15)
            {
                Console.WriteLine(nameof(Happy));
            }
            else if (happinesFood > 15)
            {
                Console.WriteLine(nameof(JavaScript));
            }
        }
    }
}
