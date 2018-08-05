using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plural
{
    public class GradeBook : GradeTracker
    {
       
        public GradeBook() 
        {
            _name = null;
            grades = new List<float>(); //de fiecare data cand instantiam GradeBook, sa ne creeze o lista noua de grades
        }

        protected List<float> grades;

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook : ComputeStatistics");
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach (var grade in grades)
            {
                sum += grade;
                stats.HightestGrade = Math.Max(grade, stats.HightestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }
        public override void ShowGrades(TextWriter description)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                description.WriteLine(grades[i - 1]);
            }
        }
        /// <summary>
        /// metoda asta pur si simplu trece prin lista ta de note, ca sa poti folosi foreach mai departe 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
    }
}
