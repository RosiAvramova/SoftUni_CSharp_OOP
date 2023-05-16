using NUnit.Framework;
using P02.ExtendedDatabas;

namespace Tests
{
    [TestFixture]
    public class PersonDatabaseTests
    {
        private Person pesho;
        private Person ivan;

        [SetUp]
        public void TestInit()
        {
            pesho = new Person(413121, "Pesho");
            ivan = new Person(121314, "Ivan");
        }

        [Test]
        public void ConstructorShoudInitializeCollection()
        {
            var expected = new Person[] { pesho, ivan };

            var database = new Database(expected);

            var actual = database.Fetch();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddMethodShouldAddValidPerson()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);
            var newPerson = new Person(554466, "Stamat");
            database.Add(newPerson);

            var actual = database.Fetch();
            var expected = new Person[] { pesho, ivan, newPerson };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddMethodSameUsernameShouldThrow()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);
            var newPerson = new Person(554466, "Ivan");

            Assert.That(() => database.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodSameIdShouldThrow()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);
            var newPerson = new Person(413121, "Misho");

            Assert.That(() => database.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveMethodShouldRemove()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);
            database.Remove();

            var actual = database.Fetch();
            var expected = new Person[] { pesho };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveMethodEmptyCollectionShouldThrow()
        {
            var persons = new Person[] { };
            var database = new Database(persons);

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameMethodShouldReturnPerson()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);

            var expected = pesho;
            var actual = database.FindByUsername("Pesho");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByUsernameMethodShouldThrow()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);

            Assert.That(() => database.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameMethodNullArgumentShouldThrow()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);

            Assert.That(() => database.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameMethodIsCaseSensitive()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);

            Assert.That(() => database.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdMethodShouldReturnPerson()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);

            var expected = pesho;
            var actual = database.FindById(413121);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByIdMethodShouldThrow()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);

            Assert.That(() => database.FindById(558877), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameMethodNegativeArgumentShouldThrow()
        {
            var persons = new Person[] { pesho, ivan };
            var database = new Database(persons);

            Assert.That(() => database.FindById(-5), Throws.Exception);
        }
    }
}