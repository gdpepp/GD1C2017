using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Mapping;
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

      internal DataTable getviajes(int idechofer, string n, int idturno)
        {
            return connector.select_query(getSelectRendicionViajeQuery(idechofer, n, idturno));
        }

        private string getSelectRendicionViajeQuery(int idechofer, string n, int idturno)
        {
            return "Select v.FechaHoraInicio,v.FechaHoraFin,v.CantKm,t.Precio_Base,t.Valor_Km, (t.Precio_Base + v.CantKm*t.Valor_Km) as Total from FSOCIETY.Chofer c  join FSOCIETY.Viaje v on v.IdChofer = c.Id  join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.Turnos t on t.Id = a.Id where (select  q.Hora_De_Inicio from  FSOCIETY.Turnos q where q.id =" + idturno + ") = t.Hora_De_Inicio and (select  w.Hora_De_Finalizacion from FSOCIETY.Turnos w where w.id =" + idturno + ") = t.Hora_De_Finalizacion and c.id = " + idechofer + "and cast(CAST(v.FechaHoraInicio as date)as char) ='" + n + "';";
        }

        private string getRendicionTotalQuery(int idechofert, string nt)
        {
            return "Select sum(t.Precio_Base + v.CantKm*t.Valor_Km) as Total from FSOCIETY.Chofer c  join FSOCIETY.Viaje v on v.IdChofer = c.Id  join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.Turnos t on t.Id = a.Id group by t.Precio_Base , v.CantKm,t.Valor_Km ,v.FechaHoraInicio, c.Id having c.id = " + idechofert + "and cast(CAST(v.FechaHoraInicio as date)as char) ='" + nt + "';";
        }



        internal DataTable getTotal(int idechofer, string n)
        {
            return connector.select_query(getRendicionTotalQuery(idechofer, n));
        }

        internal void setRencidion(int p, DateTimePicker fechaRendicion, DataGridView dataGridViewRowCollection)
        {
            Rendicion ren = new Rendicion(p, fechaRendicion, dataGridViewRowCollection);
            modificarRendicion(ren);
        }

        public int modificarRendicion(Rendicion rend)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@idChofer", rend.idchofer);
            dic.Add("@fecha", rend.fechaRendicion);
            dic.Add("@importe", rend.importeTotal);
          

            connector.executeProcedureWithParameters("FSOCIETY.sp_crear_Rendicion", dic);

            return 0;
        }
    }
}
