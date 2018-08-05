using System;

namespace Plural
{
    public class GradeStatistics
    {
        public float HightestGrade;
        public float LowestGrade;
        public float AverageGrade;
        public string LetterGrade
        {
            get
            {
                double roundNo = Math.Round(AverageGrade);
                string value;
                if (roundNo >= 90)
                {
                    value = "A";
                }
                else if (roundNo >= 80)
                    value = "B";
                else if (roundNo >= 70)
                    value = "C";
                else if (roundNo >= 60)
                    value = "D";
                else
                    value = "F";

                return value;
            }
        }
        public string Description
        {
            get
            {
                string result = "";
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excelent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;
                    default:
                        result = "Failing";
                        break;
                }
                return result;
            }
        }

        public GradeStatistics()
        {
            HightestGrade = 0;
            LowestGrade = float.MaxValue;
            AverageGrade = 0;
        }
    }
}