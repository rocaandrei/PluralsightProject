using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Plural
{
    class Program
    {
        static void Main(string[] args)
        {
          
            #region Some commented code
            ////  SpeechSynthesizer speech = new SpeechSynthesizer();
            ////  speech.Speak("Hello this is the Grade Book program.");
            //  

            //  //chemam delegatul din clasa GradeBook, legat de obiectul nostru definit mai sus 
            //  //mai jos facem multicast cu +=

            //  book1.NameChanged += new NameChangedDelegate(OnNameChanged2);
            //  //pentru a face abonarea la un event, trebuie neaparat += si nu poate fi legat de null

            //book1.NameChanged2 += OnNameChanged3;
            //book1.NameChanged2 += OnNameChanged3;
            //book1.NameChanged2 -= OnNameChanged3;
            //book1.Name = "Titlu nou";//se apeleaza cand folosim delegatul
            //book1.Name = "Scott name book";// se apeleaza cand folosim delegatul
            #endregion
       
            GradeBook book1 = new ThrowAwayGradeBook();
            book1.NameChanged += new NameChangedDelegate(OnNameChanged);
         
            Console.WriteLine(book1.BookColor.Red);
            Console.WriteLine(book1.BookColor.Green);
            GetBookName(book1);
            AddGrades(book1);
            SaveToFileGrades(book1);//salvezi in fisierul tau txt! 
            WriteResults(book1);

            // book1.ShowGrades(Console.Out);

            GradeBook carte = new GradeBook();
            carte.Name = "Nume carte nou";
            carte.NameChanged2 += OnNameChanged;
            carte.Name = "Nume dupa event...";
        }

        private static void WriteResults(IGradeTracker book)
        {
            Console.WriteLine("All the Grades");
            GradeStatistics stats = book.ComputeStatistics();
            foreach (var grade in book)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine("-----------------------------");
            WriteResult("Max val", stats.HightestGrade);
            WriteResult("Min val", (int)stats.LowestGrade);
            WriteResult("Average val", stats.AverageGrade);
            WriteResult("Letter description", stats.Description, stats.LetterGrade);
        }

      
        private static void SaveToFileGrades(IGradeTracker book1)
        {
            //ca sa salvam un text, intr-un fisier txt facut de noi
            using (StreamWriter outputFile = File.CreateText("grades.txt"))//il face el automat in folderul proiectului, daca nu ii dai calea
            {
                book1.ShowGrades(outputFile);//console.out = o sa iti returneze textul in functie de preferintele tale vizuale, inconsola, in fisier etc.
                outputFile.Close();//pentru a nu corupe executia si a fi sigur ca informatia este salvata in fisierul nostru, trebuie sa inchidem fisierul dupa executie
            }
        }

        private static void AddGrades(IGradeTracker book1)
        {
            book1.AddGrade(75.40F);
            book1.AddGrade(45);
            book1.AddGrade(89.8F);
        }

        private static void GetBookName(IGradeTracker book1)
        {
            Console.WriteLine("Enter user name: ");
            while (book1.Name == null)
            {
                try
                {
                    book1.Name = Console.ReadLine();
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong");// eroarea asta se va prinde atunci cand ajunge la linia din GradeBook legata de event-ul NameChanged
                }
            }
        }
        #region subscriberi
        /// <summary>
        /// metoda asta o folosim pentru a avea semantura ca parametrul nostru din delegate sau event
        /// </summary>
        /// <param name="existingName"></param>
        /// <param name="newName"></param>
        private static void OnNameChanged(object obj, NameChangedEventArgs args)
        {
            Console.WriteLine($"The initial book name: {args.ExistingName}, the new book name: {args.NewName} ");
        }
        private static void OnNameChanged2(object obj, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }
        private static void OnNameChanged3(object obj, NameChangedEventArgs args)
        {
            Console.WriteLine("***METODA CHEMATA FOLOSIND EVENT NU DELGATE DIRECT");
        }
        #endregion
        #region WriteResult method 
        private static void WriteResult(string description, string str1, char str2)
        {
            Console.WriteLine(description + ": " + str1 + "-"+ str2);
        }

        static void WriteResult(string str, string nr)
        {
            Console.WriteLine(str + ": " + nr);
        }
        static void WriteResult(string str, char ch)
        {
            Console.WriteLine(str + ": " + ch);
        }
        static void WriteResult(string someTxt, string description, string grade)
        {
            Console.WriteLine($"{someTxt}: {description}-{grade}");
        }
        static void WriteResult(string str, float nr)
        {
            Console.WriteLine(str + ": " + nr);
        }
        static void WriteResult(string str, int nr)
        {
            Console.WriteLine(str + ": " + nr);
        }
    }
    #endregion
}
