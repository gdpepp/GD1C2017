using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Mapping;

namespace UberFrba.Utils
{
    class UserLogin
    {
        private static UserLogin instance = null;
        private Usuario user;


        private UserLogin() { 
            
        }

        public static UserLogin getInstance() {

            if (instance == null) {
                instance = new UserLogin();
            }

            return instance;
        }



        public Usuario User {
            get { return this.user; }
            set { this.user = value; }
        }

    }
}
