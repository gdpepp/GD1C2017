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
            this.buttonAlta = new System.Windows.Forms.Button();
            this.labelMarca = new System.Windows.Forms.Label();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.labelPatente = new System.Windows.Forms.Label();
            this.textPatente = new System.Windows.Forms.TextBox();
            this.labelModelo = new System.Windows.Forms.Label();
            this.textModelo = new System.Windows.Forms.TextBox();
            this.labelChofer = new System.Windows.Forms.Label();
            this.textChofer = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dgvAutos = new System.Windows.Forms.DataGridView();
            this.IdAutos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdChofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).BeginInit();
            this.SuspendLayout();
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
            this.buttonAlta.Click += new System.EventHandler(this.buttonAlta_Click);
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
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dgvAutos
            // 
            this.dgvAutos.AllowUserToAddRows = false;
            this.dgvAutos.AllowUserToDeleteRows = false;
            this.dgvAutos.AllowUserToResizeRows = false;
            this.dgvAutos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvAutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAutos,
            this.IdChofer,
            this.Chofer,
            this.Patente,
            this.IdMarca,
            this.Marca,
            this.IdModelo,
            this.Modelo,
            this.IdTurno,
            this.Turno,
            this.Habilitado});
            this.dgvAutos.Location = new System.Drawing.Point(12, 124);
            this.dgvAutos.MultiSelect = false;
            this.dgvAutos.Name = "dgvAutos";
            this.dgvAutos.ReadOnly = true;
            this.dgvAutos.RowTemplate.Height = 24;
            this.dgvAutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutos.Size = new System.Drawing.Size(462, 268);
            this.dgvAutos.TabIndex = 13;
            this.dgvAutos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAutos_CellMouseDoubleClick);
            // 
            // IdAutos
            // 
            this.IdAutos.DataPropertyName = "IdAutos";
            this.IdAutos.HeaderText = "IdAutos";
            this.IdAutos.Name = "IdAutos";
            this.IdAutos.ReadOnly = true;
            this.IdAutos.Visible = false;
            // 
            // IdChofer
            // 
            this.IdChofer.DataPropertyName = "IdChofer";
            this.IdChofer.HeaderText = "IdChofer";
            this.IdChofer.Name = "IdChofer";
            this.IdChofer.ReadOnly = true;
            this.IdChofer.Visible = false;
            // 
            // Chofer
            // 
            this.Chofer.DataPropertyName = "Chofer";
            this.Chofer.HeaderText = "Chofer";
            this.Chofer.Name = "Chofer";
            this.Chofer.ReadOnly = true;
            // 
            // Patente
            // 
            this.Patente.DataPropertyName = "Patente";
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            // 
            // IdMarca
            // 
            this.IdMarca.DataPropertyName = "IdMarca";
            this.IdMarca.HeaderText = "IdMarca";
            this.IdMarca.Name = "IdMarca";
            this.IdMarca.ReadOnly = true;
            this.IdMarca.Visible = false;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "Marca";
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // IdModelo
            // 
            this.IdModelo.DataPropertyName = "IdModelo";
            this.IdModelo.HeaderText = "IdModelo";
            this.IdModelo.Name = "IdModelo";
            this.IdModelo.ReadOnly = true;
            this.IdModelo.Visible = false;
            // 
            // Modelo
            // 
            this.Modelo.DataPropertyName = "Modelo";
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            // 
            // IdTurno
            // 
            this.IdTurno.DataPropertyName = "IdTurno";
            this.IdTurno.HeaderText = "IdTurno";
            this.IdTurno.Name = "IdTurno";
            this.IdTurno.ReadOnly = true;
            this.IdTurno.Visible = false;
            // 
            // Turno
            // 
            this.Turno.DataPropertyName = "Turno";
            this.Turno.HeaderText = "Turno";
            this.Turno.Name = "Turno";
            this.Turno.ReadOnly = true;
            // 
            // Habilitado
            // 
            this.Habilitado.DataPropertyName = "Habilitado";
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            // 
            // Automovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 404);
            this.Controls.Add(this.dgvAutos);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textChofer);
            this.Controls.Add(this.labelChofer);
            this.Controls.Add(this.textModelo);
            this.Controls.Add(this.labelModelo);
            this.Controls.Add(this.textPatente);
            this.Controls.Add(this.labelPatente);
            this.Controls.Add(this.comboMarca);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.buttonAlta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Automovil";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Automovil";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.Label labelPatente;
        private System.Windows.Forms.TextBox textPatente;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.TextBox textModelo;
        private System.Windows.Forms.Label labelChofer;
        private System.Windows.Forms.TextBox textChofer;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.DataGridView dgvAutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdChofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turno;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitado;
    }
}