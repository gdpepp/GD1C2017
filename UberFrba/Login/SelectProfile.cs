using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Mapping;
using UberFrba.Dao;

namespace UberFrba.Login
{
    public partial class SelectProfile : Form
    {
        private Usuario user;
        private List<Rol> roles;

        public SelectProfile(Object user)
        {
            this.user = (Usuario)user;
            setupRoles();
            InitializeComponent();

            setupCombobox();

        }


        private void btnContinuar_Click(object sender, EventArgs e)
        {

        }


        private void setupCombobox()
        {
            this.comboBox1.DataSource = new BindingSource(convertToDic(), null);
            this.comboBox1.ValueMember = "Key";
            this.comboBox1.DisplayMember = "Value";
        }

        private Dictionary<string, string> convertToDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (Rol r in roles)
            {
                dic.Add(r.getId().ToString(), r.getDescription());
            }
            return dic;
        }

        private void setupRoles()
        {
            DAORoles dao = new DAORoles();
            this.roles = dao.getRolesByUserId(user.getId());
        }

        public void present()
        {
            if (roles.Count > 1)
            {
                base.ShowDialog();
            }
            else
            {
                user.setRol(roles[0]);
                throw new Exception("No existe otra pantalla");
            }
        }

    }
}
