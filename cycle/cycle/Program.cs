using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cycle
{
    class Program
    {
        static void Main(string[] args)
        {
            double v;//швидкість
            double t;//час
            const double g = 9.8;//земне тяжіння
            double t1 = 0;
            try
            {
                do
                {
                    Console.WriteLine("enter a speed (m/s)");
                    v = double.Parse(Console.ReadLine());
                } while (v < 0);// швидкість повинна бути додатня
                do
                {
                    Console.WriteLine("enter a time (s)");
                    t = double.Parse(Console.ReadLine());
                } while (t < 0);//час не може бути выдэмний
                double h1 = 0;
                double v1 = 0;
                while (t1 <= t)// цикл який підраховує висоту та швидкість від 0 до t
                {
                    h1 = v * t1 - g * t1 * t1 / 2.0;// підраховуємо висоту в заданій час тобто h(t2)
                    v1 = v - g * t1;//підраховуємо швидкість в заданий час тобто v(t2)
                    if (h1 < 0)
                    {
                        Console.WriteLine("тіло на землі");// якщо тіло лежить на землі 
                        t1 = t;// для того щоб вийти з цилу
                    }
                    else
                    {
                        Console.WriteLine("t = {0}, h = {1:f2}, v = {2:f2}", t1, h1, v1);// виводимо число t2 v1 h1
                    }
                    t1++;
                    
                }
                Console.WriteLine("+++++++++++++++");// линия для того щоб розділити різні цикли
                for (t1 = 0; t1 <= t; t1++)// цикл для пидрахункку висоти та швидкості від 0 до t
                {
                    h1 = v * t1 - g * t1 * t1 / 2.0;// підраховуємовисоту в заданій час тобто h(t1)
                    v1 = v - g * t1;//підраховуємо швидкість в заданий час тобто v(t1)
                    if (h1 < 0)
                    {
                        Console.WriteLine("тіло на землі");// якщо тіло лежить на землі 
                        t1 = t;// для того щоб вийти з цилу
                    }
                    else
                    {
                        Console.WriteLine("t = {0}, h = {1:f2}, v = {2:f2}", t1, h1, v1);// виводимо число t2 v1 h1
                    }
                }
                Console.WriteLine("++++++++++++");// линия для того щоб розділити різні цикли
                t1 = 0;// обнулили бо в попередньому циклі ця змінна була використала
                do
                {
                    h1 = v * t1 - g * t1 * t1 / 2.0;// підраховуємо висоту в заданій час тобто h(t2)
                    v1 = v - g * t1;//підраховуємо швидкість в заданий час тобто v(t2)
                    if (h1 < 0)
                    {
                        Console.WriteLine("тіло на землі");// якщо тіло лежить на землі 
                        t1 = t;// для того щоб вийти з цилу
                    }
                    else
                    {
                        Console.WriteLine("t = {0}, h = {1:f2}, v = {2:f2}", t1, h1, v1);// виводимо число t2 v1 h1
                    }
                    t1++;
                } while (t1 <= t);// цикл який підраховує висоту та швидкість від 0 до t
            }
            catch (Exception e)
            {
                Console.WriteLine("error: {0}", e);
            }


        }
    }
}