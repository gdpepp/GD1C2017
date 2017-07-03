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
        private string ganancia = "0.2";

      public  DAORendicionViaje()
        {
            this.connector = DataBaseConnector.getInstance();
        }

      internal DataTable getviajes(int idechofer, string n, int idturno)
        {
            return connector.select_query(getSelectRendicionViajeQuery(idechofer, n, idturno));
        }


      internal List<ViajeChofer> getviajessinturno(int idechofer, string n)
        {
            DataTable dt = connector.select_query(getSelectRendicionViajeQuery(idechofer, n, 0));
                  List<ViajeChofer> list = new List<ViajeChofer>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ViajeChofer(r));
            }
            return list;
            
        }


        private string getSelectRendicionViajeQuery(int idechofer, string n, int idturno)
        {
            string betwen = " datepart(hh, v.FechaHoraInicio) between (select Hora_De_Inicio from FSOCIETY.Turnos where id =" + idturno + ") and (select Hora_De_Finalizacion from FSOCIETY.Turnos where id =" + idturno + ") and";
            string subquery = "Select v.FechaHoraInicio,v.FechaHoraFin,v.CantKm,t.Precio_Base,t.Valor_Km, (t.Precio_Base + v.CantKm*t.Valor_Km)*"+this.ganancia+" as Total from FSOCIETY.Chofer c  join FSOCIETY.Viaje v on v.IdChofer = c.Id  join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.AutosTurnos ta on ta.IdAuto = a.Id join FSOCIETY.Turnos t on ta.IdTurno = t.Id  where c.id = " + idechofer + "and cast(CAST(v.FechaHoraInicio as date)as char) ='" + n + "';";

            return subquery;
            }

        private string getRendicionTotalQuery(int idechofert, string nt)
        {
            return "Select sum(t.Precio_Base + v.CantKm*t.Valor_Km) as Total from FSOCIETY.Chofer c  join FSOCIETY.Viaje v on v.IdChofer = c.Id  join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.AutosTurnos ta on ta.IdAuto = a.Id join FSOCIETY.Turnos t on ta.IdTurno = t.Id  group by v.IdChofer,c.Id,v.FechaHoraInicio having c.id = " + idechofert + "and CAST(v.FechaHoraInicio as date) ='" + nt + "';";
        }

        public List<ViajeChofer> getviajesbyfecha(string fecha, int idturno)
        { // select distinct idChofer from FSOCIETY.Viaje v 
            string subquery = "select distinct v.idChofer from FSOCIETY.Chofer c  join FSOCIETY.Viaje v on v.IdChofer = c.Id  join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.AutosTurnos ta on ta.IdAuto = a.Id join FSOCIETY.Turnos t on ta.IdTurno = t.Id where CAST(v.FechaHoraInicio as date) ='"+fecha+"'and datepart(hh, v.FechaHoraInicio) between (select Hora_De_Inicio from FSOCIETY.Turnos  where id =" + idturno + ") and (select Hora_De_Finalizacion from FSOCIETY.Turnos where id =" + idturno + ")";
           DataTable dt = connector.select_query("select distinct a.Patente, ma.Description as Marca, m.Description as Modelo, c.Id,p.Nombre,p.Apellido,p.DNI,c.Telefono, c.Email,p.[Fecha de Nacimiento] as Fecha from FSOCIETY.Chofer as c join FSOCIETY.Usuarios as u on c.Id = u.Id join FSOCIETY.Personas as p on p.Id = u.IdPersona join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.Modelos m on m.Id = a.IdModelo join FSOCIETY.Marcas ma on ma.Id = m.IdMarca where c.id in (" + subquery + ");");
           List<ViajeChofer> list = new List<ViajeChofer>();
           foreach (DataRow r in dt.Rows)
           {
               list.Add(new ViajeChofer(r));
           }
           return list;
       }

        public List<ViajeChofer> getviajesbyfechasinturno(string fecha, int idturno)
        { // select distinct idChofer from FSOCIETY.Viaje v 
            string subquery = "select distinct v.idChofer from FSOCIETY.Chofer c  join FSOCIETY.Viaje v on v.IdChofer = c.Id  join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.AutosTurnos ta on ta.IdAuto = a.Id join FSOCIETY.Turnos t on ta.IdTurno = t.Id where CAST(v.FechaHoraInicio as date) ='" + fecha + "'and datepart(hh, v.FechaHoraInicio) between (select Hora_De_Inicio from FSOCIETY.Turnos  where id =" + idturno + ") and (select Hora_De_Finalizacion from FSOCIETY.Turnos where id =" + idturno + ")";
            DataTable dt = connector.select_query("select distinct a.Patente, ma.Description as Marca, m.Description as Modelo, c.Id,p.Nombre,p.Apellido,p.DNI,c.Telefono, c.Email,p.[Fecha de Nacimiento] as Fecha from FSOCIETY.Chofer as c join FSOCIETY.Usuarios as u on c.Id = u.Id join FSOCIETY.Personas as p on p.Id = u.IdPersona join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.Modelos m on m.Id = a.IdModelo join FSOCIETY.Marcas ma on ma.Id = m.IdMarca where c.id in (" + subquery + ");");
            List<ViajeChofer> list = new List<ViajeChofer>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ViajeChofer(r));
            }
            return list;
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

        internal bool existren(string p1, int p2)
        {
            DataTable dt = connector.select_query("select count(*)from FSOCIETY.Viaje where IdChofer =" + p1 + "and cast(CAST(FechaHoraInicio as date)as char) = '"+p2 +"';");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
