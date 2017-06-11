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
        public Int32 id;
        public Int32 idchofer;
        public DateTime fechaRendicion;
        public decimal importeTotal; 


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

        public Rendicion(int p, System.Windows.Forms.DateTimePicker fechaRendicion1, System.Windows.Forms.DataGridView dataGridViewRowCollection)
        {

            this.id = p;
            this.fechaRendicion = Convert.ToDateTime(fechaRendicion1.Value);
            this.importeTotal = Convert.ToDecimal(dataGridViewRowCollection.CurrentRow.Cells["Total"].Value);
        }
    }
}
