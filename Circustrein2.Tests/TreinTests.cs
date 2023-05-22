using Circustrein2;
using CircusTrein2;

namespace Circustrein2.Tests
{
    [TestClass]
    public class TreinTests
    {
        private Wagon _wagon;

        [TestInitialize] public void Setup()
        {
            _wagon = new Wagon();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange

            // Act

            // Assert
            Assert.IsNotNull(_wagon);
            Assert.AreEqual(10, _wagon.maxWeight);
        }
    }
}