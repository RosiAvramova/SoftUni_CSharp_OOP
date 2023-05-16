using System;
using System.Collections.Generic;
using NUnit.Framework;
using P01.Database;

namespace Tests
{
    public class Tests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void AddMethodShouldThrowExeptionWithInvalidParameter()
        {
            for (int i = 0; i < 10; i++)
            {
                this.database.Add(45);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(459));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 5; i++)
            {
                this.database.Add(45);
            }

            Assert.That(11, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void RemoveMethodShouldThrowExeptionWithEmptyDatabase()
        {
            for (int i = 0; i < 6; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 2; i++)
            {
                database.Remove();
            }

            Assert.That(4, Is.EqualTo(database.DatabaseElements.Length));
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            this.database = new Database(1, 2, 3, 5);

            Assert.That(4, Is.EqualTo(database.DatabaseElements.Length));
        }

        [Test]
        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void ConstructorShouldThrowExeption(params int[] collection)
        {
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(collection));
        }

        [Test]
        public void PropertyDatabaseElementsShouldSetCorrectly()
        {
            var collection = new List<int>(){ 1, 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(collection, this.database.DatabaseElements);
        }

        [Test]
        public void PropertyDatabaseElementsShouldGetCorrectly()
        {
            int expectedCount = 6;

            Assert.That(expectedCount, Is.EqualTo(this.database.DatabaseElements.Length));
        }
    }
}