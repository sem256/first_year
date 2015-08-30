using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_1
{
    enum znak_1 { Capricorn, Aquarius, Pisces, Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius };// список знакив зодіака за зростанням
    class Conteiner
    {
        public delegate int Compare(Znak a, Znak b);//делегат
        private Znak[] mas;
        public Conteiner(Znak[] mas)// конструктор
        {
            this.mas = mas;
        }
        public Znak this[int index]// індексатор
        {
            get
            {
                if ((index < 0) || (index >= mas.Length))
                    throw new IndexOutOfRangeException("Індекс вийшов за межі масиву))");
                return mas[index];
            }
            set
            {
                if ((index < 0) || (index >= mas.Length))
                    throw new IndexOutOfRangeException("Індекс вийшов за межі масиву");
                mas[index] = value;
            }
        }
        public void Sort(Compare w, Znak[] mass)//метод який доступній зовні 
        {
            this.QuickSort(mass, 0, mass.Length - 1, w);//сотрування 
        }
        private void QuickSort(Znak[] a, int L, int R, Compare w)
        {	//метод сортування 
            int i = L; int j = R;//ліва та права межі
            while (w(a[i], a[(L + R) / 2]) < 0) i++;
            while (w(a[j], a[(L + R) / 2]) > 0) j--;
            if (i <= j)
            {
                if (i < j) Swap(ref a[i], ref a[j]);
                i++;
                j--;
            }
            if (R > i) QuickSort(a, i, R, w);
            if (L < j) QuickSort(a, L, j, w);
        }
        private void Swap(ref Znak a, ref Znak b)
        {	//метод міняє місцями записи
            Znak t = a;
            a = b;
            b = t;
        }
        public Znak[] Add(Znak a)
        {
            int i = 0;
            while (i < this.mas.Length)
            {
                if (this[i].surname == null)
                {
                    this[i] = a;
                    break;
                }
                i++;
            }
            return this.mas;
        }
        public void Display()
        {
            for (int i = 0; i < this.mas.Length; i++)
                Console.WriteLine(this.mas[i]);
        }
    }
    struct Znak
    {
        public string surname;
        public string name;
        public int zodiac_signs;
        public int[] jear;
        public Znak(string a, string b, int c, int[] j)// конструктор з параметрами
        {
            this.surname = a;
            this.name = b;
            this.zodiac_signs = c;
            this.jear = j;
        }
        public Znak(Znak a)// конструктор з параметрами
        {
            this.surname = a.surname;
            this.name = a.name;
            this.zodiac_signs = a.zodiac_signs;
            this.jear = a.jear;
        }
        public string Seasons // властивість котра повертає пору року    
        {

            get
            {
                if ((jear[1] == 12) || ((jear[1] > 0) && (jear[1] <= 2)))
                    return "Winter";
                if ((jear[1] > 2) && (jear[1] <= 5))
                    return "Spring";
                if ((jear[1] > 5) && (jear[1] <= 8))
                    return "Summer";
                return "Autumn";
            }
        }
        //властивості
        public static Conteiner.Compare Name
        {
            get 
            {
                return new Conteiner.Compare(Compare_Name);
            }
        }
        public static Conteiner.Compare Surname
        {
            get
            {
                return new Conteiner.Compare(Compare_Surmane);
            }
        }
        public static Conteiner.Compare Znakk
        {
            get
            {
                return new Conteiner.Compare(Compare_Znak);
            }
        }
        public static Conteiner.Compare Birthday
        {
            get
            {
                return new Conteiner.Compare(Compare_Birthday);
            }
        }
        public static int Compare_Birthday(Znak a, Znak b)
        {	//a<b - -1, a == b - 0, a>b - 1;
            if (a.jear[2] > b.jear[2]) return 1;
            if (a.jear[2] < b.jear[2]) return -1;
            if (a.jear[1] > b.jear[1]) return 1;
            if (a.jear[1] < b.jear[1]) return -1;
            if (a.jear[0] > b.jear[0]) return 1;
            if (a.jear[0] < b.jear[0]) return -1;
            return 0;	//якщо рівні
        }
        public static int Compare_Znak(Znak a, Znak b)// порівнюємо за знаком
        {
            if (a.zodiac_signs > b.zodiac_signs) return 1;
            if (a.zodiac_signs < b.zodiac_signs) return -1;
            return 0;	//якщо рівні
        }
        public static int Compare_Name(Znak a, Znak b)// порівнюємо за імям
        {
            return string.Compare(a.name, b.name);
        }
        public static int Compare_Surmane(Znak a, Znak b)// порівнює за прізвище
        {
            return string.Compare(a.surname, b.surname);
        }
        public static int Compare_Surname_Name_Znak_Birthday(Znak a, Znak b)// порівнюємо спочатку за прізвищем за імям знаком та за датою народження
        {
            if (Compare_Surmane(a, b) != 0)
                return Compare_Surmane(a, b);
            if (Compare_Name(a, b) != 0)
                return Compare_Name(a, b);
            if (Compare_Znak(a, b) != 0)
                return Compare_Znak(a, b);
            if (Compare_Birthday(a, b) != 0)
                return Compare_Birthday(a, b);
            return 0;
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
            string v = "Surname: " + surname + "\n" + "Name: " + name + "\n" + "Zodiac signs: " + s + "\n" + "birthday: " + jear[0] + "," + jear[1] + "," + jear[2] + "\n" + Seasons;
            return v;
        }

    }
    class Program
    {

        public static void In_Put(Znak[] z)
        {
            for (int i = 0; i < z.Length - 1 ; i++)
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
                    Console.WriteLine("enter your the jear when you were born:");
                }
                while (!int.TryParse(Console.ReadLine(), out jear[2]) || (jear[2] < 0));
                z[i].jear = jear;
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Znak[] z = new Znak[3];// масив структур
                In_Put(z);// метод для заповнення
                Conteiner test = new Conteiner(z);
                int[] birth = new int[3] { 20, 9, 1995 };

                Znak newnote = new Znak("Sem", "Matvienko", 2, birth);
                test.Add(newnote);
 
                test.Sort(Znak.Compare_Surname_Name_Znak_Birthday, z);
                Console.WriteLine("");
                test.Display();
                //for (int i = 0; i < z.Length; i++)// виводимо на екран вже відсортовані данні
                //{
                //    Console.WriteLine(z[i].ToString());
                //}
                Console.WriteLine("Surname Name Znak Birthday");
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
                    if (m == z[i].jear[1])
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
