using System;
using NUnit.Framework;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class CustomLinkedListTests
    {
        private const int InitialCount = 0;

        private DynamicList<int> list;

        [SetUp]
        public void TestInit()
        {
            this.list = new DynamicList<int>();
        }


        [Test]
        public void ConstructorShouldSetCountToZero()
        {
            Assert.That(InitialCount, Is.EqualTo(list.Count));
        }

        [Test]
        public void IndexOperatorShouldReturnValue()
        {
            list.Add(13);

            int element = list[0];

            Assert.That(element, Is.EqualTo(13));
        }

        [Test]
        public void IndexOperatorShouldSetValue()
        {
            list.Add(12);
            list[0] = 42;

            Assert.That(list[0], Is.EqualTo(42));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowExceptionWhenGettingInvalidIndex(int index)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            int returnValue = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => returnValue = list[index]);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowExceptionWhenSettingInvalidIndex(int index)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 69, "Index was " + index);
        }
    }
}