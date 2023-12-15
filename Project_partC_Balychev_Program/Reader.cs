using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partC_Balychev_Program
{
    internal class Reader
    {
        public static int ReadInt32()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int ReadInt32(Func<int, bool> typeCheck)
        {
            int number = ReadInt32();

            if (!typeCheck(number))
                throw new Exception();

            return number;
        }
    }
}
