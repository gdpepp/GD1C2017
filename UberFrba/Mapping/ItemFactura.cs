using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba.Mapping
{
    class ItemFactura
    {
        private String chofer;
        private DateTime inicio;
        private DateTime fin;
        private Int32 km;
        private Double total;

        public ItemFactura(DataRow r) {
            this.chofer = Convert.ToString(r["chofer"]);
            this.inicio = Convert.ToDateTime(r["inicio"]);
            this.fin = Convert.ToDateTime(r["fin"]);
            this.km = Convert.ToInt32(r["KM"]);
            this.total = Convert.ToDouble(r["Total"]);
        }

        public String Chofer {
            get { return this.chofer; }
            set { this.chofer = value; }
        }

        public DateTime Inicio
        {
            get { return this.inicio; }
            set { this.inicio = value; }
        }

        public DateTime Fin
        {
            get { return this.fin; }
            set { this.fin = value; }
        }

        public Int32 Km
        {
            get { return this.km; }
            set { this.km = value; }
        }

        public Double Total
        {
            get { return this.total; }
            set { this.total = value; }
        }
    }
}
