using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file_1
{
    class Program
    {
        /*
         заданій файл f1 створюємо f2 в який записуємо занчення за таким правилом: замість групи чисел одного знаку, що йдуть підряд у файлі f1 у файл f2 
         записуємо суму цих чисел, замість групи нулів - один нуль.
         */
        static void input_f1(string f)// метод для заповнення файлу
        {
            string ff = f + "f.dat";
            BinaryWriter data;
            try
            {
                data = new BinaryWriter(new FileStream(ff, FileMode.Create));// створюєсто новий файл та відкриваємо його
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                return;
            }
            try
            {
                data.Write(0);// записуємо данні у файл в двійковій системі 
                data.Write(7);
                data.Write(6);
                data.Write(0);
                data.Write(0);
                data.Write(0);
                data.Write(-1);
                data.Write(-9);
                data.Write(9);
                data.Write(-34);
                data.Write(-98);
                data.Write(0);
                data.Write(0);
                data.Write(-5);
                data.Write(5);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                data.Close();// закриваємо файл
            }
        }
        static string ex(string n)//цикл для вводу імя файлу
        {
            string f;
            do
            {
                Console.WriteLine("введіть імя файлу");
                f = n + Console.ReadLine();// зчитуємо імя файлу
            } while (!File.Exists(f));// перевіряємо чи такий файл існує
            return f;// повертаємо шлях файлу
        }
        static void read_f1(string f)// метод для підрахунку суми чесел з однаковим знаком які стоять підряд 
        {
            BinaryReader datar;
            try
            {
                datar = new BinaryReader(new FileStream(f, FileMode.Open));// відкриваємо файл для зчитування
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            int i1 = datar.ReadInt32();// зчикуємо перше число з файлу
            int i2;
            int sum = i1;// суму присвоюємо першому елементу
            try
            {
                for (; ; )// проходимо нескінченним циклом по всьому фалу
                {
                    if (i1 == 0)
                    {
                        while ((i1 = datar.ReadInt32()) == 0)// поки елементи 0 пропускаємо їх
                        {
                        }
                        Console.WriteLine("0");// виводимо 0
                        write_f(0, f);// записуємо в файл 0
                        sum = i1;// присвоюємо сумі значення елемента який зчитали 
                    }
                    i2 = datar.ReadInt32();// зчитуємо наступний елемент 
                    if (i1 * i2 > 0)// перевіряємо чи вони одного знаку 
                    {
                        sum = sum + i2;// якщо так то додаємо
                    }
                    else
                    {
                        write_f(sum, f);// записуємо в файл суму якщо різна знаки у чисел 
                        Console.WriteLine(sum);// виводимо суму на екран 
                        sum = i2;// присваюємо друге значення сумі
                    }
                    i1 = i2;// першому значенню присваюємо друге 
                }
            }
            // якщо дійшли до кінця файлу і пробуємо далі щось із ним робити, виникає таке виключення
            catch (EndOfStreamException)
            {
                if (sum != 0)// якщо сума не нуль
                {
                    write_f(sum, f);// взаписуємо в файл 0
                    Console.WriteLine(sum);// виводимо 0
                }
            }
            finally
            {
                datar.Close();// закриваємо файл
            }
        }
        static void write_f(int sum, string f)// метод для запису в файл
        {
            string ff = f + "f1.dat";
            BinaryWriter dataf2;
            try
            {
                dataf2 = new BinaryWriter(new FileStream(ff, FileMode.Create));// відкриваємо файл для запису
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            try
            {
                dataf2.Write(sum);// записуємо суму в файл 
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                dataf2.Close();// закриваємо файл
            }
        }
        static void Main(string[] args)
        {
            try
            {
                string f = @"E:\file\";// шлях до початкового файлу
                input_f1(f);//метод для запису початкового файлу
                read_f1(ex(f));//метод для зчитування з початкового файлу
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
