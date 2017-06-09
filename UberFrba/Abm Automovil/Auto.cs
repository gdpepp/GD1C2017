using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UberFrba.Abm_Automovil;
using System.Windows.Forms;

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
        }

        public Auto(DataGridViewRow unAuto)
        {
            this.idAuto = (int)unAuto.Cells["IdAutos"].Value;
            this.patente = (string)unAuto.Cells["Patente"].Value;
            this.habilitado = (bool)unAuto.Cells["Habilitado"].Value;
            this.idChofer = (int)unAuto.Cells["IdChofer"].Value;
            this.chofer = (string)unAuto.Cells["Chofer"].Value;
            this.idMarca = (int)unAuto.Cells["IdMarca"].Value;
            this.marca = (string)unAuto.Cells["Marca"].Value;
            this.idModelo = (int)unAuto.Cells["IdModelo"].Value;
            this.modelo = (string)unAuto.Cells["Modelo"].Value;
            this.idTurno = (int)unAuto.Cells["IdTurno"].Value;
            this.turno = (string)unAuto.Cells["Turno"].Value;
            this.idChofer = (int)unAuto.Cells["IdChofer"].Value;
            this.chofer = (string)unAuto.Cells["Chofer"].Value;
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
