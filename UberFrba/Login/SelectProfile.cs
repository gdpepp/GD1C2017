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
using UberFrba.Menu;
using UberFrba.Utils;

namespace UberFrba.Login
{
    public partial class SelectProfile : Form
    {
        private Usuario user;
        private List<Rol> roles;
        MainMenuView menu;


        public SelectProfile(Object user,Form menu)
        {
            this.menu = (MainMenuView)menu;
            this.user = (Usuario)user;
            setupRoles();
            InitializeComponent();
            setupCombobox();

        }


        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Rol r = comboBox1.SelectedItem as Rol;
            user.setRol(r);
            UserLogin.getInstance().User = user;
            showMainMenu();
        }


        private void setupCombobox()
        {
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Sorted = true;
            this.comboBox1.DataSource = roles;
        }

        private void setupRoles()
        {
            DAORoles dao = new DAORoles();
            this.roles = dao.getRolesByUserId(user.getId());
        }

        private void showMainMenu() {
            this.Close();
            this.menu.reload();
            this.menu.Visible = true;
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
                showMainMenu();
            }
        }

        private void SelectProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
