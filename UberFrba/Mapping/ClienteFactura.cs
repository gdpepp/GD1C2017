using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Mapping
{
    class ClienteFactura
    {
        private Int32 id;
        private String name;
        private String lastname;

        public ClienteFactura(Int32 id, String name, String lastname) {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
        }

        public ClienteFactura(DataRow row) {
            this.id = Convert.ToInt32(row["id"]);
            this.name = Convert.ToString(row["Nombre"]);
            this.lastname = Convert.ToString(row["Apellido"]);
        }

        public Int32 Id {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public String Lastname
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        public String fullName() {
            return this.Name.ToUpper() + " " + this.lastname.ToUpper();
        }

        public override string ToString()
        {
            return fullName();
        }

    }
}
