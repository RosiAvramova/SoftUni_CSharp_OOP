namespace P03.Ferrari
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            IFerrari ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari);
        }
    }
}
