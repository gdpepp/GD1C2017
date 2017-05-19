using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Utils;
using System.Data;

namespace UberFrba.Mapping
{
    class Usuario
    {
        private Int32 id;
        private String username = "";
        private String pass = "";
        private Int32 idPersona;
        private List<Rol> roles;

        public Usuario() { 
        }

        public Usuario(Int32 id, String username, String pass, Int32 idPersona) {
            this.id = id;
            this.username = username;
            this.pass = pass;
            this.idPersona = idPersona;
            this.roles = new List<Rol>();
        }

        public Usuario(DataRowCollection rows) {
            foreach (DataRow r in rows)
            {
                this.username = Convert.ToString(r["Username"]);
                this.id = Convert.ToInt32(r["id"]);
                this.pass = Convert.ToString(r["Password"]);
                this.id = Convert.ToInt32(r["idPersona"]);
            }
        }

        public Boolean passwordEquals(String pass) {
            return this.pass.Equals(pass);
        }

        public Int32 getId() {
            return this.id;
        }

        public String getUsername() {
            return this.username;
        }

        public String getPassword() {
            return this.pass;
        }

        public Int32 getIdPersona() {
            return this.idPersona;
        }

        public List<Rol> getRoles() {
            return this.roles;
        }

        public void setRoles(List<Rol> roles) {
            this.roles = roles;
        }

        public void addRol(Rol rol) {
            this.roles.Add(rol);
        }

        public int rolesCount() {
            return roles.Count;
        }
       



    }
}
