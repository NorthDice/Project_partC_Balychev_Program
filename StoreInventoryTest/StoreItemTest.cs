using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreItemTest
{
    [TestClass]
    public class ComputerPeripheralsStoreTest
    {
        [TestMethod]
        public void Price_Valid()
        {
            // Arrange
            double price = 100.0;
            ComputerPeripheralsStore storeItem = new ComputerPeripheralsStore("JBL", 5, price, PeripheriItems.Headphones);

            // Act
            double result = storeItem.Price;

            // Assert
            Assert.AreEqual(price, result);
        }

        [TestMethod]
        public void Price_Invalid()
        {
            // Arrange
            double invalidPrice = -50.0;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var store = new ComputerPeripheralsStore("JBL", 5, 10.0, PeripheriItems.Headphones);
                store.Price = invalidPrice;
            });
        }

        [TestMethod]
        public void QuantityInStock_Valid()
        {
            // Arrange
            int quantity = 10;
            ComputerPeripheralsStore storeItem = new ComputerPeripheralsStore("JBL", quantity, 75.0, PeripheriItems.Mouse);

            // Act
            int result = storeItem.QuantityInStock;

            // Assert
            Assert.AreEqual(quantity, result);
        }

        [TestMethod]
        public void QuantityInStock_Invalid()
        {
            // Arrange
            int invalidQuantity = -5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var store = new ComputerPeripheralsStore("JBL", 10, 50.0, PeripheriItems.PowerBank);
                store.QuantityInStock = invalidQuantity;
            });
        }

        [TestMethod]
        public void Items_Valid()
        {
            // Arrange
            PeripheriItems item = PeripheriItems.Keyboard;
            ComputerPeripheralsStore storeItem = new ComputerPeripheralsStore("JBL", 15, 30.0, item);

            // Act
            PeripheriItems result = storeItem.Type;

            // Assert
            Assert.AreEqual(item, result);
        }

        [TestMethod]
        public void Items_Invalid()
        {
            // Arrange
            PeripheriItems invalidItem = (PeripheriItems)(((int)Enum.GetValues(typeof(PeripheriItems)).Cast<PeripheriItems>().Max()) + 1);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var store = new ComputerPeripheralsStore("SomeCompany", 10, 50.0, PeripheriItems.Headphones);
                store.Type = invalidItem;
            });
        }


        [TestMethod]
        public void CompanyName_LengthExceedsLimit_DefaultsToNoName()
        {
            // Arrange
            string invalidName = "LongCompanyName123";

            // Act and Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => new ComputerPeripheralsStore("JBL", 1, 0.99, PeripheriItems.Headphones)
            {
                CompanyName = invalidName
            });

            Assert.AreEqual("Company name length must be less then 12 letters", ex.Message);
        }

        [TestMethod]
        public void CompanyName_SetToValidName()
        {
            // Arrange
            string validName = "ValidName";

            // Act
            ComputerPeripheralsStore storeItem = new ComputerPeripheralsStore();
            storeItem.CompanyName = validName;

            // Assert
            Assert.AreEqual(validName, storeItem.CompanyName);
        }
    }
}
