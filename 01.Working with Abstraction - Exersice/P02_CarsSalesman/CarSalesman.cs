﻿namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CarSalesman
    {
        private CarFactory carFactory;
        private EngineFactory engineFactiry;

        private List<Car> cars;
        private List<Engine> engines;

        public CarSalesman(CarFactory carFactory, EngineFactory engineFactiry)
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
            this.carFactory = carFactory;
            this.engineFactiry = engineFactiry;
        }

        public void AddEngine(string[] parameters)
        {
            Engine engine = engineFactiry.Create(parameters);
            engines.Add(engine);
        }

        public void AddCar(string[] parameters)
        {
            Car car = carFactory.Create(parameters, this.engines);

            cars.Add(car);
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}
