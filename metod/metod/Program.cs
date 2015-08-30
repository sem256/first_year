using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metod
{
    class Program
    {
        static int[] input_array()//ввод масива
        {
            int n = 0;
            while (n <= 0)// довжина масиву повинна бути додатня
            {
                Console.WriteLine("enter length");
                n = int.Parse(Console.ReadLine());// вводимо довжину масиву
            }
            int[] mass = new int[n];//ініціалізуемо масив заданої довжини
            for (int i = 0; i < mass.Length; i++)//цикл для проходу по всьому масиву
            {
                do
                {
                    Console.WriteLine("enter a number m[{0}]=", i);// виводимо значення елеменвів в масив
                }
                while (!int.TryParse(Console.ReadLine(), out mass[i]));// елементи в масиві повинні бути типу int
            }
            return mass;// виходимо з методу повертаємо заповненний масив в точку виклику 
        }
        static void output_array(int[] a)// метод для виводу масива на єкран 
        {
            for (int i = 0; i < a.Length; i++)// проходимо по всьому масиву 
            {
                Console.Write("{0} ", a[i]);// виводимо по елементово
            }
            Console.WriteLine();
        }
        static int min(int[] a)// метод для знаходження мінімального елемента
        {
            int p = a[0];// перший елемент берем за еталон
            for (int i = 1; i < a.Length; i++)//проходимо по масиву
            {
                if (p > a[i]) p = a[i];// якщо еталон більший за якийсь елемент в масиві тоді переприсвоюємо еталон
            }
            return p;//повертаемо мін елемент в точку викику 
        }
        static void pos(int[] a, int p)// метод для заміни всіх позитивних на мінімальний
        {
            for (int i = 0; i < a.Length; i++)// проходимо по всьому масиву
            {
                if (a[i] > 0) a[i] = p;// якщо значення додатне змінюємо на мінімальне 
            }
        }
        static void neg(int[] a, int p)// метод для заміни всіх відємних на мінімальний
        {
            for (int i = 0; i < a.Length; i++)// проходимо по всьому масиву
            {
                if (a[i] < 0) a[i] = p;// якщо значення відємне змінюємо на мінімальне
            }
        }
        static void Main(string[] args)
        {
            try
            {
                int k;
                int[] mass = input_array();// ініціалізуємо масив за допомогою метода заповнюємо його 
                int[] mass1 = (int[])mass.Clone();// створюємо копію цього масива 
                k = min(mass);// змінюємо всі додатні елементи на мінімальний
                pos(mass, k);// зміюємо всі додатні значення на мінімальне  
                neg(mass1, k);// зміюємо всі відємні  значення на мінімальне
                Console.WriteLine("for positive values");
                output_array(mass);// виводимо масив
                Console.WriteLine("for negativ values");
                output_array(mass1);// виводимо масив
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e);
            }
        }
    }
}