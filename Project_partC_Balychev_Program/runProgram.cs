
namespace Project_partC_Balychev_Program
{
    internal class runProgram
    {
        private StoreInventory storeInventory;

        public runProgram()
        {
            storeInventory = new StoreInventory();

            storeInventory.RegisterHandler(PrintMessage);
        }

        public static event EventHandler itemAdded;

        public void Run()
        {
            StoreItem.EmptyStock += PrintEmptyItem;

            int mode = int.MaxValue;

            while (true)
            {
                Menu.Options();

                mode = Reader.ReadInt32(x => x >= 0 && x <= 7);

                switchMenu(mode);
            }
        }

        private void switchMenu(int mode)
        {
            switch (mode)
            {
                case 1:
                    ChooseAdd();
                    break;
                case 2:
                    ChooseDelete();
                    break;
                case 3:
                    CheckAvailability();
                    break;
                case 4:
                    SortByPrice();
                    break;
                case 5:
                    StoreClear();
                    break;
                case 6:
                    itemAdded?.Invoke(this, EventArgs.Empty);
                    Information();
                    break;
                case 7:
                    Filter();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown operation!");
                    break;
            }
        }

        private void ChooseAdd()
        {
            Menu.ChooseAdd();

            int option = Reader.ReadInt32(x => x >= 1 && x <= 2);

            SwitchAdd(option);
        }

        private void ChooseDelete()
        {
            Menu.ChooseRemove();

            int option = Reader.ReadInt32(x => x >= 1 && x <= 2);

            SwitchDelete(option);
        }

        private void SwitchDelete(int option)
        {
            switch (option)
            {
                case 1:
                    DeletePeripheryItem();
                    break;

                case 2:
                    DeleteAlcoholItem();
                    break;

            }
        }

        private void SwitchAdd(int option)
        {
            switch (option)
            {
                case 1:
                    AddComputerItem();
                    break;
                case 2:
                    AddAlcoItem();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Unknown Operation!");
                    break;
            }

        }

        private void AddComputerItem()
        {
            Console.WriteLine("Adding computer item to the store:");
            Console.WriteLine("Input company name:");

            ComputerPeripheralsStore computerPeripheralAdd = new ComputerPeripheralsStore();
            computerPeripheralAdd.CompanyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            computerPeripheralAdd.QuantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than 0,99 and less then 1000):");
            computerPeripheralAdd.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Headphones,Mouse,Keyboard,PowerBank )");
            computerPeripheralAdd.Type = (PeripheriItems)Enum.Parse(typeof(PeripheriItems), Console.ReadLine());

            storeInventory.Add(computerPeripheralAdd);
        }

        private void AddAlcoItem()
        {
            Console.WriteLine("Adding alco item to the store:");
            Console.WriteLine("Input company name:");

            AlcoholStore AlcoItemAdd = new AlcoholStore();
            AlcoItemAdd.AlcoCompanyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            AlcoItemAdd.QuantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than 1,99 and less then 5000 ):");
            AlcoItemAdd.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Rum, Whiskey, Cognac, Bear, Vodka, )");
            AlcoItemAdd.Type = (AlcoholItems)Enum.Parse(typeof(AlcoholItems), Console.ReadLine());

            storeInventory.Add(AlcoItemAdd);

        }

        private void DeletePeripheryItem()
        {
            Console.WriteLine("Deleting item from the store: ");
            Console.WriteLine("Input company name:");

            string companyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            int quantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than and less than: ");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Headphones,Mouse,Keyboard,PowerBank )");
            PeripheriItems itemType = (PeripheriItems)Enum.Parse(typeof(PeripheriItems), Console.ReadLine());

            ComputerPeripheralsStore itemToDelete = new ComputerPeripheralsStore()
            {
                CompanyName = companyName,
                QuantityInStock = quantityInStock,
                Price = price,
                Type = itemType
            };

            bool removed = storeInventory.Remove(itemToDelete);
        }
        private void DeleteAlcoholItem()
        {
            Console.WriteLine("Deleting alcohol item from the store:");
            Console.WriteLine("Input company name:");

            string companyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            int quantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than 1.99 and less than 5000):");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Rum, Whiskey, Cognac, Bear, Vodka):");
            AlcoholItems type = (AlcoholItems)Enum.Parse(typeof(AlcoholItems), Console.ReadLine());

            AlcoholStore alcoholItemRemove = new AlcoholStore(companyName, quantityInStock, price, type);
            storeInventory.Remove(alcoholItemRemove);
        }

        private void CheckAvailability()
        {
            Console.WriteLine("Checking availability of an item.");
            Console.WriteLine("Input company name:");

            ComputerPeripheralsStore isComputerPeripheralContains = new ComputerPeripheralsStore();
            isComputerPeripheralContains.CompanyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            isComputerPeripheralContains.QuantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than 0.99 and less then 1000):");
            isComputerPeripheralContains.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Headphones,Mouse,Keyboard,PowerBank )");
            isComputerPeripheralContains.Type = (PeripheriItems)Enum.Parse(typeof(PeripheriItems), Console.ReadLine());

            storeInventory.Contains(isComputerPeripheralContains);
            Console.WriteLine(isComputerPeripheralContains.ToString());
        }

        private void SortByPrice()
        {
            Console.WriteLine("Sorting items by price.");

            storeInventory.SortByPrice();
        }

        private void StoreClear()
        {
            Console.WriteLine("Clearing the store inventory.");

            storeInventory.Clear();

            Console.WriteLine("Store inventory cleared.");
        }

        private void Information()
        {
            Console.WriteLine("Displaying information about items in the store.");

            string Info = storeInventory.GetStorageInfo();

            Console.WriteLine(Info);
        }
        
        private void Filter()
        {
            Menu.ChooseFiltration();

            StoreInventory filtredInventory;

            int option = Reader.ReadInt32( x => x >= 1 && x <= 2);

            switch (option)
            {
                case 1:
                    filtredInventory = storeInventory.Filtration(item => item.Price <= 50);
                    PrintList(filtredInventory);
                    break; 
                case 2:
                    filtredInventory = storeInventory.Filtration(item => item.QuantityInStock > 0);
                    PrintList(filtredInventory);
                    break;          
                default:
                    Console.WriteLine("Unknown operation!");
                    break;
            }
   
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message); 
        }

        private void PrintEmptyItem(object sender, string e)
        {
            Console.WriteLine($"Item {e} is empty in stock");
        }

        public void PrintList(StoreInventory store)
        {
            foreach (var item in store)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
