using System;

class StartUp
{
    static void Main(string[] args)
    {
        string[] carArgs = Console.ReadLine().Split();

        double carFuelQuantity = double.Parse(carArgs[1]);
        double carFuelConsumption = double.Parse(carArgs[2]);

        Car car = new Car(carFuelQuantity, carFuelConsumption);

        string[] truckArgs = Console.ReadLine().Split();

        double truckFuelQuantity = double.Parse(truckArgs[1]);
        double truckFuelConsumption = double.Parse(truckArgs[2]);

        Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            string[] commandArgs = Console.ReadLine().Split();

            string command = commandArgs[0];
            string type = commandArgs[1];

            if (command == "Drive")
            {
                double distance = double.Parse(commandArgs[2]);

                if (type == "Car")
                {
                    Console.WriteLine(car.Drive(distance));
                }
                else if (type == "Truck")
                {
                    Console.WriteLine(truck.Drive(distance));
                }
            }
            else if (command == "Refuel")
            {
                double fuelAmount = double.Parse(commandArgs[2]);

                if (type == "Car")
                {
                    car.Refuel(fuelAmount);
                }
                else if (type == "Truck")
                {
                    truck.Refuel(fuelAmount);
                }
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}