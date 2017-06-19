using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.DAO;

namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        private DAOListado dao;
        string fechaDesde;
        string fechaHasta;


        public ListadoEstadistico()
        {
            this.dao = new DAOListado();
            InitializeComponent();
            setupComboAnios();
        }

        private void setupComboAnios()
        {
            this.comboAnios.DataSource = dao.getYears();
            this.comboAnios.SelectedItem = null;
        }
        
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CheckEmptyCombo();
                int listado = this.comboListados.SelectedIndex;
                string anio = this.comboAnios.SelectedValue.ToString();
                int trimestre = this.comboTrimestres.SelectedIndex;
                llenarTabla(listado, anio, trimestre);
                this.dgvListadoEstadistico.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void llenarTabla(int listado, string anio, int trimestre)
        {
            List<String> fecha = armarFecha(anio, trimestre);
            if(listado == 0)
            {
                this.dgvListadoEstadistico.DataSource = dao.getMayorRecudacion(fecha[0], fecha[1]);
            }

            if (listado == 1)
            {
                this.dgvListadoEstadistico.DataSource = dao.getViajeMasLargo(fecha[0], fecha[1]);
            }

            if (listado == 2)
            {
                this.dgvListadoEstadistico.DataSource = dao.getMayorConsumo(fecha[0], fecha[1]);
            }

            if (listado == 3)
            {
                this.dgvListadoEstadistico.DataSource = dao.getMismoAuto(fecha[0], fecha[1]);
            }
        }

        private List<string> armarFecha(string anio, int trimestre)
        {
            if (trimestre == 0)
            {
                this.fechaDesde = anio + "-01-01";
                this.fechaHasta = anio + "-03-31";
            }
            if (trimestre == 1)
            {
                this.fechaDesde = anio + "-04-01";
                this.fechaHasta = anio + "-06-30";
            }
            if (trimestre == 2)
            {
                this.fechaDesde = anio + "-07-01";
                this.fechaHasta = anio + "-09-30";
            }
            if (trimestre == 3)
            {
                this.fechaDesde = anio + "-10-01";
                this.fechaHasta = anio + "-12-31";
            }
            
            List<string> fechas = new List<string>();
            fechas.Add(fechaDesde);
            fechas.Add(fechaHasta);

            return fechas;
        }

        private void CheckEmptyCombo()
        {
            List<ComboBox> inputsCombo = new List<ComboBox> { this.comboListados, this.comboAnios, this.comboTrimestres };
            if (inputsCombo.Any((c) => c.SelectedItem == null))
            {
                throw new Exception("Debe seleccionar en los tres campos.");
            }
        }

        private void comboListados_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboAnios.SelectedItem = null;
            this.comboTrimestres.SelectedItem = null;
            this.dgvListadoEstadistico.DataSource = null;
        }
    }
}
