using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestProppertyGettersWorkCorrectly()
        {
            Car car = new Car("bmw", 60, 50, 0.2);

            string model = car.Model;
            double capacity = car.TankCapacity;
            double fuel = car.FuelAmount;
            double consumption = car.FuelConsumptionPerKm;

            string expectedModel = "bmw";
            double expectedCapacity = 60;
            double expectedfuel = 50;
            double expectedConsumption = 0.2;

            Assert.AreEqual(expectedModel, model, "Model getter does not work as expected");
            Assert.AreEqual(expectedCapacity, capacity, "TankCapacity getter does not work as expected");
            Assert.AreEqual(expectedfuel, fuel, "FuelAmount getter does not work as expected");
            Assert.AreEqual(expectedConsumption, consumption, "FuelConsumptionPerKm getter does not work as expected");
        }

        [Test]
        public void TestModelSetterThrowsExeptionWhenDataIsInvalid()
        {
            //Car car = new Car("", 60, 50, 0.2);
            Assert.Throws<ArgumentException>(() => new Car("", 60, 50, 0.2));
        }

        [Test]
        public void TestFuelAmountSetterThrowsExeptionWhenDataIsInvalid()
        {
            //Car car = new Car("", 60, 50, 0.2);
            Assert.Throws<ArgumentException>(() => new Car("Opel", 60, 65, 0.2));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestFuelConsmptionSetterThrowsExeptionWhenDataIsInvalid(double invalidConsumption)
        {
            //Car car = new Car("", 60, 50, 0.2);
            Assert.Throws<ArgumentException>(() => new Car("Opel", 60, 50, invalidConsumption));
        }

        [Test]
        public void TestIfDriveMethodReducesFuelAmount()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            string message = car.Drive(10);
            string expectedMessage = "Have a nice trip";

            double fuel = car.FuelAmount;
            double expextedFuel = 48;

            Assert.AreEqual(expextedFuel, fuel);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void TestIfDriveMethodThrowsExeptionWhenNotEnoughFuel()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
        }

        [Test]
        public void TestIfRefuelMethodIncreasesFuelAmount()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            car.Refuel(10);

            double fuel = car.FuelAmount;
            double expextedFuel = 60;

            Assert.AreEqual(expextedFuel, fuel);
        }

        [Test]
        public void TestIfRefuelMethodThrowsExeptionWhenTooMuchFuel()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            Assert.Throws<InvalidOperationException>(() => car.Refuel(100));
        }
    }
}