using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    class Chofer
    {
        private Int32 idChofer;
        private string chofer;

        public Chofer(DataRow row)
        {
            this.idChofer = Convert.ToInt32(row["IdChofer"]);
            this.chofer = Convert.ToString(row["Chofer"]);
        }

        public Chofer(DataGridViewRow unAuto)
        {
            this.idChofer = (int)unAuto.Cells["IdChofer"].Value;
            this.chofer = (string)unAuto.Cells["Chofer"].Value;
        }

        public override string ToString()
        {
            return this.chofer;
        }

        public Int32 getId() {
            return this.idChofer;
        }

        public String getChofer()
        {
            return this.chofer;
        }

    }
}
