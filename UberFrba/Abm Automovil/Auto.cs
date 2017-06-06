using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Abm_Automovil
{
    class Auto
    {
        public int marca;
        public string modelo;
        public string patente;
        public int turno;
        public int chofer;
        public bool habilitado;

        public Auto(int marca, string modelo, string patente, int turno, int chofer, bool habilitado)
        {
            // TODO: Complete member initialization
            this.marca = marca;
            this.modelo = modelo;
            this.patente = patente;
            this.turno = turno;
            this.chofer = chofer;
            this.habilitado = habilitado;
        }

    }
}
