using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class Automovil
    {
        private Int32 id;
        private String patente;
        private Int32 idModelo;
        private Int32 idTurno;
        private Int32 idChofer;
        private Boolean habilitado;

        public Automovil(Int32 id, String patente, Int32 idModelo, Int32 idTurno, Int32 idChofer, Boolean habilitado) {
            this.id = id;
            this.patente = patente;
            this.idModelo = idModelo;
            this.idTurno = idTurno;
            this.idChofer = idChofer;
            this.habilitado = habilitado;
        }

        public Automovil(DataRowCollection rows) {
            foreach (DataRow row in rows)
            {
                this.id = Convert.ToInt32(row["Id"]);
                this.patente = Convert.ToString(row["Patente"]);
                this.idModelo = Convert.ToInt32(row["IdModelo"]);
                this.idTurno = Convert.ToInt32(row["IdTurno"]);
                this.idChofer = Convert.ToInt32(row["IdChofer"]);
                this.habilitado = Convert.ToBoolean(row["Habilitado"]);
            }
        }

        public Int32 getId() {
            return this.id;
        }

        public String getPatente() {
            return this.patente;
        }

        public Int32 getModelo() {
            return this.idModelo;
        }

        public Int32 getTurno()
        {
            return this.idTurno;
        }

        public Int32 getChofer() {
            return this.idChofer;
        }

        public Boolean getHabilitado() {
            return this.habilitado;
        }
    }
}
