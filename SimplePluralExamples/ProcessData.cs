using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePluralExamples
{
    public class ProcessData
    {
        public event BizRulessProcessDelegate BizRulessEvent;
        public ProcessData()
        {

        }
        public void Process(int x, int y, BizRulessProcessDelegate del)
        {
            var result = del(x, y); //aici invocam delegat-ul si facem operatiile matematice cum vrem noi, pe baza del
            Console.WriteLine(result);
        }
        public void ProcessAction(int x, int y, Action<int, int> del)
        {
            del(x, y);
        }
        public void ProcessFunc(int x, int y, Func<double, double, double> del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessEvent(int x, int y)
        {
            var result = BizRulessEvent?.Invoke(x, y);
            Console.WriteLine(result);
        }
    }
}
