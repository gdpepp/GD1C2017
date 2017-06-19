using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UberFrba.Utils;
using System.Data.SqlClient;
using WindowsFormsApplication1;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UberFrba.Dao;

namespace UberFrba.DAO
{
    class DAOListado
    {
        private DataBaseConnector db;

        public DAOListado()
        {
            this.db = DataBaseConnector.getInstance();
        }

        public List<Int32> getYears()
        {
            List<Int32> anios = new List<Int32>();
            DataTable dt = db.select_query("SELECT DISTINCT(YEAR(FechaHoraFin)) AS ANIO FROM FSOCIETY.Viaje UNION SELECT DISTINCT(YEAR(FechaInicio)) FROM FSOCIETY.Facturacion UNION SELECT DISTINCT(YEAR(Fecha)) FROM FSOCIETY.Rendicion");

            foreach (DataRow row in dt.Rows)
            {
                anios.Add(Convert.ToInt32(row["ANIO"]));
            }

            return anios;
        }

        internal DataTable getMayorRecudacion(string fechaDesde, string fechaHasta)
        {
            return db.select_query("SELECT TOP 5 PERSONAS.Apellido, PERSONAS.Nombre, PERSONAS.DNI, PERSONAS.[Fecha de Nacimiento], PERSONAS.Direccion, CHOFER.Telefono, CHOFER.Email, SUM(RENDICION.ImporteTotal) AS Recaudacion FROM FSOCIETY.Rendicion RENDICION INNER JOIN FSOCIETY.Chofer CHOFER ON RENDICION.IdChofer = CHOFER.Id INNER JOIN FSOCIETY.Usuarios USUARIOS ON CHOFER.Id = USUARIOS.Id INNER JOIN FSOCIETY.Personas PERSONAS ON USUARIOS.IdPersona = PERSONAS.Id WHERE RENDICION.Fecha >= '" + fechaDesde + "' AND RENDICION.Fecha <= '" + fechaHasta + "' GROUP BY PERSONAS.Apellido, PERSONAS.Nombre, PERSONAS.DNI, PERSONAS.[Fecha de Nacimiento], PERSONAS.Direccion, CHOFER.Telefono, CHOFER.Email ORDER BY Recaudacion DESC");
        }

        internal object getViajeMasLargo(string fechaDesde, string fechaHasta)
        {
            return db.select_query("SELECT TOP 5 PERSONAS.Apellido, PERSONAS.Nombre, PERSONAS.DNI, PERSONAS.[Fecha de Nacimiento], PERSONAS.Direccion, CHOFER.Telefono, CHOFER.Email, MAX(VIAJE.CantKm) AS CantKM FROM FSOCIETY.Viaje VIAJE INNER JOIN FSOCIETY.Chofer CHOFER ON VIAJE.IdChofer = CHOFER.Id INNER JOIN FSOCIETY.Usuarios USUARIOS ON CHOFER.Id = USUARIOS.Id INNER JOIN FSOCIETY.Personas PERSONAS ON USUARIOS.IdPersona = PERSONAS.Id WHERE VIAJE.FechaHoraInicio >= '" + fechaDesde + "' AND VIAJE.FechaHoraInicio <= '" + fechaHasta + "' GROUP BY VIAJE.IdChofer, PERSONAS.Apellido, PERSONAS.Nombre, PERSONAS.DNI, PERSONAS.[Fecha de Nacimiento], PERSONAS.Direccion, CHOFER.Telefono, CHOFER.Email ORDER BY CantKm DESC");
        }

        internal object getMayorConsumo(string fechaDesde, string fechaHasta)
        {
            return db.select_query("SELECT TOP 5 PERSONAS.Apellido, PERSONAS.Nombre, PERSONAS.DNI, PERSONAS.[Fecha de Nacimiento], PERSONAS.Direccion, CLIENTE.Codigo_Postal, CLIENTE.Telefono, CLIENTE.Email, SUM(FACTURACION.Importe) AS TOTAL FROM FSOCIETY.Cliente CLIENTE INNER JOIN FSOCIETY.Facturacion FACTURACION ON CLIENTE.Id = FACTURACION.IdCliente INNER JOIN FSOCIETY.Usuarios USUARIOS ON CLIENTE.Id = USUARIOS.Id INNER JOIN FSOCIETY.Personas PERSONAS ON USUARIOS.IdPersona = PERSONAS.Id WHERE FACTURACION.FechaInicio >= '" + fechaDesde + "' AND FACTURACION.FechaInicio <= '" + fechaHasta + "' GROUP BY PERSONAS.Apellido, PERSONAS.Nombre, PERSONAS.DNI, PERSONAS.[Fecha de Nacimiento], PERSONAS.Direccion, CLIENTE.Codigo_Postal, CLIENTE.Telefono, CLIENTE.Email ORDER BY TOTAL DESC");
        }

        internal object getMismoAuto(string fechaDesde, string fechaHasta)
        {
            return db.select_query("SELECT TOP 5 PERSONAS.Apellido, PERSONAS.Nombre, PERSONAS.DNI, PERSONAS.[Fecha de Nacimiento], PERSONAS.Direccion, CLIENTE.Codigo_Postal, CLIENTE.Telefono, CLIENTE.Email, (SELECT TOP 1 COUNT(AUTOS.Id) AS CANT FROM FSOCIETY.Viaje VIAJE INNER JOIN FSOCIETY.Chofer CHOFER ON VIAJE.IdChofer = CHOFER.Id INNER JOIN FSOCIETY.Autos AUTOS ON CHOFER.Id = AUTOS.IdChofer WHERE VIAJE.IdCliente = CLIENTE.Id AND VIAJE.FechaHoraInicio > '" + fechaDesde + "' AND VIAJE.FechaHoraInicio < '" + fechaHasta + "' GROUP BY AUTOS.Patente, AUTOS.Id ORDER BY CANT DESC) AS CANTIDAD FROM FSOCIETY.Cliente CLIENTE INNER JOIN FSOCIETY.Usuarios USUARIOS ON CLIENTE.Id = USUARIOS.Id INNER JOIN FSOCIETY.Personas PERSONAS ON USUARIOS.IdPersona = PERSONAS.Id INNER JOIN FSOCIETY.Viaje VIAJECLIENTES ON CLIENTE.Id = VIAJECLIENTES.IdCliente WHERE VIAJECLIENTES.FechaHoraInicio > '" + fechaDesde + "' AND VIAJECLIENTES.FechaHoraInicio < '" + fechaHasta + "' GROUP BY VIAJECLIENTES.IdCliente, PERSONAS.Apellido, PERSONAS.Nombre, PERSONAS.DNI, PERSONAS.[Fecha de Nacimiento], PERSONAS.Direccion, CLIENTE.Codigo_Postal, CLIENTE.Telefono, CLIENTE.Email, CLIENTE.Id ORDER BY CANTIDAD DESC");
        }
    }
}
