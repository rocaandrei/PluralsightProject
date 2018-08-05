using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plural;

namespace Gradest.Tests
{
    [TestClass]//adaugi atributul ce iti arata ca clasa e de test 
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book1 = new GradeBook();
            book1.AddGrade(10);
            book1.AddGrade(90);
            GradeStatistics test = book1.ComputeStatistics();

            Assert.AreEqual(test.AverageGrade, 50);
            Assert.AreEqual(test.HightestGrade, 90);
        }


        [TestMethod]
        public void ComputeLowestGrade()
        {
            GradeBook book1 = new GradeBook();
            book1.AddGrade(10);
            book1.AddGrade(90);
            GradeStatistics test = book1.ComputeStatistics();
            Assert.AreEqual(test.LowestGrade, 10);
        }
        [TestMethod]
        public void ComputeLetterGrade()
        {
            GradeBook book1 = new GradeBook();
            book1.AddGrade(75);
            book1.AddGrade(45);
            book1.AddGrade(89.8F);
            GradeStatistics test = book1.ComputeStatistics();
            Assert.AreEqual(test.LetterGrade, "C");
        }
    }
}

