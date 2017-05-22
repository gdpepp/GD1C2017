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
using UberFrba.Abm_Rol;


namespace UberFrba.Menu
{
    public partial class MainMenu : Form
    {
        private Usuario user;

        public MainMenu(Object user)
        {
            this.user = (Usuario)user;
            InitializeComponent();
            this.label1.Text = "Bienvenido " + this.user.getUsername() + " con perfil: " + this.user.getRol().getDescription();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmRol form = new AbmRol(this,user.getUsername());
            this.Hide();
            form.ShowDialog();
        }
    }
}
