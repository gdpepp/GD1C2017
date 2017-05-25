using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Cliente
{
    class Cliente
    {
        public string telefono;
        public string mail;
        public string zipcode;
        public int idCliente;

        public Cliente(string p1, string p2, string p3, int idPersona)
        {
            // TODO: Complete member initialization
            this.telefono = p1;
            this.mail = p2;
            this.zipcode = p3;
            this.idCliente = idPersona;
        }

        public void setIdCliente(int id)
        {
            this.idCliente = id;
        }
    }
}