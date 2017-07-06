using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace UberFrba.Abm_Turno
{
    class Turno
    {
        public string Descripcion;
        public System.DateTime horaInicio;
        public System.DateTime horaFin;
        public float valorKm;
        public float precioBase;
        public bool Habilitado;
 
        public Turno(string p1, System.DateTime p2, System.DateTime p3, float p4, float p5, bool checkBox)
        {
            // TODO: Complete member initialization
            this.Descripcion = p1;
            this.horaInicio = p2;
            this.horaFin = p3;
            this.valorKm = (float)p4;
            this.precioBase = (float)p5;
            this.Habilitado = (bool)checkBox;
        }
    }
}
