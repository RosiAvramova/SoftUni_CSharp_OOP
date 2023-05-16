namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestConstructor()
        {
            Phone phone = new Phone("Sony", "123Q");

            string expectedMake = phone.Make;
            string expectedModel = phone.Model;

            Assert.AreEqual(expectedMake, phone.Make);
            Assert.AreEqual(expectedModel, phone.Model);
        }

        [Test]
        [TestCase("", "Samsung")]
        [TestCase(null, "Sony")]
        public void MakeThrowsExceptionWithInvalidString(string invalidMake, string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone(invalidMake, model));
        }

        [Test]
        [TestCase("Sony", null)]
        [TestCase("Samsung", "")]
        public void ModelThrowsExceptionWithInvalidString(string make, string invalidModel)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, invalidModel));
        }

        [Test]
        public void CountWorksCorrectly()
        {
            Phone phone = new Phone("Sony", "123Q");
            phone.AddContact("Ivan", "0888777666");
            phone.AddContact("Mimi", "0888777666");

            int expected = 2;
            int actual = phone.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddContactMethodThrowException()
        {
            Phone phone = new Phone("Sony", "123Q");
            phone.AddContact("Pesho", "0888777666");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "0888123666"));
        }


        [Test]
        public void AddContactMethodWorksCorrectly()
        {
            Phone phone = new Phone("Sony", "123Q");
            phone.AddContact("Pesho", "0888777666");
            phone.AddContact("Jivko", "0888123666");

            int actual = phone.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CallMethodWorksCorrectly()
        {
            Phone phone = new Phone("Sony", "123Q");
            phone.AddContact("Pesho", "0888777666");
            phone.AddContact("Jivko", "0888123666");

            string actual = phone.Call("Pesho");
            string expected = "Calling Pesho - 0888777666...";
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CallMethodThrowsException()
        {
            Phone phone = new Phone("Sony", "123Q");
            phone.AddContact("Pesho", "0888777666");
            phone.AddContact("Jivko", "0888123666");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Viki"));
        }
    }
}