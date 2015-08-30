using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_1
{
    class Fraction : Numbers
    {
        // конструктори
        public Fraction() : base(0, 1) { }
        public Fraction(int num) : base(num, 1) { }
        public Fraction(int num, int den)
        {
            if (den == 0)
            {
                throw new DivideByZeroException();
            }
            number_1 = num;
            number_2 = den;
        }
        //методи
        public static void Reduce(Fraction c)//пошука НСД і скорочення
        {
            //для знаходження НСД використаємо алгоритм Евкліда
            int copyChiselnuk3;
            int copyZnamennuk3;
            copyChiselnuk3 = c.number_1; //зробимо копії змінних
            copyZnamennuk3 = c.number_2;
            while (copyChiselnuk3 != copyZnamennuk3)//поки чисельник не дорівнює знаменнику
            {
                if (copyChiselnuk3 > copyZnamennuk3)//порівняємо яке значення більше і від більшого віднімемо менше
                {
                    copyChiselnuk3 = copyChiselnuk3 - copyZnamennuk3;
                }
                else
                {
                    copyZnamennuk3 = copyZnamennuk3 - copyChiselnuk3;
                }
            }
            //поділимо чисельник і знаменник на НСД, тим самим скоротивши дріб
            c.number_1 = c.number_1 / copyChiselnuk3;
            c.number_2 = c.number_2 / copyChiselnuk3;
        }
        public static void Deceive(Fraction first, Fraction second)//метод зводить дроби до спільного знаменника
        {
            int znamennuk = first.number_2 * second.number_2;//результат добуток знаменників
            first.number_1 = second.number_2 * first.number_1;//при зміненні знаменника змінюється і чисельник відповідним чином 
            second.number_1 = first.number_2 * second.number_1;//домножимо чисельник на знаменник іншого дробу 
            first.number_2 = first.number_2 * second.number_2;
            second.number_2 = first.number_2;
        }
        //перегрузки операторів
        public static Fraction operator +(Fraction first, Fraction second)
        {
            if (first.number_2 != second.number_2)
            {
                Deceive(first, second);
            }
            Fraction a = new Fraction(first.number_1 + second.number_1, first.number_2);
            Reduce(a);
            return a;
        }
        public static Fraction operator -(Fraction first, Fraction second)
        {
            if (first.number_2 != second.number_2)//коли знаменник рівні, то в залежності від знака виконаємо дію
            //якщо знаменники нерівні
            {
                Deceive(first, second);
            }
            Fraction a = new Fraction(first.number_1 - second.number_1, first.number_2);
            Reduce(a);
            return a;
        }
        public static Fraction operator *(Fraction first, Fraction second)
        {
            Fraction a = new Fraction(first.number_1 * second.number_1, first.number_2 * second.number_2);
            Reduce(a);
            return a;
        }
        public static Fraction operator /(Fraction first, Fraction second)
        {
            if (second.number_1 == 0)
            {
                throw new DivideByZeroException();
            }
            int chiselnuk = first.number_1 * second.number_2;//чисельник першого дробу множимо на знаменник другого
            int znamennuk = first.number_2 * second.number_1;//знаменник першого дробу множимо на чисельник другогo
            Fraction c = new Fraction(chiselnuk, znamennuk);
            Fraction.Reduce(c);
            return c;

        }
        //перевантаження перевірок на більше-менше, використовуємо метод Compare
        public static bool operator >(Fraction first, Fraction second)
        {
            return first.Compare(second) > 0;
        }
        public static bool operator <(Fraction first, Fraction second)
        {
            return first.Compare(second) < 0;
        }
        public static bool operator <=(Fraction first, Fraction second)
        {
            return first.Compare(second) <= 0;
        }
        public static bool operator >=(Fraction first, Fraction second)
        {
            return first.Compare(second) >= 0;
        }
        //перевантаження операторів рівності-нерівності, використовуємо метод Compare
        public static bool operator ==(Fraction first, Fraction second)
        {
            return first.Compare(second) == 0;
        }
        public static bool operator !=(Fraction first, Fraction second)
        {
            return first.Compare(second) != 0;
        }

        public override string ToString()
        {
            if (this.number_2 == 1) return String.Format("{0}", this.number_1);
            return String.Format("{0}/{1}", this.number_1, this.number_2);
        }//перевантажуємо метод для перетворення об'єкта в рядок
        private int Compare(Fraction other) // метод є базовим для перевантаження порівнянь
        {
            double first = this.number_1 / this.number_2;
            double second = other.number_1 / other.number_2;
            if (first > second) return 1;
            if (first < second) return -1;
            return 0;
        }
        public override bool Equals(object obj)
        {
            if (this == obj) return true;//якщо ссилки однакові
            if (!(obj is Fraction)) return false;//якщо об'єкт не налажить класу
            if (this.Compare((Fraction)obj) == 0) return true;//порівнюємо значення
            return false;
        }
    }
}
