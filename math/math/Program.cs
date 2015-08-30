using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, z1, z2, x;
            try // ловимо помилки при неправильному використанні програми\
            {
                // перевірочні два цикли 
                Console.WriteLine("enter the number (a) of degrees");
                a = double.Parse(Console.ReadLine());
                a %= 360;
                Console.WriteLine("enter the number (b)of degrees");
                b = double.Parse(Console.ReadLine());
                b %= 360;
                do
                {
                    Console.WriteLine("enter the number");
                    x = double.Parse(Console.ReadLine());
                }
                while (x <= 0);
                double m = Math.PI / 180;
                // обчислення змінних які ми зчитали
                a = a * m;
                //Console.WriteLine(a);
                b = b * m;
                // розроховуємо за формулою
                z1 = -4.0 * Math.Pow(Math.Sin((a - b) / 2.0), 2) * Math.Cos(a + b);
                z2 = Math.Log(Math.Sqrt(x / (x * x + 1.0)));
                // виводимо на екран
                Console.WriteLine("answer z1 = {0,4:f2}, z2 = {1,4:f2}", z1, z2);
            }
            catch (Exception e)
            {
                Console.WriteLine("error:{0}", e);
            }

        }
    }
}