namespace P01.Vehicles
{
    using P01.Vehicles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            for (int i = 1; i <= 3; i++)
            {
                string[] VehicleArgs = Console.ReadLine().Split();

                double fuelQuantity = double.Parse(VehicleArgs[1]);
                double fuelConsumption = double.Parse(VehicleArgs[2]);
                int tankCapacity = int.Parse(VehicleArgs[3]);

                Vehicle vehicle = null;

                switch (i)
                {
                    case 1:
                        vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                        break;

                    case 2:
                        vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                        break;

                    case 3:
                        vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                        break;
                }

                vehicles.Add(vehicle);
            }

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string command = commandArgs[0];
                string type = commandArgs[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    Vehicle currVehicle = vehicles.FirstOrDefault(x => x.GetType().Name == type);

                    Console.WriteLine(currVehicle.Drive(distance));

                }
                else if (command == "Refuel")
                {
                    double fuelAmount = double.Parse(commandArgs[2]);

                    Vehicle currVehicle = vehicles.FirstOrDefault(x => x.GetType().Name == type);

                    try
                    {
                        currVehicle.Refuel(fuelAmount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else
                {
                    double distance = double.Parse(commandArgs[2]);

                    Bus currBuss = (Bus)vehicles.FirstOrDefault(x => x.GetType().Name == type);

                    Console.WriteLine(currBuss.DriveEmpty(distance));
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
