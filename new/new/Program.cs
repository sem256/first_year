using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @new
{
   

        public abstract class Parent
        {

            public int Id { get; protected set; }
            public abstract string IdToString();
        }

        public class Child : Parent
        {

            public Child()
            {

                Random random = new Random(0);
                Id = random.Next(0, 1000);
            }

            public override string IdToString()
            {

                return Id.ToString();
            }
        }

        public class ChildChild : Child
        {

            public ChildChild()
            {

                Random random = new Random(1);
                Id = random.Next(0, 1000);
            }

            public override string IdToString()
            {

                return Id.ToString();
            }
        }
        class Program
        {

        static void Main(string[] args)
        {

            Child child = new Child();
            Console.WriteLine(child.IdToString());
            Console.WriteLine(child.IdToString());
            Console.WriteLine();
            ChildChild childChild = new ChildChild();
            Console.WriteLine(childChild.IdToString());
            Console.WriteLine(childChild.IdToString());
            Console.ReadKey();
        }
    }
}
