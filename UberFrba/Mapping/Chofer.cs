using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class Chofer
    {
        private Int32 id;
        private string chofer;

        public Chofer(DataRow row)
        {
            this.id = Convert.ToInt32(row["Id"]);
            this.chofer = Convert.ToString(row["Chofer"]);
        }

        public override string ToString()
        {
            return this.chofer;
        }

        public Int32 getId() {
            return this.id;
        }

    }
}
