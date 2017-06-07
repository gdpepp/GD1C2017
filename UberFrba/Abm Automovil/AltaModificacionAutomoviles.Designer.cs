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
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.textModelo = new System.Windows.Forms.TextBox();
            this.labelModelo = new System.Windows.Forms.Label();
            this.labelPatente = new System.Windows.Forms.Label();
            this.textPatente = new System.Windows.Forms.TextBox();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.comboChofer = new System.Windows.Forms.ComboBox();
            this.checkHabilitado = new System.Windows.Forms.CheckBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboMarca
            // 
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(13, 13);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(220, 24);
            this.comboMarca.TabIndex = 0;
            this.comboMarca.Text = "Seleccione Marca";
            // 
            // textModelo
            // 
            this.textModelo.Location = new System.Drawing.Point(75, 44);
            this.textModelo.Name = "textModelo";
            this.textModelo.Size = new System.Drawing.Size(158, 22);
            this.textModelo.TabIndex = 1;
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(12, 47);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(54, 17);
            this.labelModelo.TabIndex = 2;
            this.labelModelo.Text = "Modelo";
            // 
            // labelPatente
            // 
            this.labelPatente.AutoSize = true;
            this.labelPatente.Location = new System.Drawing.Point(12, 75);
            this.labelPatente.Name = "labelPatente";
            this.labelPatente.Size = new System.Drawing.Size(57, 17);
            this.labelPatente.TabIndex = 3;
            this.labelPatente.Text = "Patente";
            // 
            // textPatente
            // 
            this.textPatente.Location = new System.Drawing.Point(75, 72);
            this.textPatente.Name = "textPatente";
            this.textPatente.Size = new System.Drawing.Size(158, 22);
            this.textPatente.TabIndex = 4;
            // 
            // comboTurno
            // 
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(17, 100);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(217, 24);
            this.comboTurno.TabIndex = 5;
            this.comboTurno.Text = "Turno";
            // 
            // comboChofer
            // 
            this.comboChofer.FormattingEnabled = true;
            this.comboChofer.Location = new System.Drawing.Point(17, 130);
            this.comboChofer.Name = "comboChofer";
            this.comboChofer.Size = new System.Drawing.Size(216, 24);
            this.comboChofer.TabIndex = 6;
            this.comboChofer.Text = "Chofer";
            // 
            // checkHabilitado
            // 
            this.checkHabilitado.AutoSize = true;
            this.checkHabilitado.Location = new System.Drawing.Point(12, 160);
            this.checkHabilitado.Name = "checkHabilitado";
            this.checkHabilitado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkHabilitado.Size = new System.Drawing.Size(93, 21);
            this.checkHabilitado.TabIndex = 7;
            this.checkHabilitado.Text = "Habilitado";
            this.checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(256, 9);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(100, 28);
            this.buttonGuardar.TabIndex = 8;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(256, 47);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(100, 28);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Enabled = false;
            this.buttonEliminar.Location = new System.Drawing.Point(256, 81);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(100, 28);
            this.buttonEliminar.TabIndex = 10;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // AltaModificacionAutomoviles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 195);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.checkHabilitado);
            this.Controls.Add(this.comboChofer);
            this.Controls.Add(this.comboTurno);
            this.Controls.Add(this.textPatente);
            this.Controls.Add(this.labelPatente);
            this.Controls.Add(this.labelModelo);
            this.Controls.Add(this.textModelo);
            this.Controls.Add(this.comboMarca);
            this.Name = "AltaModificacionAutomoviles";
            this.Text = "Alta/Modificacion Automovil";
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
    }
}