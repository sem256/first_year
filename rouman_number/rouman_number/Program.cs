using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouman_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = " ";
            char a, b;//змінні для збереження символів
            int i = 0; //для збереження символа рядка
            int a1 = 0;//для збереження числового значення символа і
            int b1 = 0;//для збереження числового значення символа j
            int s = 0;//для підрахунку першого числа
            int s1 = 0;//для підрахунку другого числа 
            int p = 0;//в яку записуємо кількість символів які є в римському числі 
            bool count;// використовуємо для перевірки
            try//перевірка вхідного рядка на помилки
            {
                do//цикл в якому відбаваєтся введення даних
                {
                    count = true;
                    Console.WriteLine("Enter a number one but this number must be less than MMM");
                    myString = Console.ReadLine();//зчитуємо рядок и записуємо в змінну
                    p = myString.Length;//в змінній зберігатимется довжина рядка
                    i = 0;//рахівник для номера символу
                    s = 0;
                    while (count && (i < p))//цикл виконуватимется поки не закінчятся елементи рядка
                    {
                        a = myString[i];//записуємо в змінну а символ під номером і 
                        i++;
                        switch (a)// перебираємо можливі значення а
                        {
                            case 'M':
                            case 'D':
                            case 'C':
                            case 'L':
                            case 'X':
                            case 'V':
                            case 'I': count = true;//якщо символ дозволений
                                break;
                            default: count = false;//якщо є якісь інші символи виконаємо цикл введення ще раз
                                break;
                        }

                    }
                    if (count)
                    {
                        i = 0;
                        // p = myString.Length;//довжина рядка
                        myString = myString + " ";//доповнимо вхідний рядок пробілом з правої сторони для того щоб мати змогу порівнювати працювати з останнім елементо числа
                        while (i < p)// цикл в якому знаходится формула за якому здійсюєтся перетворення 
                        {
                            a = myString[i];//елемент рядка виділяємо, символ
                            i++;
                            b = myString[i];//беремо елемент рядка з порядковим номером на 1 більший за попередній

                            if (p >= 2 && a == b) //відкинемо варіанти, коли два знаки V|L|D стоять підряд
                            {
                                switch (a)
                                {
                                    case 'V':
                                    case 'L':
                                    case 'D':
                                        count = false;
                                        break;
                                }
                            }
                            if (p >= 4 && a == b && a == myString[i + 1] && b == myString[i + 2])//відкинемо варіант, коли 4 знаки I|X|C стоять підряд
                            {
                                switch (a)
                                {
                                    case 'I':
                                    case 'X':
                                    case 'C':
                                        count = false;
                                        break;
                                }
                            }
                            if (count)
                            {
                                switch (a)//перебираємо значення а
                                {
                                    case 'M': a1 = 1000;
                                        break;
                                    case 'D': a1 = 500;
                                        break;
                                    case 'C': a1 = 100;
                                        break;
                                    case 'L': a1 = 50;
                                        break;
                                    case 'X': a1 = 10;
                                        break;
                                    case 'V': a1 = 5;
                                        break;
                                    case 'I': a1 = 1;
                                        break;
                                }
                                switch (b)//перебираємо значення b
                                {
                                    case 'M': b1 = 1000;
                                        break;
                                    case 'D': b1 = 500;
                                        break;
                                    case 'C': b1 = 100;
                                        break;
                                    case 'L': b1 = 50;
                                        break;
                                    case 'X': b1 = 10;
                                        break;
                                    case 'V': b1 = 5;
                                        break;
                                    case 'I': b1 = 1;
                                        break;
                                }
                                if (a1 < b1)//якщо перший елемент менший за другий, міняємо знак першого елемента
                                {
                                    a1 = -a1;
                                }
                                s = s + a1;//підраховуємо значення  

                            }
                            if (s >= 1500) count = false;
                        }
                    }
                }
                while (count == false);//цикл виконуватимется, поки будуть помилки

                do
                {
                    count = true;
                    Console.WriteLine("enter a number two but this number must be less than MMM");
                    myString = Console.ReadLine();//зчитуємо рядок
                    p = myString.Length;//в змінній зберігатимется довжина рядка
                    i = 0;//рахівник для номера символу
                    s1 = 0;
                    while (count && (i < p))//цикл виконуватимется поки не закінчятся елементи рядка і елементи рядка будуть коректні символи
                    {
                        a = myString[i];//записуємо в змінну а символ під номером і 
                        i++;
                        switch (a)// перебираємо можливі значення а
                        {
                            case 'M':
                            case 'D':
                            case 'C':
                            case 'L':
                            case 'X':
                            case 'V':
                            case 'I': count = true;//якщо символ дозволений
                                break;
                            default: count = false;//якщо є якісь інші символи виконаємо цикл введення ще раз
                                break;
                        }
                    }
                    if (count)
                    {
                        i = 0;
                        // p = myString.Length;//довжина рядка
                        myString = myString + " ";//доповнимо вхідний рядок пробілом з правої сторони для того щоб мати змогу порівнювати працювати з останнім елементо числа
                        while (i < p)// цикл в якому знаходится формула за якому здійсюєтся перетворення 
                        {
                            a = myString[i];//елемент рядка виділяємо, символ
                            i++;
                            b = myString[i];//беремо елемент рядка з порядковим номером на 1 більший за попередній

                            if (p >= 2 && a == b) //відкинемо варіанти, коли два знаки V|L|D стоять підряд
                            {
                                switch (a)
                                {
                                    case 'V':
                                    case 'L':
                                    case 'D':
                                        count = false;
                                        break;
                                }
                            }
                            if (p >= 4 && a == b && a == myString[i + 1] && b == myString[i + 2])//відкинемо варіант, коли 4 знаки I|X|C стоять підряд
                            {
                                switch (a)
                                {
                                    case 'I':
                                    case 'X':
                                    case 'C':
                                        count = false;
                                        break;
                                }
                            }
                            if (count)
                            {
                                switch (a)//перебираємо значення а
                                {
                                    case 'M': a1 = 1000;
                                        break;
                                    case 'D': a1 = 500;
                                        break;
                                    case 'C': a1 = 100;
                                        break;
                                    case 'L': a1 = 50;
                                        break;
                                    case 'X': a1 = 10;
                                        break;
                                    case 'V': a1 = 5;
                                        break;
                                    case 'I': a1 = 1;
                                        break;
                                }
                                switch (b)//перебираємо значення b
                                {
                                    case 'M': b1 = 1000;
                                        break;
                                    case 'D': b1 = 500;
                                        break;
                                    case 'C': b1 = 100;
                                        break;
                                    case 'L': b1 = 50;
                                        break;
                                    case 'X': b1 = 10;
                                        break;
                                    case 'V': b1 = 5;
                                        break;
                                    case 'I': b1 = 1;
                                        break;
                                }
                                if (a1 < b1)//якщо перший елемент менший за другий, міняємо знак першого елемента
                                {
                                    a1 = -a1;
                                }
                                s1 = s1 + a1;//підраховуємо значення                     
                            }
                            if (s >= 1500) count = false;
                        }
                    }
                }
                while (count == false);//цикл виконуватимется, поки будуть помилки

                s = s1 + s;// сума вдох чисел
                int p1;
                p1 = (s / 1000) % 10;// четверта цифра числа
                switch (p1)// виводиомо певні римські букви в залежності від цифри
                {
                    case 1: Console.Write("M");
                        break;
                    case 2: Console.Write("MM");
                        break;
                    case 3: Console.Write("MMM");
                        break;
                }
                p1 = (s / 100) % 10;// третя цифра числа
                switch (p1)//виводиомо певні римські букви в залежності від цифри
                {
                    case 1: Console.Write("C");
                        break;
                    case 2: Console.Write("CC");
                        break;
                    case 3: Console.Write("CCC");
                        break;
                    case 4: Console.Write("CD");
                        break;
                    case 5: Console.Write("D");
                        break;
                    case 6: Console.Write("DC");
                        break;
                    case 7: Console.Write("DCC");
                        break;
                    case 8: Console.Write("DCCC");
                        break;
                    case 9: Console.Write("CM");
                        break;
                }
                p1 = (s / 10) % 10;//друга цифра числа
                switch (p1)// виводиомо певні римські букви в залежності від цифри
                {
                    case 1: Console.Write("X");
                        break;
                    case 2: Console.Write("XX");
                        break;
                    case 3: Console.Write("XXX");
                        break;
                    case 4: Console.Write("XL");
                        break;
                    case 5: Console.Write("L");
                        break;
                    case 6: Console.Write("LX");
                        break;
                    case 7: Console.Write("LXX");
                        break;
                    case 8: Console.Write("LXXX");
                        break;
                    case 9: Console.Write("XC");
                        break;
                }
                p1 = s % 10;//пперша цифра числа
                switch (p1)// виводиомо певні римські букви в залежності від цифри
                {
                    case 1: Console.Write("I");
                        break;
                    case 2: Console.Write("II");
                        break;
                    case 3: Console.Write("III");
                        break;
                    case 4: Console.Write("IV");
                        break;
                    case 5: Console.Write("V");
                        break;
                    case 6: Console.Write("VI");
                        break;
                    case 7: Console.Write("VII");
                        break;
                    case 8: Console.Write("VIII");
                        break;
                    case 9: Console.Write("IX");
                        break;
                }
                Console.WriteLine();
            }
            catch (Exception e)//всі можливі помилки
            {
                Console.WriteLine(e);
            }
        }
    }
}