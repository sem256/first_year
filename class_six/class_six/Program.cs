using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_six
{
    class sixteen
    {
        private String name;
        private const int MAX = 65536;// 16^4 обмеження 
        //public String Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}
        private static int length = 50;
        public sixteen()
        {
            name = "";
        }
        public sixteen(int ten)//конструктор з параметром дес число
        { 
            if ((ten < 0) || (ten > MAX))// перевіряємо умову
            {
                throw new OverflowException("помылка число быльше за 1048576");
            }
            else // якщо все гаразд, перетворюємо з int десяткове -> string шіснадцяткове
            {
                name = "";
                int t;
                do
                {
                    t = ten % 16;
                    switch (t)
                    {
                        case 10: name = 'A' + name;
                            break;
                        case 11: name = 'B' + name;
                            break;
                        case 12: name = 'C' + name;
                            break;
                        case 13: name = 'D' + name;
                            break;
                        case 14: name = 'E' + name;
                            break;
                        case 15: name = 'F' + name;
                            break;
                        default:
                            name = t + name;
                            break;
                    }
                    ten = ten / 16;
                } while (ten >= 15);
                if (ten != 0)
                    name = ten + name;
                //length = name.Length;
            }
        }
        // це індексатор для name
        public char this[int index]
        {
            get// Аксесор get
            {
                if ((index >= 0 & index < length))// перевіряємо
                    return name[index];
                else throw new IndexOutOfRangeException("індекс виходить за межі обєкту");// якщо помилка
            }
        }
        public static sixteen operator *(sixteen a, sixteen b)
        {
            if ((int)a * (int)b > MAX)
                throw new OverflowException("результат більший за 1048576");// перевіряємо чи не віходимо за межі
            else
            {
                sixteen c = new sixteen((int)a * (int)b);
                return c;
            }
        }
        public static sixteen operator +(sixteen a, sixteen b)
        {
            if ((int)a + (int)b > MAX) throw new OverflowException("результат більший за 1048576");// перевіряємо чи не віходимо за межі
            else
            {
                sixteen c = new sixteen((int)a + (int)b);
                return c;
            }
        }
        public static sixteen operator -(sixteen a, sixteen b)
        {
            if ((int)a - (int)b > MAX) throw new OverflowException("результат більший за 1048576");// перевіряємо чи не віходимо за межі
            else
            {
                sixteen c = new sixteen((int)a - (int)b);// віконуємо віднімання
                return c;
            }
        }
        public static implicit operator int(sixteen a)
        { // sixteen -> int
            int dec = 0;
            int j = 1;
            for (int i = length - 1; i >= 0; i--)// починаємо з кінця
            {
                switch (a[i])
                {
                    case 'A': dec += 10 * j;
                        break;
                    case 'B': dec += 11 * j;
                        break;
                    case 'C': dec += 12 * j;
                        break;
                    case 'D': dec += 13 * j;
                        break;
                    case 'E': dec += 14 * j;
                        break;
                    case 'F': dec += 15 * j;
                        break;
                    default:
                        int p = Convert.ToInt32(a[i]) - 48;
                        dec += (Convert.ToInt32(a[i]) - 48) * j;// підраховуємо суму
                        break;
                }
                j *= 16;
            }
            return dec;
        }
        public override string ToString()
        {	//метод переведення значень об'єкта в строку
            string s = "";
            s = name;
            //for (int i = 0; i < length; i++)
            //{	//кожен елемент переводи в строку та конкатенує
            //    s = s + name[i];
            //}
            return s;
        }
        public static bool operator >(sixteen a, sixteen b)
        {	// результат те, що більше 
            return Compare(a, b) == 1;
        }
        public static bool operator <(sixteen a, sixteen b)
        {	// результат те, що менше 
            return Compare(a, b) == -1;
        }
        // Перевантаження перевірок на рівність-нерівність - порівнюємо значення, а не посилання!
        public static bool operator ==(sixteen a, sixteen b)
        {	// результат чи дорівнює 
            return Compare(a, b) == 0;
        }
        public static bool operator !=(sixteen a, sixteen b)
        {	// результат чи не рівне
            return Compare(a, b) != 0;
        }
        public static bool operator >=(sixteen a, sixteen b)
        {	// результат те, що більше рівне
            return Compare(a, b) >= 0;
        }
        public static bool operator <=(sixteen a, sixteen b)
        {	// результат те, що менше рівне 
            return Compare(a, b) <= 0;
        }
        // a>b = 1; a<b = -1; a==b = 0;
        private static int Compare(sixteen a, sixteen b)
        {	//цей метод порівнює 2 об'екти, a>b = 1; a<b = -1; a==b = 0;
            int i = (int)a;
            int j = (int)b;//допоміжний рахівник
            if (i > j) return 1;	//a>b = 1;
            if (i < j) return -1;	//a<b = -1;
            return 0;	// a == b = 0;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            sixteen c = (sixteen)obj;
            return Compare(this, c) == 0;
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
                    do
                    {
                        Console.WriteLine("enter a second number");
                        s1 = int.Parse(Console.ReadLine());
                    } while (s1 <= s);
                    sixteen number1 = new sixteen(s1);//створюємо екземпляр класу
                    Console.WriteLine(number1.ToString());//виводимо на екран в шіснадцятковій формі
                    Console.WriteLine("==================================");
                    sixteen c;//створюємо екземпляр класу


                    c = number1 + number;
                    Console.WriteLine(c.ToString());//виводимо на екран в шіснадцятковій формі
                    Console.WriteLine("==================================");

                    c = number1 - number;
                    Console.WriteLine(c.ToString());//виводимо на екран в шіснадцятковій формі 
                    Console.WriteLine("==================================");

                    c = number1 * number;
                    Console.WriteLine(c.ToString());//виводимо на екран в шіснадцятковій формі
                    Console.WriteLine("==================================");
                    
                    

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
}
