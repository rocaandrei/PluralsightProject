using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plural
{
    public struct Colors
    {
        private string _green;

        private string _red;

        public string Green
        {
            get
            {
                return _green;
            }

            set
            {
                _green = value;
            }
        }

        public string Red
        {
            get
            {
                return _red;
            }

            set
            {
                _red = value;
            }
        }
    }
}
