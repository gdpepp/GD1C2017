namespace UberFrba.Abm_Automovil
{
    partial class Automovil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewAutomoviles = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.labelMarca = new System.Windows.Forms.Label();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.labelPatente = new System.Windows.Forms.Label();
            this.textPatente = new System.Windows.Forms.TextBox();
            this.labelModelo = new System.Windows.Forms.Label();
            this.textModelo = new System.Windows.Forms.TextBox();
            this.labelChofer = new System.Windows.Forms.Label();
            this.textChofer = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomoviles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAutomoviles
            // 
            this.dataGridViewAutomoviles.AllowUserToAddRows = false;
            this.dataGridViewAutomoviles.AllowUserToDeleteRows = false;
            this.dataGridViewAutomoviles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAutomoviles.ColumnHeadersVisible = false;
            this.dataGridViewAutomoviles.Location = new System.Drawing.Point(15, 129);
            this.dataGridViewAutomoviles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewAutomoviles.Name = "dataGridViewAutomoviles";
            this.dataGridViewAutomoviles.RowHeadersVisible = false;
            this.dataGridViewAutomoviles.RowTemplate.Height = 24;
            this.dataGridViewAutomoviles.Size = new System.Drawing.Size(459, 264);
            this.dataGridViewAutomoviles.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Patente
            // 
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            // 
            // Turno
            // 
            this.Turno.HeaderText = "Modelo";
            this.Turno.Name = "Turno";
            this.Turno.ReadOnly = true;
            // 
            // Habilitado
            // 
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            // 
            // buttonAlta
            // 
            this.buttonAlta.Location = new System.Drawing.Point(354, 59);
            this.buttonAlta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(100, 28);
            this.buttonAlta.TabIndex = 1;
            this.buttonAlta.Text = "Alta";
            this.buttonAlta.UseVisualStyleBackColor = true;
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(354, 91);
            this.buttonModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(100, 28);
            this.buttonModificar.TabIndex = 2;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(12, 9);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(47, 17);
            this.labelMarca.TabIndex = 4;
            this.labelMarca.Text = "Marca";
            // 
            // comboMarca
            // 
            this.comboMarca.DropDownWidth = 180;
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(13, 30);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(150, 24);
            this.comboMarca.TabIndex = 5;
            this.comboMarca.Text = "Seleccione Marca";
            // 
            // labelPatente
            // 
            this.labelPatente.AutoSize = true;
            this.labelPatente.Location = new System.Drawing.Point(179, 9);
            this.labelPatente.Name = "labelPatente";
            this.labelPatente.Size = new System.Drawing.Size(57, 17);
            this.labelPatente.TabIndex = 6;
            this.labelPatente.Text = "Patente";
            // 
            // textPatente
            // 
            this.textPatente.Location = new System.Drawing.Point(182, 32);
            this.textPatente.Name = "textPatente";
            this.textPatente.Size = new System.Drawing.Size(150, 22);
            this.textPatente.TabIndex = 7;
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(12, 70);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(54, 17);
            this.labelModelo.TabIndex = 8;
            this.labelModelo.Text = "Modelo";
            // 
            // textModelo
            // 
            this.textModelo.Location = new System.Drawing.Point(13, 91);
            this.textModelo.Name = "textModelo";
            this.textModelo.Size = new System.Drawing.Size(150, 22);
            this.textModelo.TabIndex = 9;
            // 
            // labelChofer
            // 
            this.labelChofer.AutoSize = true;
            this.labelChofer.Location = new System.Drawing.Point(182, 70);
            this.labelChofer.Name = "labelChofer";
            this.labelChofer.Size = new System.Drawing.Size(50, 17);
            this.labelChofer.TabIndex = 10;
            this.labelChofer.Text = "Chofer";
            // 
            // textChofer
            // 
            this.textChofer.Location = new System.Drawing.Point(185, 90);
            this.textChofer.Name = "textChofer";
            this.textChofer.Size = new System.Drawing.Size(150, 22);
            this.textChofer.TabIndex = 11;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(354, 26);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(100, 28);
            this.buttonBuscar.TabIndex = 12;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            // 
            // Automovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 404);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textChofer);
            this.Controls.Add(this.labelChofer);
            this.Controls.Add(this.textModelo);
            this.Controls.Add(this.labelModelo);
            this.Controls.Add(this.textPatente);
            this.Controls.Add(this.labelPatente);
            this.Controls.Add(this.comboMarca);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.dataGridViewAutomoviles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Automovil";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Automovil";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomoviles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.Button buttonModificar;

        private System.Windows.Forms.DataGridView dataGridViewAutomoviles;

        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Habilitado;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.Label labelPatente;
        private System.Windows.Forms.TextBox textPatente;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.TextBox textModelo;
        private System.Windows.Forms.Label labelChofer;
        private System.Windows.Forms.TextBox textChofer;
        private System.Windows.Forms.Button buttonBuscar;
    }
}