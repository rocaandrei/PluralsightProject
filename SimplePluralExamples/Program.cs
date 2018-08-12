using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePluralExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //linia de jos: avem un string[] ce citeste linile din fisierul txt si ni le pune in array
            string[] lines = File.ReadAllLines("TextFile.txt");
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
        }

        private static int Execute(int a)
        {
            int c;
            int b = int.Parse(Console.ReadLine());
            c = a / b;
            return c;
        }

        public static void SomeCode(int no)
        {
            for (int i = 1; i < no; i++)
            {
                Console.WriteLine(no);
                if (i == 3)
                {
                    return;
                }
            }
        }
        public static void  TestMethod(int nr)
        {
            if(nr == 0)
            {
                ArgumentException ex = new ArgumentException("Avem introdus 0");
                throw ex;
            }
        }
    }
}
