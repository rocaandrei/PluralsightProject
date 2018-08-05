using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plural
{
    //prin conventie asa trebuie definit delegatul, sa aiba un obiect ca parametru si dupa armentele/semnatura de returnare dorita 
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
