using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Utils;
using UberFrba.Mapping;
using System.Data.SqlClient;

namespace UberFrba.Dao
{
    class DAOFacturacion
    {
        private DataBaseConnector db;

        public DAOFacturacion() {
            this.db = DataBaseConnector.getInstance();
        }


        public List<ClienteFactura> getClientToSelect() {
            DateTime now = DateTime.Now;
            //DataTable dt = db.select_query("Select distinct c.Id,p.Nombre, p.Apellido from FSOCIETY.Viaje as v join FSOCIETY.Cliente as c on v.IdCliente=c.Id join FSOCIETY.Usuarios as u on u.Id = c.Id join FSOCIETY.Personas as p on p.Id=u.IdPersona where MONTH(v.FechaHoraInicio) = 12 and YEAR(v.FechaHoraInicio) = 2015");
            DataTable dt = db.select_query("Select distinct c.Id,p.Nombre, p.Apellido from FSOCIETY.Viaje as v join FSOCIETY.Cliente as c on v.IdCliente=c.Id join FSOCIETY.Usuarios as u on u.Id = c.Id join FSOCIETY.Personas as p on p.Id=u.IdPersona where MONTH(v.FechaHoraInicio) = '"+ now.Month + "' and YEAR(v.FechaHoraInicio) = '"+ now.Year +"'");
            List<ClienteFactura> list = new List<ClienteFactura>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ClienteFactura(r));   
            }
            return list;
        }

        public void generateInvoice(Int32 id) {
            DateTime now = DateTime.Now;

            try
            {   
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@id", id);
                dic.Add("@month", now.Month);
                dic.Add("@year", now.Year);
                db.executeProcedureWithParameters("FSOCIETY.sp_facturar", dic);
            }
            catch (DuplicateKeyException ex)
            {
                throw new DuplicateKeyException("ya se genero la factura de este mes");
            }
            catch (SqlException ex) {
                throw new Exception(ex.Message.ToString());
            }
            
        }

        public Factura getInvoice(Int32 id) { 
            DateTime now = DateTime.Now;
            DataTable table = db.select_query("select Id,Importe from FSOCIETY.Facturacion where IdCliente = " + id + " and MONTH(FechaInicio) = " + now.Month +" and YEAR(FechaInicio) = " + now.Year);
            if (table.Rows.Count == 0) {
                return null;
            }
            Factura f = new Factura(table.Rows[0]);
            return getItemInvoice(id, f);
        }

        public Factura getItemInvoice(Int32 id,Factura f) {
            DataTable dt = db.select_query("Select  (p.Nombre + ' ' + UPPER(p.Apellido)) chofer,v.FechaHoraInicio inicio,v.FechaHoraFin fin ,v.CantKm KM,((v.CantKm * Valor_Km)+t.Precio_Base) as Total from FSOCIETY.Facturacion as f join FSOCIETY.FacturacionViajes as fv on f.Id = fv.IdFactura join FSOCIETY.Viaje as v on v.Id = fv.IdViaje join FSOCIETY.Chofer ch on ch.Id = v.IdChofer join FSOCIETY.Usuarios u on u.Id = ch.id join FSOCIETY.Personas p on p.Id = u.Id join FSOCIETY.Autos a on a.IdChofer = ch.Id join FSOCIETY.AutosTurnos at on at.IdAuto = a.Id join FSOCIETY.Turnos t on t.Id = at.IdTurno where f.IdCliente = " + id + " and (DATEPART(hh,v.FechaHoraInicio) between t.Hora_De_Inicio and t.Hora_De_Finalizacion) and t.Hora_De_Finalizacion <> DATEPART(hh,v.FechaHoraInicio)");
            List<ItemFactura> items = new List<ItemFactura>();

            foreach (DataRow row in dt.Rows) {
                items.Add(new ItemFactura(row));
            }
            f.Items = items;
            return f;
        }

        public DataTable getItemInvoice(Int32 id)
        {
            return db.select_query("Select  (p.Nombre + ' ' + UPPER(p.Apellido)) chofer,v.FechaHoraInicio inicio,v.FechaHoraFin fin ,v.CantKm KM,((v.CantKm * Valor_Km)+t.Precio_Base) as Total from FSOCIETY.Facturacion as f join FSOCIETY.FacturacionViajes as fv on f.Id = fv.IdFactura join FSOCIETY.Viaje as v on v.Id = fv.IdViaje join FSOCIETY.Chofer ch on ch.Id = v.IdChofer join FSOCIETY.Usuarios u on u.Id = ch.id join FSOCIETY.Personas p on p.Id = u.Id join FSOCIETY.Autos a on a.IdChofer = ch.Id join FSOCIETY.AutosTurnos at on at.IdAuto = a.Id join FSOCIETY.Turnos t on t.Id = at.IdTurno where f.IdCliente = " + id + " and (DATEPART(hh,v.FechaHoraInicio) between t.Hora_De_Inicio and t.Hora_De_Finalizacion) and t.Hora_De_Finalizacion <> DATEPART(hh,v.FechaHoraInicio)");
        }

    }
}
