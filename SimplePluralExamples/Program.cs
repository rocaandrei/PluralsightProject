using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePluralExamples
{
    public delegate int BizRulessProcessDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            ProcessData pro = new ProcessData();

            BizRulessProcessDelegate addDelegate = (x, y) => x + y;
            BizRulessProcessDelegate multiplyDelegate = (x, y) => (x * y);
            pro.Process(5, 10, addDelegate);
            pro.Process(5, 10, multiplyDelegate);

            Action<int, int> actionScadereDelegate = (x, y) => Console.WriteLine(x - y); ;
            pro.ProcessAction(5, 10, actionScadereDelegate);
            Func<double, double, double> actionDivideDelegate = (x, y) => x / y;
            pro.ProcessFunc(5, 10, actionDivideDelegate);
            //ReadFromTxt();

           //nu ma prind exact care e treaba aici 
            pro.BizRulessEvent += Pro_BizRulessEvent2;
            pro.BizRulessEvent += (x, y) => x + y + 100;
            pro.ProcessEvent(5, 10);
        }

        private static int Pro_BizRulessEvent2(int x, int y)
        {
            Console.WriteLine("face ceva...");
                return 200;
        }

        private static int Pro_BizRulessEvent1(int x, int y)
        {
            return 99;
        }

        private static int Pro_BizRulessEvent(int x, int y)
        {
            return x + y;
        }

        private static void ReadFromTxt()
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
        public static void TestMethod(int nr)
        {
            if (nr == 0)
            {
                ArgumentException ex = new ArgumentException("Avem introdus 0");
                throw ex;
            }
        }
    }
}
