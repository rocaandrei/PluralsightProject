using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plural
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void ShowGrades(TextWriter description);
       public abstract IEnumerator GetEnumerator();//aici definesti clasa abstracta GetEnumerator ce vine prin interfata IEnumerable 

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");//=exemplu de unhandeld exception
                }
                if (_name != value)//verificam daca numele este schimbat, atunci invocam delegatul 
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    if (NameChanged != null)//aici verificam conditia ca noi sa avem subscriberi la eveniment, daca nu avem inseamna ca nu executam codul din if in consecinta event-ul e null
                    {
                        NameChanged(this, args);
                        //this = face rererire la obiectul curent, pe care il operam in momentul compilarii
                    }
                    NameChanged2?.Invoke(this, args);//la fel ca in if-ul de mai sus doar ca mai putin scris, doar ca aici folosim si metoda statica Invoke()
                }
                _name = value;
            }
        }
        //definim delegatul
        //ne facem un camp, NameChange = se vor putea lega de delegatul asta si sa-l invoce din alta parte , este public 
        public NameChangedDelegate NameChanged;
        //asa facem event-ul, are aceeasi semnatura ca si delegatul doar ca se adauga cuvantul event 
        public event NameChangedDelegate NameChanged2;

        protected string _name;
    }
}
