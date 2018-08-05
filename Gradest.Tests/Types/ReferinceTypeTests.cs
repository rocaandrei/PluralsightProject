using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plural;

namespace Gradest.Tests.Types
{
    [TestClass]
    public class ReferinceTypeTests
    {
        /// <summary>
        /// Verificam daca au aceeasi referinta in campul Name
        /// </summary>
        [TestMethod]
        public void GradeBookVaribablesHoldReferince()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "scot grade book";
            Console.WriteLine(g2.Name);
            Assert.AreNotEqual(g1.Name, g2.Name);//e true pentru ca initialieze mai sus din nou g1
        }
        [TestMethod]
        public void IntVariableHoldValue()
        {
            int x1 = 100;
            int x2 = x1;
            x1 = 4;
            Assert.AreNotEqual(x1, x2);
             

        }
        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";
            //comparam cele doua stringuri si ignoram ca unul e scris cu litera mare si unul cu litera mica folosind enum-ul din System = StringComparison, altfel ar da false pentru ca nu sunt identice stringurile 
            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ReferencesTypePassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = new GradeBook();
            book2 = book1;

            AddBookName(book2);
            Assert.AreEqual(book1.Name, book2.Name);//pentru ca ia valoarea lui book1.Name
        }

        private void AddBookName(GradeBook book)
        {
            book.Name = "Andrei grade book";
        }
        /// <summary>
        /// testul de jos demonsteaza ca tipul valoare nu se schimba = noi modificam x-ul in metoda de mai jos dar x-ul initial ramane neschimbat, de 46
        /// </summary>
        [TestMethod]
        public void ValueTypePassByValue()
        {
            int x = 46;
            IncrementNumber(x);
            Assert.AreEqual(46, x);

        }
        private void IncrementNumber(int number)
        {
            number += 1;
        }
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date.AddDays(1);//pica (faild) pentru ca aici construieste o valoare noua
            //asa nu pica
            date = date.AddDays(1);
            Assert.AreEqual(2, date.Day);
        }
        [TestMethod]
        public void UppercaseString()
        {

        }
    }
   
}
