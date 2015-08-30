using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file_2
{
    class Program
    /*
     маємо файл f1 створюємо f2 та f3 до файлу f2 записуємо з кожного рядка n слів (n - вводимо з клавіатури) а до файлу f3 записуємо решту рядка якщо n більше ніж
     довжіна рядка то пропускаємо рядок.
     */
    {

        static void read_f1(string ff, string f, int n)//метод для зчитування слів з файлу
        {
            string f2 = f + "f2.txt";
            string f3 = f + "f3.txt";
            StreamReader st;
            StreamWriter s2;
            StreamWriter s3;
            try
            {
                st = new StreamReader(ff);// відкриваємо файл для зчитування
                s2 = new StreamWriter(f2);//видкріваємо файл для запису та для до запису
                s3 = new StreamWriter(f3);//видкріваємо файл для запису та для до запису
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            try
            {
                string s, m = "", k = "";
                char[] seps = { ' ' };// знаки розділювачі за якими ми розбиваємо строку на слова
                string[] part;//масив в який ми заносимо слова
                while ((s = st.ReadLine()) != null)// превіряємо на кінець файла
                {
                    part = s.Split(seps, StringSplitOptions.RemoveEmptyEntries);//записуємо в масив слова між яками є розділвач пробіл
                    if (n > part.Length)// якщо слів в рядку менше ніж задане число
                    {
                        s2.WriteLine(s);
                        s3.WriteLine("");
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)// цикл пряцює до n слова 
                        {
                            m = m + part[i] + " ";// робимо один рядок з n слів
                        }
                        s2.WriteLine(m);
                        m = "";
                        for (int i = n; i < part.Length; i++)//цикл пряцює з n слова до кінця рядка
                        {
                            k = k + part[i] + " ";// робимо один рядок з слів які залишилися після n слова 
                        }
                        s3.WriteLine(k);
                        k = "";
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                st.Close();
                s2.Close();
                s3.Close();
            }
        }
        static int number()
        {
            int n = -1;
            while (n < 0)// перевіряємо на правельність вводу числа
            {
                Console.WriteLine("введіть кількість слів");
                n = int.Parse(Console.ReadLine());// зчитуємо чмсло і перетворюємо його в int  
            }
            return n;
        }
      
        static string check(string f)//цикл для вводу імя файлу
        {
            string ff;
            do
            {
                Console.WriteLine("введіть імя файлу");
                ff = f + Console.ReadLine();// зчитуємо імя файлу
            } while (!File.Exists(ff));// перевіряємо чи такий файл існує
            return ff;// повертаємо шлях файлу
        }
        static void Main(string[] args)
        {
            try
            {
                string f = @"E:\file_1\";
                string ff = check(f);
                int n = number();
                read_f1(ff, f, n);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
