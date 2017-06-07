using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    class Marca
    {
        private Int32 idMarca;
        private String marca;

        public Marca(DataRow row)
        {
            this.idMarca = Convert.ToInt32(row["IdMarca"]);
            this.marca = Convert.ToString(row["Marca"]);
        }

        public Marca(DataGridViewRow unAuto)
        {
            this.idMarca = (int)unAuto.Cells["IdMarca"].Value;
            this.marca = (string)unAuto.Cells["Marca"].Value;
        }

        public override string ToString()
        {
            return this.marca;
        }
        
        public Int32 getId()
        {
            return idMarca;
        }

        public String getMarca()
        {
            return marca;
        }
    }
}
