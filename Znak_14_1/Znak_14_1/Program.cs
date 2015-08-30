using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znak_14_1
{
    enum znak_1 { Capricorn, Aquarius, Pisces, Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius };// список знакив зодіака за зростанням

    struct Znak
    {
        public string surname;
        public string name;
        public int zodiac_signs;
        public int[] year;
        public Znak(string a, string b, int c, int[] j)// конструктор з параметрами
        {
            surname = a;
            name = b;
            zodiac_signs = c;
            year = j;
        }
        public string Seasons // властивість котра повертає пора року    
        {
            get
            {
                if ((year[1] == 12) || ((year[1] > 0) && (year[1] <= 2)))
                    return "Winter";
                if ((year[1] > 2) && (year[1] <= 5))
                    return "Spring";
                if ((year[1] > 5) && (year[1] <= 8))
                    return "Summer";
                return "Autumn";
            }
        }

        public static int Compare_Birthday(Znak a, Znak b)
        {	//a<b - -1, a == b - 0, a>b - 1;
            if (a.year[2] > b.year[2]) return 1;
            if (a.year[2] < b.year[2]) return -1;
            if (a.year[1] > b.year[1]) return 1;
            if (a.year[1] < b.year[1]) return -1;
            if (a.year[0] > b.year[0]) return 1;
            if (a.year[0] < b.year[0]) return -1;
            return 0;	//якщо рівні
        }



        public static int Compare_Znak(Znak a, Znak b)
        {
            if (a.zodiac_signs > b.zodiac_signs) return 1;
            if (a.zodiac_signs < b.zodiac_signs) return -1;
            return 0;	//якщо рівні
        }
        public override string ToString()
        {
            string s = "";
            switch (zodiac_signs)
            {
                case 0: s = "Capricorn";
                    break;
                case 1: s = "Aquarius";
                    break;
                case 2: s = " Pisces";
                    break;
                case 3: s = "Aries";
                    break;
                case 4: s = "Taurus";
                    break;
                case 5: s = "Gemini";
                    break;
                case 6: s = "Cancer";
                    break;
                case 7: s = "Leo";
                    break;
                case 8: s = "Virgo";
                    break;
                case 9: s = "Libra";
                    break;
                case 10: s = "Scorpio";
                    break;
                case 11: s = "Sagittarius";
                    break;
            }
            string v = "Surname: " + surname + "\n" + "Name: " + name + "\n" + "Zodiac signs: " + s + "\n" + "birthday: " + year[0] + "," + year[1] + "," + year[2] + "\n" + Seasons;
            return v;
        }

    }
    class Program
    {
        static void QuickSort(Znak[] a, int L, int R, string w)
        {	//метод сортування
            int i = L; int j = R;//ліва та права межі
            string x;
            switch (w)	//вибираємо, що сортувати
            {
                case "surname":	//якщо за призвіщем
                    {
                        x = a[(L + R) / 2].surname;
                        while (string.Compare(a[i].surname, x) < 0) i++;
                        while (string.Compare(a[j].surname, x) > 0) j--;
                        break;
                    }
                case "name":	//якщо за ім'ям
                    {
                        x = a[(L + R) / 2].name;
                        while (string.Compare(a[i].name, x) < 0) i++;
                        while (string.Compare(a[j].name, x) > 0) j--;
                        break;
                    }
                case "znak":	//якщо за знаком
                    {
                        while (Znak.Compare_Znak(a[i], a[(L + R) / 2]) < 0) i++;
                        while (Znak.Compare_Znak(a[j], a[(L + R) / 2]) > 0) j--;
                        break;
                    }
                case "birthdate":	//за датою народження
                    {
                        while (Znak.Compare_Birthday(a[i], a[(L + R) / 2]) < 0) i++;
                        while (Znak.Compare_Birthday(a[j], a[(L + R) / 2]) > 0) j--;
                        break;
                    }
                default:
                    { throw new Exception("Error"); }	//якщо ні,
            }
            if (i <= j)
            {
                if (i < j) Swap(ref a[i], ref a[j]);
                i++;
                j--;
            }
            if (R > i) QuickSort(a, i, R, w);
            if (L < j) QuickSort(a, L, j, w);
        }
        static void Swap(ref Znak a, ref Znak b)
        {	//метод міняє місцями записи
            Znak t = a;
            a = b;
            b = t;
        }




        public static void In_Put(Znak[] z)
        {
            for (int i = 0; i < z.Length; i++)
            {
                int[] jear = new int[3];
                Console.WriteLine("Enter your surname");
                z[i].surname = Console.ReadLine();



                Console.WriteLine("Enter your name");
                z[i].name = Console.ReadLine();
                bool t = false;
                do
                {
                    Console.WriteLine("Enter your zodiac sign");
                    string s = Console.ReadLine();
                    switch (s)
                    {
                        case "Capricorn":
                            {
                                z[i].zodiac_signs = (int)znak_1.Capricorn;
                                t = true;
                            }
                            break;
                        case "Aquarius":
                            {
                                z[i].zodiac_signs = (int)znak_1.Aquarius;
                                t = true;
                            }
                            break;
                        case "Pisces":
                            {
                                z[i].zodiac_signs = (int)znak_1.Pisces;
                                t = true;
                            }
                            break;
                        case "Aries":
                            {
                                z[i].zodiac_signs = (int)znak_1.Aries;
                                t = true;
                            }
                            break;
                        case "Taurus":
                            {
                                z[i].zodiac_signs = (int)znak_1.Taurus;
                                t = true;
                            }
                            break;
                        case "Gemini":
                            {
                                z[i].zodiac_signs = (int)znak_1.Gemini;
                                t = true;
                            }
                            break;
                        case "Cancer":
                            {
                                z[i].zodiac_signs = (int)znak_1.Cancer;
                                t = true;
                            }
                            break;
                        case "Leo":
                            {
                                z[i].zodiac_signs = (int)znak_1.Leo;
                                t = true;
                            }
                            break;
                        case "Virgo":
                            {
                                z[i].zodiac_signs = (int)znak_1.Virgo;
                                t = true;
                            }
                            break;
                        case "Libra":
                            {
                                z[i].zodiac_signs = (int)znak_1.Libra;
                                t = true;
                            }
                            break;
                        case "Scorpio":
                            {
                                z[i].zodiac_signs = (int)znak_1.Scorpio;
                                t = true;
                            }
                            break;
                        case "Sagittarius":
                            {
                                z[i].zodiac_signs = (int)znak_1.Sagittarius;
                                t = true;
                            }
                            break;
                        default: t = false;
                            break;
                    }
                } while (!t);

                do //поки не введемо правильну дату
                {
                    Console.WriteLine("enter your the day when you were born:");
                }
                while ((!int.TryParse(Console.ReadLine(), out jear[0]) || (jear[0] < 0) || (jear[0] > 31)));
                do
                {
                    Console.WriteLine("enter your the month when you were born:");
                }
                while ((!int.TryParse(Console.ReadLine(), out jear[1]) || (jear[1] < 0) || (jear[1] > 12)));
                do
                {
                    Console.WriteLine("enter your the year when you were born:");
                }
                while (!int.TryParse(Console.ReadLine(), out jear[2]) || (jear[2] < 0));
                z[i].year = jear;
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Znak[] z = new Znak[2];// масив структур
                In_Put(z);// метод для заповнення
                string w;
                do //вводимо за чим нам сортувати
                {
                    Console.WriteLine("The sort will work for (surname, name, znak ,birthdate):");
                    w = Console.ReadLine();
                }
                while ((w != "name") && (w != "surname") && (w != "znak") && (w != "birthdate"));

                QuickSort(z, 0, z.Length - 1, w);//  сортування масиву

                for (int i = 0; i < z.Length; i++)// виводимо на екран вже відсортовані данні
                {
                    Console.WriteLine(z[i].ToString());
                }
                Console.WriteLine();
                Console.WriteLine("+++++++++++++++++++++++");
                Console.WriteLine();
                int m;	//змінна місяця
                do
                {
                    Console.WriteLine("enter the month he or she was born:");
                }
                while ((!int.TryParse(Console.ReadLine(), out m) || (m < 0) || (m > 12)));

                for (int i = 0; i < z.Length; i++)
                {	//проходимо через всі записи і виводимо на екран данні з заданим місяцем
                    if (m == z[i].year[1])
                        Console.WriteLine(z[i].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
