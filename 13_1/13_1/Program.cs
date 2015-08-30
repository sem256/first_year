using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_1
{
    
    
   
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Numbers[] n = new Numbers[6] { new Complex(), new Complex(2, 1), new Complex(2, 3),new Fraction(),  new Fraction(1), new Fraction(2,5) };
                Console.WriteLine("a=" + n[1].ToString());
                Console.WriteLine("b=" + n[2].ToString());
                n[0] = (Complex)n[1] + (Complex)n[2];
                Console.WriteLine("a+b=" + n[0].ToString());
                n[0] = (Complex)n[1] / (Complex)n[2];
                Console.WriteLine("a/b=" + n[0].ToString());
                n[0] = (Complex)n[1] - (Complex)n[2];
                Console.WriteLine("a-b=" + n[0].ToString());
                n[0] = (Complex)n[1] * (Complex)n[2];
                Console.WriteLine("a*b=" + n[0].ToString());
                Console.WriteLine("test=" + n[1].ToString());
                Console.WriteLine("спряжене= " + ((Complex)n[1]).conjugate());
                double n1 = 2.0;
                Console.WriteLine(((Complex)n[1]).Root(n1));
                Console.WriteLine(((Complex)n[1]).Pow(n1));

                Console.WriteLine("+++++++++++++++++++++++");


                Fraction a1 = new Fraction(1);
                Console.WriteLine("1+2/5=");
                Fraction b1 = new Fraction(2, 5);
                n[3] = (Fraction)n[4] + (Fraction)n[5];
                Console.WriteLine(n[3].ToString());
                Console.WriteLine("1-2/5=");
                n[3] = (Fraction)n[4] - (Fraction)n[5];
                Console.WriteLine(n[3].ToString());
                Console.WriteLine("1*2/5=");
                n[3] = (Fraction)n[4] * (Fraction)n[5];
                Console.WriteLine(n[3].ToString());
                Console.WriteLine("1 : 2/5=");
                n[3] = (Fraction)n[4] / (Fraction)n[5];
                Console.WriteLine(n[3].ToString());
                Console.WriteLine();
                Console.WriteLine("1<2/5");
                Console.WriteLine((Fraction)n[4] < (Fraction)n[5]);
                Console.WriteLine();
                Console.WriteLine("1>2/5");
                Console.WriteLine((Fraction)n[4] > (Fraction)n[5]);
                Console.WriteLine();
                Console.WriteLine("1<=2/5");
                Console.WriteLine((Fraction)n[4] <= (Fraction)n[5]);
                Console.WriteLine();
                Console.WriteLine("1>=2/5");
                Console.WriteLine((Fraction)n[4] >= (Fraction)n[5]);
                Console.WriteLine();
                Console.WriteLine("1==2/5");
                Console.WriteLine((Fraction)n[4] == (Fraction)n[5]);
                Console.WriteLine();
                Console.WriteLine("1!=2/5");
                Console.WriteLine((Fraction)n[4] != (Fraction)n[5]);
                Fraction mm = new Fraction(2, 2);
                Complex mn = new Complex(2, 2);
                if (mn.Equals(mm))
                    Console.WriteLine("+++");
                else
                    Console.WriteLine("---");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
