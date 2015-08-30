using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_1
{
    class Numbers
    {
        //поля
        protected int number_1;//перше число
        public int Numerator_1//властивість читає перше число
        {
            get { return number_1; }
        }
        protected int number_2;//друге число
        public int Number_2 //властивість читає друге число
        {
            get { return number_2; }
        }
        // конструктори
        public Numbers() : this(0, 0) { }
        public Numbers(int i, int j)
        {
            this.number_1 = i;
            this.number_2 = j;
        }
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is Numbers)) return false;
            Numbers r = (Numbers)obj;
            return number_1 == r.number_1 && number_2 == r.number_2;
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", this.number_1, this.number_2);
        }
    }
}
