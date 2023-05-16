namespace Skeleton.Tests
{
    using System;
    using NUnit.Framework;
    using FluentAssertions;

    [TestFixture]
    public class AxeTests
    {        
        [Test]
        public void AxeAttackShouldDropDurabilityByOne()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            axe.DurabilityPoints.Should().Be(9);
        }
    }
}
