using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Utils;

namespace UberFrba.Dao
{
    class DAOFacturacion
    {
        private DataBaseConnector db;

        public DAOFacturacion() {
            this.db = DataBaseConnector.getInstance();
        }



    }
}
