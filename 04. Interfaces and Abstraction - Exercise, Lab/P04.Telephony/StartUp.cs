namespace P04.Telephony
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                Console.WriteLine(smartphone.Calling(number));
            }

            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browsing(url));
            }
        }
    }
}
