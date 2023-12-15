using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryTest
{
    [TestClass]
    public class AlcoholStoreTests
    {

        [TestMethod]
        public void AlcoCompanyName_SetValidValue_Success()
        {
            // Arrange
            AlcoholStore alcoholStore = new AlcoholStore();

            // Act
            alcoholStore.AlcoCompanyName = "New Company";

            // Assert
            Assert.AreEqual("New Company", alcoholStore.AlcoCompanyName);
        }

        [TestMethod]
        public void AlcoCompanyName_SetInvalidValue_ExceptionThrown()
        {
            // Arrange
            AlcoholStore alcoholStore = new AlcoholStore();

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => alcoholStore.AlcoCompanyName = "TooLongCompanyName123456");
        }

        [TestMethod]
        public void Type_SetValidValue_Success()
        {
            // Arrange
            AlcoholStore alcoholStore = new AlcoholStore();

            // Act
            alcoholStore.Type = AlcoholItems.Cognac;

            // Assert
            Assert.AreEqual(AlcoholItems.Cognac, alcoholStore.Type);
        }

        [TestMethod]
        public void Type_SetInvalidValue_ExceptionThrown()
        {
            // Arrange
            AlcoholStore alcoholStore = new AlcoholStore();

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => alcoholStore.Type = (AlcoholItems)100);
        }

        [TestMethod]
        public void QuantityInStock_SetValidValue_Success()
        {
            // Arrange
            AlcoholStore alcoholStore = new AlcoholStore();

            // Act
            alcoholStore.QuantityInStock = 10;

            // Assert
            Assert.AreEqual(10, alcoholStore.QuantityInStock);
        }

        [TestMethod]
        public void QuantityInStock_SetInvalidValue_ExceptionThrown()
        {
            // Arrange
            AlcoholStore alcoholStore = new AlcoholStore();

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => alcoholStore.QuantityInStock = 30);
        }

        [TestMethod]
        public void Price_SetValidValue_Success()
        {
            // Arrange
            AlcoholStore alcoholStore = new AlcoholStore();

            // Act
            alcoholStore.Price = 50.0;

            // Assert
            Assert.AreEqual(50.0, alcoholStore.Price);
        }

        [TestMethod]
        public void Price_SetInvalidValue_ExceptionThrown()
        {
            // Arrange
            AlcoholStore alcoholStore = new AlcoholStore();

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => alcoholStore.Price = 0.5);
        }
    }
}
