using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plural
{
    public class ThrowAwayGradeBook : GradeBook 
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook : ComputeStatistics");
            float lowestGrade = float.MaxValue;
            foreach (var grade in grades)
            {
                lowestGrade = Math.Min(grade, lowestGrade);
            }
            grades.Remove(lowestGrade);//asa vom scoate cea mai mica nota din tabel
            return base.ComputeStatistics();
        }
    }
}
