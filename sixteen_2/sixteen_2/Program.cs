using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sixteen_2
{
        class sixteen
        {
            private const int LENGTH = 6;
            //private const int MAX = 65535;// 16^6 обмеження 
            int[] name;//оголошення масиву, що буде лежати в осові об'єкта
            public sixteen()
            {
                name = new int[LENGTH];
            }
            public sixteen(int ten)//конструктор з параметром дес число
            {
                //if ((ten < 0) || (ten >= MAX))// перевіряємо умову
                //{
                //    throw new OverflowException("помылка число быльше за 16777216");
                //}
                //else // якщо все гаразд, перетворюємо з int десяткове -> string шіснадцяткове
                //{
                   name = new int[LENGTH];
                    int x = ten;
                    int i = 0;
                    while (x != 0)
                    {
                        name[LENGTH - i - 1] = x % 16;
                        i++;
                        x /= 16;
                    }
                //}
            }
            // це індексатор для name
            //public int this[int index]
            //{
            //    get// Аксесор get
            //    {
            //        if ((index >= 0) || (index < LENGTH))// перевіряємо
            //            return name[index];
            //        else throw new IndexOutOfRangeException("індекс виходить за межі обєкту");// якщо помилка
            //    }
            //    set
            //    {
            //        if ((index < 0) || (index > LENGTH - 1))
            //            throw new IndexOutOfRangeException("Помилка! індекс виходить за межі об'єкту");
            //        else
            //        {
            //            //if ((value >=0) || ((value <= 15)))
            //                name[index] = value;
            //            //else
            //                //throw new FormatException("Помилка! Об'єкт може набувати лише значення від 0 до 15");
            //        }
            //    }
            //}
            //public static sixteen operator *(sixteen a, sixteen b)
            //{
            //    if ((int)a * (int)b >= MAX)
            //        throw new OverflowException("результат більший за 16777216");// перевіряємо чи не віходимо за межі
            //    else
            //    {
            //        sixteen c = new sixteen((int)a * (int)b);
            //        return c;
            //    }
            //}
            //public static sixteen operator +(sixteen a, sixteen b)
            //{
            //    if ((int)a + (int)b > MAX) throw new OverflowException("результат більший за 16777216");// перевіряємо чи не віходимо за межі
            //    else
            //    {
            //        sixteen c = new sixteen((int)a + (int)b);
            //        return c;
            //    }
            //}
            //public static sixteen operator -(sixteen a, sixteen b)
            //{
            //    if ((int)a - (int)b > MAX) throw new OverflowException("результат більший за 16777216");// перевіряємо чи не віходимо за межі
            //    else
            //    {
            //        sixteen c = new sixteen((int)a - (int)b);// віконуємо віднімання
            //        return c;
            //    }
            //}
            //public static implicit operator int(sixteen a)
            //{ // sixteen -> int
            //    int dec = 0;
            //    int j = 1;
            //    for (int i = LENGTH - 1; i >= 0; i--)// починаємо з кінця
            //    {
            //        switch (a[i])
            //        {
            //            case 10: dec += 10 * j;
            //                break;
            //            case 11: dec += 11 * j;
            //                break;
            //            case 12: dec += 12 * j;
            //                break;
            //            case 13: dec += 13 * j;
            //                break;
            //            case 14: dec += 14 * j;
            //                break;
            //            case 15: dec += 15 * j;
            //                break;
            //            default:
            //                dec += (Convert.ToInt32(a[i]) - 48) * j;// підраховуємо суму
            //                break;
            //        }
            //        j *= 16;
            //    }
            //    return dec;
            //}
            public override string ToString()
            {	//метод переведення значень об'єкта в строку
                string s ="";
                for (int i = 0; i < LENGTH; i++)// починаємо з кінця
                {
                    switch (name[i])
                    {
                        case 10: s = s + "A";
                            break;
                        case 11: s = s + "B";
                            break;
                        case 12: s = s + "C";
                            break;
                        case 13: s = s + "D";
                            break;
                        case 14: s = s + "E";
                            break;
                        case 15: s = s + "F";
                            break;
                        default:
                            s += s + name[i];
                            break;
                    }
                }
                return s;
            }
            //public static bool operator >(sixteen a, sixteen b)
            //{	// результат те, що більше 
            //    return Compare(a, b) == 1;
            //}
            //public static bool operator <(sixteen a, sixteen b)
            //{	// результат те, що менше 
            //    return Compare(a, b) == -1;
            //}
            //// Перевантаження перевірок на рівність-нерівність - порівнюємо значення, а не посилання!
            //public static bool operator ==(sixteen a, sixteen b)
            //{	// результат чи дорівнює 
            //    return Compare(a, b) == 0;
            //}
            //public static bool operator !=(sixteen a, sixteen b)
            //{	// результат чи не рівне
            //    return Compare(a, b) != 0;
            //}
            //public static bool operator >=(sixteen a, sixteen b)
            //{	// результат те, що більше рівне
            //    return Compare(a, b) >= 0;
            //}
            //public static bool operator <=(sixteen a, sixteen b)
            //{	// результат те, що менше рівне 
            //    return Compare(a, b) <= 0;
            //}
            //// a>b = 1; a<b = -1; a==b = 0;
            //private static int Compare(sixteen a, sixteen b)
            //{	//цей метод порівнює 2 об'екти, a>b = 1; a<b = -1; a==b = 0;
            //    int i = (int)a;
            //    int j = (int)b;//допоміжний рахівник
            //    if (i > j) return 1;	//a>b = 1;
            //    if (i < j) return -1;	//a<b = -1;
            //    return 0;	// a == b = 0;
            //}

            //public override bool Equals(object obj)
            //{
            //    if (this == obj)
            //        return true;
            //    sixteen c = (sixteen)obj;
            //    return Compare(this, c) == 0;
            //}
    }
            class Program
            {
                static void Main(string[] args)
                {
                    try
                    {
                        int s, s1;
                        do
                        {
                            Console.WriteLine("enter a number first");
                            s = int.Parse(Console.ReadLine());
                        } while (s <= 0);
                        sixteen number = new sixteen(s);//створюємо екземпляр класу
                        Console.WriteLine(number.ToString());//виводимо на екран в шіснадцятковій формі
                        Console.WriteLine("==================================");
                       // do
                       // {
                       //     Console.WriteLine("enter a second number");
                       //     s1 = int.Parse(Console.ReadLine());
                       // } while (s1 <= s);
                       // sixteen number1 = new sixteen(s1);//створюємо екземпляр класу
                       // Console.WriteLine(number1.ToString());//виводимо на екран в шіснадцятковій формі
                       // Console.WriteLine("==================================");
                       // sixteen c = new sixteen(s1);//створюємо екземпляр класу


                       //// c = number1 + number;
                       // Console.WriteLine(c.ToString());//виводимо на екран в шіснадцятковій формі
                       // Console.WriteLine("==================================");

                       //// c = number1 - number;
                       // Console.WriteLine(c.ToString());//виводимо на екран в шіснадцятковій формі 
                       // Console.WriteLine("==================================");

                       // //c = number1 * number;
                       // Console.WriteLine(c.ToString());//виводимо на екран в шіснадцятковій формі
                       // Console.WriteLine("==================================");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }