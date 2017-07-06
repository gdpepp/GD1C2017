using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Utils
{
    class InvalidOptionException : Exception
    {
        public InvalidOptionException() { }

        public InvalidOptionException(string message) { }

    }
}
