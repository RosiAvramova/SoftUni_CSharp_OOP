using NUnit.Framework;
using Skeleton.Interfaces;
using Moq;

namespace Skeleton.Tests
{

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void MockDemo()
        {
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();

            var type = mockWeapon.Object.GetType();

            Hero batman = new Hero("batman", mockWeapon.Object);
        }
    }
}
