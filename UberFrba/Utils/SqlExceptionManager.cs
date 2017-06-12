using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UberFrba.Utils
{
    class SqlExceptionManager
    {

        public static void handlerException(SqlException ex) { 
            
            switch(ex.Number){
                case 208:
                    throw new InvalidOptionException(ex.Message.ToString() + "custom");
                case 2601:
                    throw new DuplicateKeyException(ex.Message.ToString() + "custom");
                case 2602:
                    throw new DuplicateKeyException(ex.Message.ToString() + "Esta operacion ya fue Realizada");
                default:
                    throw new Exception("Hubo un error, reintente mas tarde");

            }

        }

    }
}
