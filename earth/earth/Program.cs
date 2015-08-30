using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earth
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                char m;// початковий напрямок руху 
                int n;// дія яку виконує робот
                do
                {
                    Console.WriteLine("enter symbol (N) or (W) or (S) or (O)");
                    m = char.Parse(Console.ReadLine());// зчитуємо та перетворюємо з tostring в char 
                }
                while ((m != 'N') && (m != 'W') && (m != 'O') && (m != 'S'));// цикл для перевірки щоб можна було ввести правильні значення
                do
                {
                    Console.WriteLine("enter number (1) turn to the left (-1) turn to the right and (0) go straight");
                    n = int.Parse(Console.ReadLine());// зчитуємо та перетворюємо з tostring в int
                }
                while ((n != 1) && (n != -1) && (n != 0)); // цикл для перевірки
                switch (m)//перевіряємо який напрямок 
                {
                    case 'N': // якшо m = N то виконуємо умову цього case
                        switch (n)
                        {
                            case 1: Console.WriteLine("direction W"); // якщо 1 тоді він повертає на ліво та виводить результат
                                break;
                            case -1: Console.WriteLine("direction O");// якщо -1 тоді він повертає на право та виводить результат
                                break;
                            case 0: Console.WriteLine("direction N");// якщо 0 тоді він зберігає початковий напрямок та виводить результат
                                break;
                        }
                        break;
                    case 'O': // якшо m = O то виконуємо умову цього case
                        switch (n)
                        {
                            case 1: Console.WriteLine("direction N");// якщо 1 тоді він повертає на ліво та виводить результат
                                break;
                            case -1: Console.WriteLine("direction S");// якщо -1 тоді він повертає на право та виводить результат
                                break;
                            case 0: Console.WriteLine("direction O");// якщо 0 тоді він зберігає початковий напрямок та виводить результат
                                break;
                        }
                        break;
                    case 'S': // якшо m = S то виконуємо умову цього case
                        switch (n)
                        {
                            case 1: Console.WriteLine("direction O");// якщо 1 тоді він повертає на ліво та виводить результат
                                break;
                            case -1: Console.WriteLine("direction W");// якщо -1 тоді він повертає на право та виводить результат
                                break;
                            case 0: Console.WriteLine("direction S");// якщо 0 тоді він зберігає початковий напрямок та виводить результат
                                break;
                        }
                        break;
                    case 'W': // якшо m = W то виконуємо умову цього case
                        switch (n)
                        {
                            case 1: Console.WriteLine("direction S");// якщо 1 тоді він повертає на ліво та виводить результат
                                break;
                            case -1: Console.WriteLine("direction N");// якщо -1 тоді він повертає на право та виводить результат
                                break;
                            case 0: Console.WriteLine("direction W");// якщо 0 тоді він зберігає початковий напрямок та виводить результат
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error:{0}", e);
            }
        }
    }
}