using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    class Turno
    {
        private Int32 idTurno;
        private string turno;

        public Turno(DataRow row) 
        {
            this.idTurno = Convert.ToInt32(row["IdTurno"]);
            this.turno = Convert.ToString(row["Turno"]);
        }

        public Turno(DataGridViewRow unAuto)
        {
            this.idTurno = (int)unAuto.Cells["IdTurno"].Value;
            this.turno = (string)unAuto.Cells["Turno"].Value;
        }

        public override string ToString()
        {
            return this.turno;
        }

        public Int32 getId() 
        {
            return this.idTurno;
        }

        public String getTurno()
        {
            return turno;
        }

    }
}
