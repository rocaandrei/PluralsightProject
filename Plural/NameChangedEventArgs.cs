using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plural
{
    //clasa menita sa respecte conventia eventurilor cu args si trebuie sa mostenesca clasa EventArgs 
    public class NameChangedEventArgs : EventArgs
    {
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
}
