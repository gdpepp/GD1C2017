using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Utils;
using System.Data;
using UberFrba.Mapping;

namespace UberFrba.Dao
{
    class DAOUsers
    {
        public Usuario getUser(String username)
        {

                DataBaseConnector db = DataBaseConnector.getInstance();
                DataTable dt = db.select_query("Select Id,Username,Password,IdPersona from FSOCIETY.Usuarios where Username = '" + username + "'");

                if (dt.Rows.Count == 1)
                {
                    return new Usuario(dt.Rows);
                }
                else
                {
                    if (dt.Rows.Count > 1)
                    {
                        throw new Exception("Se produjo un problema al intentar iniciar sesion por favor concatese con el administrador");

                    }
                    else
                    {
                        throw new Exception("El usuario ingresado es inexistente");
                    }
                }
        }

    }
}
