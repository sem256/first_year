using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_1
{
    class Complex : Numbers
    {
        // конструктори
        public Complex() : base(0, 0) { }
        public Complex(int i, int j)
        {
            this.number_1 = i;
            this.number_2 = j;
        }
        // Перевантаження арифметичних операцій
        public static Complex operator +(Complex a, Complex b)// додавання
        {
            Complex k = new Complex();
            k.number_1 = a.number_1 + b.number_1;
            k.number_2 = a.number_2 + b.number_2;
            return k;
        }
        public static Complex operator -(Complex a, Complex b)// віднімання
        {
            Complex k = new Complex();
            k.number_1 = a.number_1 - b.number_1;
            k.number_2 = a.number_2 - b.number_2;
            return k;
        }
        public Complex Root(double n)// добування кореня
        {
            Complex k = new Complex();
            double f = Math.Acos(this.number_1 / Modul());// знаходимо кут фі
            double r = Math.Pow(Modul(), 1 / n);// перемо корінь від радіуса
            k.number_1 = (int)Math.Round((r * Math.Cos(f / n)));// дійсна частина 
            k.number_2 = (int)Math.Round((r * Math.Sin(f / n)));// уявна частиина
            return k;
        }
        public Complex Pow(double n)// пінносимо в степінь
        {
            Complex k = new Complex();
            double f = Math.Acos(this.number_1 / Modul());// знаходимо кут фі
            double r = Math.Pow(Modul(), n);// підносимо до кореня радіус
            k.number_1 = (int)(Math.Round(r * Math.Cos(f * n)));// дійсна частина
            k.number_2 = (int)(Math.Round(r * Math.Sin(f * n)));// уявна частиина
            return k;
        }
        public Complex conjugate()// спряжене число
        {
            Complex k = new Complex();
            k.number_1 = this.number_1;
            k.number_2 = -this.number_2;
            return k;
        }

        public double Modul()//повертає модуль
        {
            return Math.Sqrt(this.number_1 * this.number_1 + this.number_2 * this.number_2);
        }
        public static Complex operator *(Complex a, Complex b)//множення двох компл. чисел
        {
            Complex k = new Complex();
            k.number_1 = a.number_1 * b.number_1 - b.number_2 * a.number_2;
            k.number_2 = a.number_1 * b.number_2 + a.number_2 * b.number_1;
            return k;
        }
        public static Complex operator /(Complex a, Complex b)//ділення комплексних чисел
        {
            if ((b.number_1 == 0) && (b.number_2 == 0)) { throw new DivideByZeroException(); }
            Complex k = new Complex();
            k.number_1 = (int)((a.number_1 * b.number_1 + a.number_2 * b.number_2) / b.Modul());
            k.number_2 = (int)((a.number_2 * b.number_1 - a.number_1 * b.number_2) / b.Modul());
            return k;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Complex)) return false;
            if (obj == this) return true;
            Complex r = (Complex)obj;
            return number_1 == r.number_1 && number_2 == r.number_2;
        }
        public static implicit operator Complex(int value)//перетворення типів
        {
            return new Complex(value, 0);
        }
        public static explicit operator int(Complex value)//перетворення типів
        {
            if (value.number_2 != 0) throw new OverflowException("уявна частина не 0");
            return (int)value.number_1;
        }
        public override string ToString()
        {
            return string.Format("({0:F1},{1:F1})", number_1, number_2);
        }

    }
}
