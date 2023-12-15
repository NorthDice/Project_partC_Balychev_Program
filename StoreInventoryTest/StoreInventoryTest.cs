namespace StoreInventoryTest
{
    [TestClass]
    public class StoreInventoryTest
    {
        [TestMethod]
        public void Filtration_ShouldFilterItemsByPrice()
        {
            // Arrange
            var items = new List<StoreItem>
    {
        new ComputerPeripheralsStore { QuantityInStock = 10, Price = 100.0 },
        new ComputerPeripheralsStore { QuantityInStock = 5, Price = 50.0 },
        new AlcoholStore { QuantityInStock = 8, Price = 10.0 },
        new AlcoholStore { QuantityInStock = 3, Price = 5.0 },
    };

            var storeInventory = new StoreInventory(items);

            // Act
            var filteredInventory = storeInventory.Filtration(item => item.Price < 70.0);

            // Assert
            Assert.AreEqual(4, items.Count);
            Assert.AreEqual(3, filteredInventory.Count);
            Assert.IsTrue(filteredInventory.Contains(items[1])); 
            Assert.IsTrue(filteredInventory.Contains(items[3])); 
        }
        [TestMethod]
        public void Count_ValidCount()
        {
            // Arrange 
            StoreInventory inventory = new StoreInventory()
        {
            new ComputerPeripheralsStore("Company1", 10, 2.5, PeripheriItems.None),
            new ComputerPeripheralsStore("Company2", 3, 1.2, PeripheriItems.None),
            new ComputerPeripheralsStore("Company3", 5, 4.8, PeripheriItems.None),
            new ComputerPeripheralsStore("Company4", 20, 3.0, PeripheriItems.None)
        };

            // Act
            int result = inventory.Count;

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Count_InvalidCount()
        {
            // Arrange 
            StoreInventory inventory = new StoreInventory();

            // Act
            int result = inventory.Count;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Clear_Clear()
        {
            // Arrange 
            StoreInventory inventory = new StoreInventory()
        {
            new ComputerPeripheralsStore("Company1", 10, 2.5, PeripheriItems.None),
            new ComputerPeripheralsStore("Company2", 3, 1.2, PeripheriItems.None),
            new ComputerPeripheralsStore("Company3", 5, 4.8, PeripheriItems.None),
            new ComputerPeripheralsStore("Company4", 20, 3.0, PeripheriItems.None)
        };

            // Act
            inventory.Clear();

            // Assert
            Assert.AreEqual(0, inventory.Count);
        }

        [TestMethod]
        public void Add_Valid()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();
            ComputerPeripheralsStore newItem = new ComputerPeripheralsStore("Company5", 2, 1.5, PeripheriItems.Mouse);

            // Act
            inventory.Add(newItem);

            // Assert
            Assert.IsTrue(inventory.Contains(newItem));
        }


        [TestMethod]
        public void Add_NullInput()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => inventory.Add(null));
        }

        [TestMethod]
        public void Remove_Valid()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();
            ComputerPeripheralsStore itemToRemove = new ComputerPeripheralsStore("Company2", 3, 1.2, PeripheriItems.None);
            inventory.Add(itemToRemove);

            // Act
            bool result = inventory.Remove(itemToRemove);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(inventory.Contains(itemToRemove));
        }

        [TestMethod]
        public void Remove_Invalid()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();
            ComputerPeripheralsStore itemToRemove = new ComputerPeripheralsStore("Company2", 3, 1.2, PeripheriItems.None);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => inventory.Remove(itemToRemove));
        }

        [TestMethod]
        public void Remove_NullInput()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => inventory.Remove(null));
        }

        [TestMethod]
        public void Contains_Valid()
        {
            // Arrange
            ComputerPeripheralsStore itemToCheck = new ComputerPeripheralsStore("Company3", 5, 5.0, PeripheriItems.Headphones);
            StoreInventory inventory = new StoreInventory()
            {
                new ComputerPeripheralsStore("Company1", 10, 2.5, PeripheriItems.None),
                new ComputerPeripheralsStore("Company2", 3, 1.2, PeripheriItems.None),
                new ComputerPeripheralsStore("Company4", 20, 3.0, PeripheriItems.None),
                itemToCheck
            };

            // Act
            bool result = inventory.Contains(itemToCheck);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_Invalid()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();
            ComputerPeripheralsStore itemToCheck = new ComputerPeripheralsStore("Company5", 3, 1.2, PeripheriItems.None);

            // Act
            bool result = inventory.Contains(itemToCheck);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SortByPrice_SortsItemsByPrice()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory()
        {
            new ComputerPeripheralsStore("Company1", 10, 2.5, PeripheriItems.None),
            new ComputerPeripheralsStore("Company2", 3, 1.2, PeripheriItems.None),
            new ComputerPeripheralsStore("Company3", 5, 4.8, PeripheriItems.None),
            new ComputerPeripheralsStore("Company4", 20, 3.0, PeripheriItems.None)
        };

            // Act
            inventory.SortByPrice();

            var sortedItems = inventory.ToList();
            Assert.AreEqual(1.2, sortedItems[0].Price);
            Assert.AreEqual(2.5, sortedItems[1].Price);
            Assert.AreEqual(3.0, sortedItems[2].Price);
            Assert.AreEqual(4.8, sortedItems[3].Price);
        }
    }
}