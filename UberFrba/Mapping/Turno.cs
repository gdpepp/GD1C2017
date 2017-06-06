using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class Turno
    {
        private int id;
        private string descripcion;

        public Turno(DataRow row) 
        {
            this.id = Convert.ToInt32(row["Id"]);
            this.descripcion = Convert.ToString(row["Descripcion"]);
        }

        public override string ToString()
        {
            return this.descripcion;
        }

    }
}
