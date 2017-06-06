using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Mapping;
using System.Data;
using UberFrba.Utils;
using System.Windows.Forms;

namespace UberFrba.Dao
{
    class DAORoles
    {
        private DataBaseConnector connector;

        public DAORoles() {
            this.connector = DataBaseConnector.getInstance();
        }

        public List<Rol> getRolesByUserId(Int32 userId)
        {

                List<Rol> roles = new List<Rol>();
                DataBaseConnector db = DataBaseConnector.getInstance();
                DataTable dt = db.select_query("Select r.id,r.Descripcion from FSOCIETY.Roles as r join FSOCIETY.UsuariosRoles as ur on r.Id = ur.IdRol where r.Habilitado = 1 and ur.IdUsuario = '" + userId + "'");

                foreach (DataRow row in dt.Rows)
                {
                    roles.Add(new Rol(row));
                }

                return roles;
        }

        internal DataTable buscarRol(String nombreRol)
        {
            if (nombreRol != "")
            {
                return connector.select_query(getSelectRolQuery(nombreRol));
            }
            else
            {
                return buscarTodosLosRoles();
            }
        }

        public DataTable buscarTodosLosRoles()
        {
            return connector.select_query(getAllRolQuery());
        }

        private String getAllRolQuery()
        {
            return "select rol.Id, rol.Descripcion, rol.Habilitado from FSOCIETY.Roles rol ";
        }

        private String getSelectRolQuery(String nombre)
        {
            return getAllRolQuery() + "where rol.Descripcion like '%" + nombre + "%'";
        }

        private String GetAllFunctionalitiesQuery()
        {
            return "SELECT distinct(func.Descripcion) as 'Funcionalidades', '0' as 'relacion' FROM FSOCIETY.Funcionalidades func, FSOCIETY.RolFuncionalidades rolfunc, FSOCIETY.Roles rol ";
        }
        
        public DataTable getAllFuncionalitiesByRol(int idRol)
        {
            String query = "SELECT distinct(func.Descripcion)as 'Funcionalidades', (select '1' from FSOCIETY.RolFuncionalidades rf where rf.IdFuncionalidad = func.Id and rf.IdRol = '" + idRol + "') as 'relacion' FROM FSOCIETY.Funcionalidades func, FSOCIETY.RolFuncionalidades rolfunc, FSOCIETY.Roles rol";
            return connector.select_query(query);
        }

        public DataTable getAllFuncionalities()
        {
            return connector.select_query(GetAllFunctionalitiesQuery());
        }

        internal void update(List<String> add, List<String> del, int idRol, String rolDesc, bool habilitado)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@id", idRol);
            dic.Add("@nombre", rolDesc);
            dic.Add("@habilitado",habilitado);

            this.deleteActualFunctionalities(del, idRol);
            this.insertNewFunctionalities(add, idRol);
            connector.executeProcedureWithParameters("FSOCIETY.sp_update_roles", dic);
        }

        internal void insert(List<String> add, String rol, bool habilitado)
        {
            int idRol = this.getRolQuery(rol);
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@id", idRol);
            dic.Add("@nombre", rol);
            dic.Add("@habilitado", habilitado);

            this.insertNewFunctionalities(add, idRol);
            connector.executeProcedureWithParameters("FSOCIETY.sp_update_roles", dic);
        }

        private int getRolQuery(String rol)
        {
            DataTable result = connector.select_query("select Id from FSOCIETY.Roles where Descripcion = '" + rol + "'");
            return (Int32)result.Rows[0]["Id"];
        }

        private void deleteActualFunctionalities(List<string> del, int idRol)
        {
            foreach (String funcionalidad in del)
            {
                Dictionary<String, Object> dicSacadas = new Dictionary<String, Object>();
                dicSacadas.Add("@idrol", idRol);

                DataTable result = connector.select_query(this.getfunctionalityByDescQuery(funcionalidad));
                dicSacadas.Add("@idfun", result.Rows[0]["Id"].ToString());

                connector.executeProcedureWithParameters("FSOCIETY.sp_delete_funcionalidad", dicSacadas);
            }
        }
        
        private void insertNewFunctionalities(List<string> add, int idRol)
        {
            foreach (String funcionalidad in add)
            {
                Dictionary<String, Object> dicAgregadas = new Dictionary<String, Object>();
                dicAgregadas.Add("@idrol", idRol);

                DataTable result = connector.select_query(this.getfunctionalityByDescQuery(funcionalidad));
                dicAgregadas.Add("@idfun", result.Rows[0]["Id"].ToString());

                connector.executeProcedureWithParameters("FSOCIETY.sp_insert_funcionalidad", dicAgregadas);
            }
        }

        private String getfunctionalityByDescQuery(string funcionalidad)
        {
            return "Select Id from FSOCIETY.Funcionalidades where Descripcion = '" + funcionalidad + "'";
        }
    }
}