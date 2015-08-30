using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    class Program
    {
        static void Main(string[] args)
        {
            // програма виводить номер автомобиля який кратній 2,5,7 та сума його цифр =12
            int m, p, n;
            try
            {
                for (int f = 100; f <= 999; f++)// проходимо через всі трьох значні числа 
                {
                    if ((f % 7 == 0) && (f % 5 == 0) && (f % 2 == 0))// перевіряємо кратність на 7,5,2
                    {
                        m = f % 10;// отримуємо останний елемент числа
                        p = (f / 10) % 10;// отримуємо другій елемент числа
                        n = f / 100;// отрімуємо перший елемет числа
                        if ((m + p + n) == 12) // перевіряємо чи їх сума =12 якщо так то виводимо результат
                        {
                            Console.WriteLine("це число кратне 7, 5, 2 та сума його цифр = 12; {0}", f);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error:{0}", e);
            }
        }
    }
}
