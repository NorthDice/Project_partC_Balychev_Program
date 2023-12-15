using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partC_Balychev_Program
{
    internal static class Menu
    {
        public static void Options()
        {
            Console.WriteLine("1 - Add item in store");
            Console.WriteLine("2 - Delete item from store");
            Console.WriteLine("3 - Check for availability ");
            Console.WriteLine("4 - Sort by price");
            Console.WriteLine("5 - Clear");
            Console.WriteLine("6 - Store info");
            Console.WriteLine("7 - Filter (price less or equals 50 or in stock)");
            Console.WriteLine("0 - Exit");
        }
        public static void ChooseAdd()
        {
            Console.WriteLine("1 - Add computer item");
            Console.WriteLine("2 - Add alco item");
        }

        public static void ChooseRemove()
        {
            Console.WriteLine("1 - Delete computer item");
            Console.WriteLine("2 - Delete alco item");

        }

        public static void ChooseFiltration() 
        {
            Console.WriteLine("1 - Filtration by price");
            Console.WriteLine("2 - Filtration by quantity in store");
        }
    }
}
