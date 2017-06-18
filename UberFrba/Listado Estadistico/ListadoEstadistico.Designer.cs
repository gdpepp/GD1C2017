namespace UberFrba.Listado_Estadistico
{
    partial class ListadoEstadistico
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
            this.labelListados = new System.Windows.Forms.Label();
            this.comboListados = new System.Windows.Forms.ComboBox();
            this.labelAnio = new System.Windows.Forms.Label();
            this.comboAnios = new System.Windows.Forms.ComboBox();
            this.labelTrimestre = new System.Windows.Forms.Label();
            this.comboTrimestres = new System.Windows.Forms.ComboBox();
            this.dgvListadoEstadistico = new System.Windows.Forms.DataGridView();
            this.buttonBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEstadistico)).BeginInit();
            this.SuspendLayout();
            // 
            // labelListados
            // 
            this.labelListados.AutoSize = true;
            this.labelListados.Location = new System.Drawing.Point(13, 13);
            this.labelListados.Name = "labelListados";
            this.labelListados.Size = new System.Drawing.Size(127, 17);
            this.labelListados.TabIndex = 0;
            this.labelListados.Text = "Seleccione Listado";
            // 
            // comboListados
            // 
            this.comboListados.DropDownWidth = 340;
            this.comboListados.FormattingEnabled = true;
            this.comboListados.Items.AddRange(new object[] {
            "Chóferes con mayor recaudación",
            "Choferes con el viaje más largo realizado",
            "Clientes con mayor consumo",
            "Cliente que utilizo más veces el mismo automóvil"});
            this.comboListados.Location = new System.Drawing.Point(13, 34);
            this.comboListados.Name = "comboListados";
            this.comboListados.Size = new System.Drawing.Size(175, 24);
            this.comboListados.TabIndex = 1;
            // 
            // labelAnio
            // 
            this.labelAnio.AutoSize = true;
            this.labelAnio.Location = new System.Drawing.Point(195, 13);
            this.labelAnio.Name = "labelAnio";
            this.labelAnio.Size = new System.Drawing.Size(109, 17);
            this.labelAnio.TabIndex = 2;
            this.labelAnio.Text = "Seleccione Anio";
            // 
            // comboAnios
            // 
            this.comboAnios.FormattingEnabled = true;
            this.comboAnios.Location = new System.Drawing.Point(198, 34);
            this.comboAnios.Name = "comboAnios";
            this.comboAnios.Size = new System.Drawing.Size(175, 24);
            this.comboAnios.TabIndex = 3;
            // 
            // labelTrimestre
            // 
            this.labelTrimestre.AutoSize = true;
            this.labelTrimestre.Location = new System.Drawing.Point(380, 13);
            this.labelTrimestre.Name = "labelTrimestre";
            this.labelTrimestre.Size = new System.Drawing.Size(141, 17);
            this.labelTrimestre.TabIndex = 4;
            this.labelTrimestre.Text = "Seleccione Trimestre";
            // 
            // comboTrimestres
            // 
            this.comboTrimestres.FormattingEnabled = true;
            this.comboTrimestres.Items.AddRange(new object[] {
            "Primero",
            "Segundo",
            "Tercero",
            "Cuarto"});
            this.comboTrimestres.Location = new System.Drawing.Point(383, 34);
            this.comboTrimestres.Name = "comboTrimestres";
            this.comboTrimestres.Size = new System.Drawing.Size(175, 24);
            this.comboTrimestres.TabIndex = 5;
            // 
            // dgvListadoEstadistico
            // 
            this.dgvListadoEstadistico.AllowUserToAddRows = false;
            this.dgvListadoEstadistico.AllowUserToDeleteRows = false;
            this.dgvListadoEstadistico.AllowUserToResizeRows = false;
            this.dgvListadoEstadistico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListadoEstadistico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEstadistico.Enabled = false;
            this.dgvListadoEstadistico.Location = new System.Drawing.Point(13, 74);
            this.dgvListadoEstadistico.MultiSelect = false;
            this.dgvListadoEstadistico.Name = "dgvListadoEstadistico";
            this.dgvListadoEstadistico.ReadOnly = true;
            this.dgvListadoEstadistico.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvListadoEstadistico.RowTemplate.Height = 24;
            this.dgvListadoEstadistico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoEstadistico.Size = new System.Drawing.Size(654, 375);
            this.dgvListadoEstadistico.TabIndex = 6;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(567, 31);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(100, 28);
            this.buttonBuscar.TabIndex = 7;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 461);
            this.ControlBox = false;
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.dgvListadoEstadistico);
            this.Controls.Add(this.comboTrimestres);
            this.Controls.Add(this.labelTrimestre);
            this.Controls.Add(this.comboAnios);
            this.Controls.Add(this.labelAnio);
            this.Controls.Add(this.comboListados);
            this.Controls.Add(this.labelListados);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEstadistico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelListados;
        private System.Windows.Forms.ComboBox comboListados;
        private System.Windows.Forms.Label labelAnio;
        private System.Windows.Forms.ComboBox comboAnios;
        private System.Windows.Forms.Label labelTrimestre;
        private System.Windows.Forms.ComboBox comboTrimestres;
        private System.Windows.Forms.DataGridView dgvListadoEstadistico;
        private System.Windows.Forms.Button buttonBuscar;
    }
}