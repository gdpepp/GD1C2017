using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Utils
{
    class DuplicateKeyException : Exception
    {
        public DuplicateKeyException () {}


        public DuplicateKeyException(string message) { }

    }
}
