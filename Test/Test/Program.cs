using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("=============");
            ////перетворення типов

            //byte b1 = 16, b2 = 32;
            //byte b = (byte)(b1 + b2);
            //Console.WriteLine("b =" + b.ToString());

            Console.WriteLine("===============");
            //
            int x, y, z;
            x = 1;
            y = x++ + ++x;
            z = x++ + ++x;
            Console.WriteLine("x = {0} y = {1} z = {2}", x, y, z);

            Console.WriteLine("==============");
            
        }
    }
}
