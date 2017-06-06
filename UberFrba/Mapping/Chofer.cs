using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Mapping
{
    class Chofer
    {
        public Int32 id;
        public string telefono;
        public string email;
        public bool habilitado { get; set; }

        public Chofer( string telefo, string mail, bool avtivo) {
            this.email = mail;
            this.telefono = telefo;
            this.habilitado = avtivo;

       
        }



        internal void setIdChofer(int p)
        {
            this.id = p;
        }
    }
}
