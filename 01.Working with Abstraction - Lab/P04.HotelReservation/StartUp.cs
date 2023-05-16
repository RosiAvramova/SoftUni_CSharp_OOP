using System;

namespace P04.HotelReservation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] splitedInput = Console.ReadLine()
                .Split();

            decimal pricePerDay = decimal.Parse(splitedInput[0]);
            int days = int.Parse(splitedInput[1]);
            Season season = Enum.Parse<Season>(splitedInput[2]);
            Discount discount = Discount.None;

            if (splitedInput.Length == 4)
            {
                discount = Enum.Parse<Discount>(splitedInput[3]);
            }

            decimal totalCost = days * pricePerDay * (int)season * (1 - (int)discount / 100.0M);

            Console.WriteLine(totalCost.ToString("f2"));
        }
    }
}
