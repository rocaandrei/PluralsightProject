using System.Collections;
using System.IO;

namespace Plural
{
    public interface IGradeTracker : IEnumerable//te ajuta sa enumerezi un obiect, ca un list sau array
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void ShowGrades(TextWriter description);
        string Name { get; set; }
    }
}