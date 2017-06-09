using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    class Chofer_Auto
    {
        private Int32 idChofer;
        private string chofer;

        public Chofer_Auto(DataRow row)
        {
            this.idChofer = Convert.ToInt32(row["IdChofer"]);
            this.chofer = Convert.ToString(row["Chofer"]);
        }

        public Chofer_Auto(DataGridViewRow unAuto)
        {
            this.idChofer = (int)unAuto.Cells["IdChofer"].Value;
            this.chofer = (string)unAuto.Cells["Chofer"].Value;
        }

        public Chofer_Auto(Auto unAuto)
        {
            this.idChofer = unAuto.idChofer;
            this.chofer = unAuto.chofer;
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
