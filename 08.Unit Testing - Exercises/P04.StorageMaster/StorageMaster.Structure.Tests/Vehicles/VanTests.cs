using System;
using System.Linq;
using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;

namespace Tests
{
    public class Tests
    {
        private Vehicle van;

        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void LoadProductCorrect()
        {
            Product product = new Ram(2.57);

            this.van.LoadProduct(product);

            int expectedCount = 1;

            Product insertedProduct = this.van.Trunk.Last();

            //Assert.That(expectedCount, Is.EqualTo(this.van.Trunk.Count));
            Assert.That(expectedCount == this.van.Trunk.Count);
            Assert.That(product == insertedProduct);
        }

        [Test]
        public void LoadProductThrowsExeption()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }

            int expectedCount = 20;

            Assert.That(expectedCount == this.van.Trunk.Count);
            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(product));
        }

        [Test]
        public void UnloadProductThrowsExeption()
        {
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }

        [Test]
        public void UnloadProductWorksCorrectly()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 5; i++)
            {
                this.van.LoadProduct(product);
            }

            Product lastProduct = new HardDrive(3.25);

            this.van.LoadProduct(lastProduct);

            Product resultProduct = this.van.Unload();

            int expectedCount = 5;

            Assert.That(expectedCount == this.van.Trunk.Count);
            Assert.That(lastProduct == resultProduct);
        }

        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.van.IsEmpty;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmptyReturnsFalse()
        {
            Product product = new Ram(2.35);

            this.van.LoadProduct(product);

            var result = this.van.IsEmpty;

            Assert.IsFalse(result);
            //Assert.That(result == false);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            Product product = new HardDrive(2.35);

            this.van.LoadProduct(product);
            this.van.LoadProduct(product);

            var result = this.van.IsFull;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            var result = this.van.IsFull;

            Assert.IsFalse(result);


        }

        [Test]
        public void CapacitySetCorrectly()
        {
            Assert.That(2 == this.van.Capacity);
        }

        [Test]
        public void PropertyTruckReturnsCorrectData()
        {
            Assert.That(0 == this.van.Trunk.Count);
        }
    }
}