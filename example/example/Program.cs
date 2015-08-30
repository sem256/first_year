using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter dataOut;
            BinaryReader dataIn;

            string item; // назва товару 
            int onhand;  // наявна кількість 
            double cost; // вартість 

            try // створюємо файл, відкриваємо його на запис
            {
                dataOut = new BinaryWriter(new FileStream("inventory.dat", FileMode.Create));
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "\nНеможливо відкрити файл для запису.");
                return;
            }

            // Записуємо інформацію до файлу. 
            try
            {
                dataOut.Write("Молотки");
                dataOut.Write(10);
                dataOut.Write(3.95);

                dataOut.Write("Викрутки");
                dataOut.Write(18);
                dataOut.Write(1.50);

                dataOut.Write("Кусачки");
                dataOut.Write(5);
                dataOut.Write(4.95);

                dataOut.Write("Пили");
                dataOut.Write(8);
                dataOut.Write(8.95);
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "\nПомилка запису.");
            }

            dataOut.Close(); // закриваємо потік

            Console.WriteLine();

            // Відкриваємо файл ще раз, тепер для зчитування. 
            try
            {
                dataIn = new BinaryReader(new FileStream("inventory.dat", FileMode.Open));
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message + "\nНеможливо відкрити файл для зчитування.");
                return;
            }

            // Шукаємо елемент, визначений користувачем. 
            Console.Write("Введіть назву товару для пошуку: ");
            string what = Console.ReadLine();
            Console.WriteLine();

            try
            {
                // Тут той випадок, коли простіше перервати цикл або обробити виключення, 
                // ніж перевіряти у циклі ще одну умову (чи дійшли до кінця файлу) - 
                // оскільки ми зчитуємо декілька значень за один прохід циклу
                for (; ; )
                {
                    // Зчитуємо запис з файлу. 
                    item = dataIn.ReadString(); // рядок - назва товару
                    onhand = dataIn.ReadInt32();  // ціле - наявна кількість товару
                    cost = dataIn.ReadDouble();  // дійсне - вартість товару

                    /* Якщо елемент з файлу співпадає із введеним, виводимо інформацію про нього */
                    if (item.CompareTo(what) == 0)
                    {
                        Console.WriteLine(onhand + " " + item + " у наявності. " +
                                          "ціна: {0:C} за кожен", cost);
                        Console.WriteLine("Загальна вартість товару {0}: {1:C}.",
                                          item, cost * onhand);
                        break;
                    }
                }
            }
            // якщо дійшли до кінця файлу і пробуємо далі щось із ним робити, виникає таке виключення
            catch (EndOfStreamException)
            {
                Console.WriteLine("Товар не знайдено.");
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "Помилка зчитування.");
            }

            dataIn.Close(); // закриваємо потік
        }
    }
}
