using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba.Mapping
{
    class Factura
    {
        private Int32 id;
        private List<ItemFactura> items;
        private Double total;

        public Factura(DataRow r) {
            this.id = Convert.ToInt32(r["id"]);
            this.total = Convert.ToDouble(r["Importe"]);
            this.items = new List<ItemFactura>();
        }

        public Int32 Id {
            get { return this.id; }
            set { this.id = value; }
        }

        public List<ItemFactura> Items {
            get { return this.items; }
            set { this.items = value; }
        }

        public Double Total {
            get { return this.total; }
            set { this.total = value; }
        }
    }
}
