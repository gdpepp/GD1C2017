using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Mapping
{
    class Rendicion
    {
        private Int32 id;
        private Int32 idchofer;
        private DateTime fechaRendicion;
        private Int32 importeTotal;

        public Rendicion(int i, int ic, DateTime fecha, int impo)
        {
            this.id = i;
            this.idchofer = ic;
            this.fechaRendicion = fecha;
            this.importeTotal = impo;
        }
        public Rendicion(DataRow row)
        {
            this.id = Convert.ToInt32(row["id"]);
            this.idchofer = Convert.ToInt32(row["idChofer"]);
            this.fechaRendicion = Convert.ToDateTime(row["Fecha"]);
            this.importeTotal = Convert.ToInt32(row["Total"]);
        }
    }
}
