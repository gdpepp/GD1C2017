using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Abm_Automovil
{
    class Modelo
    {
        private Int32 idModelo;
        private String modelo;

        public Modelo(DataRow row) 
        {
            this.idModelo = Convert.ToInt32(row["IdModelo"]);
            this.modelo = Convert.ToString(row["Modelo"]);
        }

        public override string ToString()
        {
            return this.modelo;
        }

        public Int32 getId() 
        {
            return this.idModelo;
        } 
    }
}
