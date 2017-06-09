namespace UberFrba.Abm_Automovil
{
    partial class AltaModificacionAutomoviles
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
            this.textModelo = new System.Windows.Forms.TextBox();
            this.textPatente = new System.Windows.Forms.TextBox();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.labelModelo = new System.Windows.Forms.Label();
            this.labelPatente = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.comboChofer = new System.Windows.Forms.ComboBox();
            this.checkHabilitado = new System.Windows.Forms.CheckBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.groupDatosAuto = new System.Windows.Forms.GroupBox();
            this.labelMarcas = new System.Windows.Forms.Label();
            this.labelTurnos = new System.Windows.Forms.Label();
            this.labelChoferes = new System.Windows.Forms.Label();
            this.groupDatosAuto.SuspendLayout();
            this.SuspendLayout();
            // 
            // textModelo
            // 
            this.textModelo.Location = new System.Drawing.Point(78, 57);
            this.textModelo.Name = "textModelo";
            this.textModelo.Size = new System.Drawing.Size(353, 22);
            this.textModelo.TabIndex = 2;
            // 
            // textPatente
            // 
            this.textPatente.Location = new System.Drawing.Point(78, 29);
            this.textPatente.Name = "textPatente";
            this.textPatente.Size = new System.Drawing.Size(353, 22);
            this.textPatente.TabIndex = 1;
            // 
            // comboMarca
            // 
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(78, 85);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(353, 24);
            this.comboMarca.TabIndex = 3;
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(18, 60);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(54, 17);
            this.labelModelo.TabIndex = 2;
            this.labelModelo.Text = "Modelo";
            // 
            // labelPatente
            // 
            this.labelPatente.AutoSize = true;
            this.labelPatente.Location = new System.Drawing.Point(18, 32);
            this.labelPatente.Name = "labelPatente";
            this.labelPatente.Size = new System.Drawing.Size(57, 17);
            this.labelPatente.TabIndex = 3;
            this.labelPatente.Text = "Patente";
            // 
            // comboTurno
            // 
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(239, 164);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(217, 24);
            this.comboTurno.TabIndex = 5;
            this.comboTurno.Text = "Turno";
            // 
            // comboChofer
            // 
            this.comboChofer.FormattingEnabled = true;
            this.comboChofer.Location = new System.Drawing.Point(11, 164);
            this.comboChofer.Name = "comboChofer";
            this.comboChofer.Size = new System.Drawing.Size(216, 24);
            this.comboChofer.TabIndex = 4;
            this.comboChofer.Text = "Chofer";
            this.comboChofer.SelectedIndexChanged += new System.EventHandler(this.comboChofer_SelectedIndexChanged);
            // 
            // checkHabilitado
            // 
            this.checkHabilitado.AutoSize = true;
            this.checkHabilitado.Location = new System.Drawing.Point(15, 198);
            this.checkHabilitado.Name = "checkHabilitado";
            this.checkHabilitado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkHabilitado.Size = new System.Drawing.Size(93, 21);
            this.checkHabilitado.TabIndex = 6;
            this.checkHabilitado.Text = "Habilitado";
            this.checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(156, 198);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(100, 28);
            this.buttonGuardar.TabIndex = 7;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(262, 198);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(100, 28);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Enabled = false;
            this.buttonEliminar.Location = new System.Drawing.Point(368, 198);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(100, 28);
            this.buttonEliminar.TabIndex = 9;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // groupDatosAuto
            // 
            this.groupDatosAuto.Controls.Add(this.labelMarcas);
            this.groupDatosAuto.Controls.Add(this.labelPatente);
            this.groupDatosAuto.Controls.Add(this.textPatente);
            this.groupDatosAuto.Controls.Add(this.labelModelo);
            this.groupDatosAuto.Controls.Add(this.textModelo);
            this.groupDatosAuto.Controls.Add(this.comboMarca);
            this.groupDatosAuto.Location = new System.Drawing.Point(12, 12);
            this.groupDatosAuto.Name = "groupDatosAuto";
            this.groupDatosAuto.Size = new System.Drawing.Size(456, 129);
            this.groupDatosAuto.TabIndex = 13;
            this.groupDatosAuto.TabStop = false;
            this.groupDatosAuto.Text = "Datos del Auto";
            // 
            // labelMarcas
            // 
            this.labelMarcas.AutoSize = true;
            this.labelMarcas.Location = new System.Drawing.Point(18, 88);
            this.labelMarcas.Name = "labelMarcas";
            this.labelMarcas.Size = new System.Drawing.Size(54, 17);
            this.labelMarcas.TabIndex = 5;
            this.labelMarcas.Text = "Marcas";
            // 
            // labelTurnos
            // 
            this.labelTurnos.AutoSize = true;
            this.labelTurnos.Location = new System.Drawing.Point(236, 144);
            this.labelTurnos.Name = "labelTurnos";
            this.labelTurnos.Size = new System.Drawing.Size(91, 17);
            this.labelTurnos.TabIndex = 14;
            this.labelTurnos.Text = "Elija un turno";
            // 
            // labelChoferes
            // 
            this.labelChoferes.AutoSize = true;
            this.labelChoferes.Location = new System.Drawing.Point(12, 144);
            this.labelChoferes.Name = "labelChoferes";
            this.labelChoferes.Size = new System.Drawing.Size(98, 17);
            this.labelChoferes.TabIndex = 15;
            this.labelChoferes.Text = "Elija un chofer";
            // 
            // AltaModificacionAutomoviles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 238);
            this.ControlBox = false;
            this.Controls.Add(this.labelChoferes);
            this.Controls.Add(this.labelTurnos);
            this.Controls.Add(this.groupDatosAuto);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.checkHabilitado);
            this.Controls.Add(this.comboChofer);
            this.Controls.Add(this.comboTurno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaModificacionAutomoviles";
            this.Text = "Alta Automovil";
            this.groupDatosAuto.ResumeLayout(false);
            this.groupDatosAuto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.TextBox textModelo;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.Label labelPatente;
        private System.Windows.Forms.TextBox textPatente;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.ComboBox comboChofer;
        private System.Windows.Forms.CheckBox checkHabilitado;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.GroupBox groupDatosAuto;
        private System.Windows.Forms.Label labelMarcas;
        private System.Windows.Forms.Label labelTurnos;
        private System.Windows.Forms.Label labelChoferes;
    }
}