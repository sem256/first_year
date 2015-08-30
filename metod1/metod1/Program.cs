using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace metod1
{
    class Program
    {
        static int[,] input_array()// метод для вводу масива
        {
            int a = 0, b = 0;
            while ((a < 2) || (a > 5))// за умовою задачі
            {
                Console.WriteLine("enter a number m");
                a = int.Parse(Console.ReadLine());//переводимо введене значення в int
            }
            while ((b < 2) || (b > 10))// за умовою задачі
            {
                Console.WriteLine("enter a number n");
                b = int.Parse(Console.ReadLine());// переводимо введене значення в int
            }
            int[,] mass = new int[a, b];// ініціалізуємо масив за розміром a*b
            for (int i = 0; i < mass.GetLength(0); i++)// проходимо по рядках у масиві 
            {
                for (int j = 0; j < mass.GetLength(1); j++)// проходимо по елементам в масиві заданого рядака 
                {
                    do
                    {
                        Console.WriteLine("enter a number m[{0},{1}]", i, j);//елемент який ми вводимо
                    } while (!int.TryParse(Console.ReadLine(), out mass[i, j]));//для коректного вводу числа
                }
            }
            return mass;// повертає заповнений масив
        }
        static int end(int[,] k)// метод для знаходження останнього рядка з рівною кількістю додатніх та відємних елементів
        {
            int a = 0, b = 0, j;
            for (int i = (k.GetLength(0) - 1); i >= 0; i--)// проходимо по рядкам в масиві 
            {
                for (j = 0; j < k.GetLength(1); j++)// проходимо по елементах в масиві заданого рядака 
                {
                    if (k[i, j] > 0) a++;// якщо елемент в масиві додатній то збільшуемо рахівник 
                    else if (k[i, j] < 0) a--;// якщо відємний то зменшуемо
                    else b++;// дізнаемося кількість нулів в рядку
                }
                if ((a == 0) && (b != j)) return i;// якщо кількість додатніх та відємних співпадає та в рядку є не нульові елементи повертаємо номер рядка
                b = 0;
                a = 0;
            }
            return 0;// якщо таких рядків немає тоді повертаемо 0 
        }
        static int first(int[,] k)// метод для знаходження першого рядка з рівною кількістю додатніх та відємних елементів
        {
            int a = 0, b = 0, j;
            for (int i = 0; i < k.GetLength(0); i++)// проходимо по рядках в масиві 
            {
                for (j = 0; j < k.GetLength(1); j++)// проходимо по елементах в масиві заданого рядака 
                {
                    if (k[i, j] > 0) a++;// якщо елемент в масиві додатній то збільшуемо рахівник 
                    else if (k[i, j] < 0) a--;// якщо відємний то зменшуемо 
                    else b++;// дізнаємося кількість нулів в рядку
                }
                if ((a == 0) && (b != j)) return i;// якщо кількість додатніх та відємних співпадає та в рядку є не нульові елементи повертаємо номер рядка
                b = 0;
                a = 0;
            }
            return 0;// якщо таких рядків немає, повертаемо 0 
        }
        static void Main(string[] args)
        {
            try
            {
                int[,] array = input_array();// ініціалізуємо введений масив та за допомогою метода заповнюємо його
                Console.WriteLine("--------------");
                Console.WriteLine(first(array));// виводимо номер першого рядка в якому кількість додатніх та відємних елеменків співпадає
                Console.WriteLine("--------------");
                Console.WriteLine(end(array));//виводимо номер останнього рядка в якому кількість додатніх та відємних елеменків співпадає
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}