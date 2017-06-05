using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class Turno
    {
        private int id;
        private int horaInicio;
        private int horaFinal;
        private string descripcion;
        private int valorKm;
        private int valorBase;
        private bool habilitado;

        public Turno(DataRow row) 
        {
            this.id = Convert.ToInt32(row["Id"]);
            this.horaInicio = Convert.ToInt32(row["Hora_De_Inicio"]);
            this.horaFinal = Convert.ToInt32(row["Hora_De_Finalizacion"]);
            this.descripcion = Convert.ToString(row["Descripcion"]);
            this.valorKm = Convert.ToInt32(row["Valor_Km"]);
            this.valorBase = Convert.ToInt32(row["Precio_Base"]);
            this.habilitado = Convert.ToBoolean(row["Habilitado"]);
        }

    }
}
