using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paskal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number n");
            int n = int.Parse(Console.ReadLine());
            int a = 1;
            int b;
            int c;
            int j;
            for (int f = 0; f <= n; f++)
            {
                j = f;
                for (int m = 0; m <= j; m++)
                {
                    for (int i = 0; i <= j; i++)
                    {
                        a *= i;
                        if (a == 0)
                        {
                            a = 1;
                        }
                    }
                    b = 0;
                    for (int i = 0; i <= m; i++)
                    {
                        b *= i;
                        if (b == 0)
                        {
                            b = 1;
                        }
                    }
                    c = 0;
                    for (int i = 0; i <= j - m; i++)
                    {
                        c *= i;
                        if (c == 0)
                        {
                            c = 1;
                        }
                    }
                    double someVariant = a / (b * c);
                    
                    Console.Write(someVariant);
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}