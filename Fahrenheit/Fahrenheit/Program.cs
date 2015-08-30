using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Ця програма переводить значення температурі по фар у значення температури у значення по цельсію та 
             виводить на екран таблицю значень для введеного діапазону градусів по фар*/
            int f1, f2;//значення темп по цел
            double c;//значення темп по фар
            int counter;// допоміжній рахівник

            //вводимо початкову інфу
            Console.WriteLine("write a first number to celsiuse");
            f1 = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("Write the second number to celsius");
                f2 = int.Parse(Console.ReadLine());
            }
            while (f2 <= f1);

            //перераховуемо та виводемо початкове значення темп
            Console.WriteLine("==============");
            counter = 0;
            for (int f = f1; f <= f2; f++)
            {//перетвор у градуси по цел
                c = 9.0/5.0*f + 32.0;
                Console.WriteLine("{0,3} градусов по цельсию = {1,-7:f2} градусов по фаренгейту", f, c);
                counter++;// рахуемо рядочки

                if (counter == 10)// після кожного десятого рядочка пропускаємо пустий рядок
                {
                    Console.WriteLine();//виводимо пустий рядок 
                    counter = 0;// облуляємо рахівник для наступного блока рядочків
                }
            }
        }
    }
}
