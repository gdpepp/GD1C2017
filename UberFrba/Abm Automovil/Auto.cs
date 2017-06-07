using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UberFrba.Abm_Automovil;

namespace UberFrba.Abm_Automovil
{
    class Auto
    {
        public Int32 idAuto;
        public String patente;
        public Boolean habilitado;
        public Int32 idChofer;
        public String chofer;
        public Int32 idMarca;
        public String marca;
        public Int32 idModelo;
        public String modelo;
        public Int32 idTurno;
        public String turno;

        public Auto(DataRow row)
        {
            this.idAuto = Convert.ToInt32(row["IdAutos"]);
            this.patente = Convert.ToString(row["Patente"]);
            this.habilitado = Convert.ToBoolean(row["Habilitado"]);
            this.idChofer = Convert.ToInt32(row["IdChofer"]);
            this.chofer = Convert.ToString(row["Chofer"]);
            this.idMarca = Convert.ToInt32(row["IdMarca"]);
            this.marca = Convert.ToString(row["Marca"]);
            this.idModelo = Convert.ToInt32(row["IdModelo"]);
            this.modelo = Convert.ToString(row["Modelo"]);
            this.idTurno = Convert.ToInt32(row["IdTurno"]);
            this.turno = Convert.ToString(row["Turno"]);
            //this.chofer = new Chofer(row);
            //this.marca = new Marca(row);
            //this.modelo = new Modelo(row);
            //this.turno = new Turno(row);
        }

        public Auto(String patente, Boolean habilitado, Int32 idChofer, Int32 idMarca, String modelo, Int32 idTurno)
        {
            this.patente = patente;
            this.habilitado = habilitado;
            this.idChofer = idChofer;
            this.idMarca = idMarca;
            this.modelo = modelo;
            this.idTurno = idTurno;
        }
    }
}
