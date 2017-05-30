using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UberFrba.Utils;
using UberFrba.Mapping;

namespace UberFrba.Dao
{
    class DAOAutomovil
    {
        private DataBaseConnector db;

        public DAOAutomovil() {
            this.db = DataBaseConnector.getInstance();
        }

        public Automovil getAll() {
            DataTable dt = db.select_query("SELECT * FROM FSOCIETY.Autos");
            return new DataTable automoviles;
        }
    }
}
