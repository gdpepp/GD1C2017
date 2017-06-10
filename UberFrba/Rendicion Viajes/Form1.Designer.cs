namespace UberFrba.Rendicion_Viajes
{
    partial class RendicionViaje
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
            this.grupoChofer = new System.Windows.Forms.GroupBox();
            this.txtCDoc = new System.Windows.Forms.TextBox();
            this.dtCFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCMail = new System.Windows.Forms.TextBox();
            this.txtCTel = new System.Windows.Forms.TextBox();
            this.txtCApellido = new System.Windows.Forms.TextBox();
            this.txtCNombre = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupdatosRendicion = new System.Windows.Forms.GroupBox();
            this.comboChofer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btCalcular = new System.Windows.Forms.Button();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaRendicion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.grendicion = new System.Windows.Forms.GroupBox();
            this.dgMontoTotal = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgViajesRealizados = new System.Windows.Forms.DataGridView();
            this.grupoChofer.SuspendLayout();
            this.groupdatosRendicion.SuspendLayout();
            this.grendicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMontoTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViajesRealizados)).BeginInit();
            this.SuspendLayout();
            // 
            // grupoChofer
            // 
            this.grupoChofer.Controls.Add(this.txtCDoc);
            this.grupoChofer.Controls.Add(this.dtCFecha);
            this.grupoChofer.Controls.Add(this.txtCMail);
            this.grupoChofer.Controls.Add(this.txtCTel);
            this.grupoChofer.Controls.Add(this.txtCApellido);
            this.grupoChofer.Controls.Add(this.txtCNombre);
            this.grupoChofer.Controls.Add(this.label15);
            this.grupoChofer.Controls.Add(this.label16);
            this.grupoChofer.Controls.Add(this.label17);
            this.grupoChofer.Controls.Add(this.label18);
            this.grupoChofer.Controls.Add(this.label19);
            this.grupoChofer.Controls.Add(this.label20);
            this.grupoChofer.Enabled = false;
            this.grupoChofer.Location = new System.Drawing.Point(12, 227);
            this.grupoChofer.Name = "grupoChofer";
            this.grupoChofer.Size = new System.Drawing.Size(364, 182);
            this.grupoChofer.TabIndex = 25;
            this.grupoChofer.TabStop = false;
            this.grupoChofer.Text = "Datos Chofer";
            // 
            // txtCDoc
            // 
            this.txtCDoc.Location = new System.Drawing.Point(133, 73);
            this.txtCDoc.Name = "txtCDoc";
            this.txtCDoc.Size = new System.Drawing.Size(216, 20);
            this.txtCDoc.TabIndex = 15;
            // 
            // dtCFecha
            // 
            this.dtCFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtCFecha.Location = new System.Drawing.Point(133, 151);
            this.dtCFecha.Name = "dtCFecha";
            this.dtCFecha.Size = new System.Drawing.Size(216, 20);
            this.dtCFecha.TabIndex = 13;
            // 
            // txtCMail
            // 
            this.txtCMail.Location = new System.Drawing.Point(133, 125);
            this.txtCMail.Name = "txtCMail";
            this.txtCMail.Size = new System.Drawing.Size(216, 20);
            this.txtCMail.TabIndex = 12;
            // 
            // txtCTel
            // 
            this.txtCTel.Location = new System.Drawing.Point(133, 99);
            this.txtCTel.Name = "txtCTel";
            this.txtCTel.Size = new System.Drawing.Size(216, 20);
            this.txtCTel.TabIndex = 11;
            // 
            // txtCApellido
            // 
            this.txtCApellido.Location = new System.Drawing.Point(133, 48);
            this.txtCApellido.Name = "txtCApellido";
            this.txtCApellido.Size = new System.Drawing.Size(216, 20);
            this.txtCApellido.TabIndex = 8;
            // 
            // txtCNombre
            // 
            this.txtCNombre.Location = new System.Drawing.Point(133, 22);
            this.txtCNombre.Name = "txtCNombre";
            this.txtCNombre.Size = new System.Drawing.Size(216, 20);
            this.txtCNombre.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Fecha de nacimiento";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Nombre";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 102);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Teléfono";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Apellido";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 128);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Mail";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Número documento";
            // 
            // groupdatosRendicion
            // 
            this.groupdatosRendicion.Controls.Add(this.comboChofer);
            this.groupdatosRendicion.Controls.Add(this.label4);
            this.groupdatosRendicion.Controls.Add(this.btCalcular);
            this.groupdatosRendicion.Controls.Add(this.cbTurno);
            this.groupdatosRendicion.Controls.Add(this.label2);
            this.groupdatosRendicion.Controls.Add(this.fechaRendicion);
            this.groupdatosRendicion.Controls.Add(this.label1);
            this.groupdatosRendicion.Location = new System.Drawing.Point(12, 12);
            this.groupdatosRendicion.Name = "groupdatosRendicion";
            this.groupdatosRendicion.Size = new System.Drawing.Size(364, 209);
            this.groupdatosRendicion.TabIndex = 26;
            this.groupdatosRendicion.TabStop = false;
            this.groupdatosRendicion.Text = "Datos de la Rendicion";
            // 
            // comboChofer
            // 
            this.comboChofer.FormattingEnabled = true;
            this.comboChofer.Location = new System.Drawing.Point(133, 73);
            this.comboChofer.Name = "comboChofer";
            this.comboChofer.Size = new System.Drawing.Size(216, 21);
            this.comboChofer.TabIndex = 20;
            this.comboChofer.SelectedIndexChanged += new System.EventHandler(this.comboChofer_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Chofer";
            // 
            // btCalcular
            // 
            this.btCalcular.Location = new System.Drawing.Point(255, 170);
            this.btCalcular.Name = "btCalcular";
            this.btCalcular.Size = new System.Drawing.Size(94, 33);
            this.btCalcular.TabIndex = 18;
            this.btCalcular.Text = "Calcular";
            this.btCalcular.UseVisualStyleBackColor = true;
            this.btCalcular.Click += new System.EventHandler(this.btCalcular_Click);
            // 
            // cbTurno
            // 
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Location = new System.Drawing.Point(133, 46);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(216, 21);
            this.cbTurno.TabIndex = 17;
            this.cbTurno.SelectedIndexChanged += new System.EventHandler(this.cbTurno_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Turno";
            // 
            // fechaRendicion
            // 
            this.fechaRendicion.CustomFormat = "yyyy-MM-dd";
            this.fechaRendicion.Location = new System.Drawing.Point(133, 19);
            this.fechaRendicion.Name = "fechaRendicion";
            this.fechaRendicion.Size = new System.Drawing.Size(216, 20);
            this.fechaRendicion.TabIndex = 15;
            this.fechaRendicion.Value = new System.DateTime(2017, 6, 10, 17, 10, 28, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fecha de Rendicion";
            // 
            // grendicion
            // 
            this.grendicion.Controls.Add(this.dgMontoTotal);
            this.grendicion.Controls.Add(this.label3);
            this.grendicion.Controls.Add(this.dgViajesRealizados);
            this.grendicion.Location = new System.Drawing.Point(382, 12);
            this.grendicion.Name = "grendicion";
            this.grendicion.Size = new System.Drawing.Size(438, 279);
            this.grendicion.TabIndex = 27;
            this.grendicion.TabStop = false;
            this.grendicion.Text = "Rendicion";
            // 
            // dgMontoTotal
            // 
            this.dgMontoTotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMontoTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMontoTotal.Location = new System.Drawing.Point(329, 215);
            this.dgMontoTotal.Name = "dgMontoTotal";
            this.dgMontoTotal.Size = new System.Drawing.Size(109, 58);
            this.dgMontoTotal.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Viajes realizados";
            // 
            // dgViajesRealizados
            // 
            this.dgViajesRealizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViajesRealizados.Location = new System.Drawing.Point(0, 32);
            this.dgViajesRealizados.Name = "dgViajesRealizados";
            this.dgViajesRealizados.Size = new System.Drawing.Size(438, 177);
            this.dgViajesRealizados.TabIndex = 0;
            // 
            // RendicionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 421);
            this.Controls.Add(this.grendicion);
            this.Controls.Add(this.groupdatosRendicion);
            this.Controls.Add(this.grupoChofer);
            this.Name = "RendicionViaje";
            this.Text = "Rendicion de Viaje";
            this.Load += new System.EventHandler(this.RendicionViaje_Load);
            this.grupoChofer.ResumeLayout(false);
            this.grupoChofer.PerformLayout();
            this.groupdatosRendicion.ResumeLayout(false);
            this.groupdatosRendicion.PerformLayout();
            this.grendicion.ResumeLayout(false);
            this.grendicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMontoTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViajesRealizados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoChofer;
        private System.Windows.Forms.TextBox txtCDoc;
        private System.Windows.Forms.DateTimePicker dtCFecha;
        private System.Windows.Forms.TextBox txtCMail;
        private System.Windows.Forms.TextBox txtCTel;
        private System.Windows.Forms.TextBox txtCApellido;
        private System.Windows.Forms.TextBox txtCNombre;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupdatosRendicion;
        private System.Windows.Forms.Button btCalcular;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechaRendicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grendicion;
        private System.Windows.Forms.DataGridView dgMontoTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgViajesRealizados;
        private System.Windows.Forms.ComboBox comboChofer;
        private System.Windows.Forms.Label label4;
    }
}