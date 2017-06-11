using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Utils;

namespace UberFrba.Dao
{
    class DAORendicionViaje
    {
        private DataBaseConnector connector;

      public  DAORendicionViaje()
        {
            this.connector = DataBaseConnector.getInstance();
        }

        internal DataTable getviajes(int idechofer, string n)
        {
            return connector.select_query(getSelectRendicionViajeQuery(idechofer, n));
        }

        private string getSelectRendicionViajeQuery(int idechofer, string n)
        {
            return "Select v.FechaHoraInicio,v.FechaHoraFin,v.CantKm,t.Precio_Base,t.Valor_Km, (t.Precio_Base + v.CantKm*t.Valor_Km) as Total from FSOCIETY.Chofer c  join FSOCIETY.Viaje v on v.IdChofer = c.Id  join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.Turnos t on t.Id = a.Id where c.id = " + idechofer + "and cast(CAST(v.FechaHoraInicio as date)as char) ='" + n + "';";
        }

        private string getRendicionTotalQuery(int idechofert, string nt)
        {
            return "Select sum(t.Precio_Base + v.CantKm*t.Valor_Km) as Total from FSOCIETY.Chofer c  join FSOCIETY.Viaje v on v.IdChofer = c.Id  join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.Turnos t on t.Id = a.Id group by t.Precio_Base , v.CantKm,t.Valor_Km ,v.FechaHoraInicio, c.Id having c.id = " + idechofert + "and cast(CAST(v.FechaHoraInicio as date)as char) ='" + nt + "';";
        }



        internal DataTable getTotal(int idechofer, string n)
        {
            return connector.select_query(getRendicionTotalQuery(idechofer, n));
        }
    }
}
