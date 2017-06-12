namespace UberFrba.Abm_Turno
{
    partial class AbmTurno
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
            this.bt_nuevo_cliente = new System.Windows.Forms.Button();
            this.BTModificar = new System.Windows.Forms.Button();
            this.fieldDescription = new System.Windows.Forms.TextBox();
            this.BuscarPor = new System.Windows.Forms.Label();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_modificar = new System.Windows.Forms.Button();
            this.bt_nuevo = new System.Windows.Forms.Button();
            this.bt_volver = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_nuevo_cliente
            // 
            this.bt_nuevo_cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_nuevo_cliente.Location = new System.Drawing.Point(721, 377);
            this.bt_nuevo_cliente.Name = "bt_nuevo_cliente";
            this.bt_nuevo_cliente.Size = new System.Drawing.Size(85, 27);
            this.bt_nuevo_cliente.TabIndex = 47;
            this.bt_nuevo_cliente.Text = "Nuevo cliente";
            this.bt_nuevo_cliente.UseVisualStyleBackColor = true;
            // 
            // BTModificar
            // 
            this.BTModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTModificar.Location = new System.Drawing.Point(630, 377);
            this.BTModificar.Name = "BTModificar";
            this.BTModificar.Size = new System.Drawing.Size(85, 27);
            this.BTModificar.TabIndex = 48;
            this.BTModificar.Text = "Modificar";
            this.BTModificar.UseVisualStyleBackColor = true;
            // 
            // fieldDescription
            // 
            this.fieldDescription.Location = new System.Drawing.Point(90, 19);
            this.fieldDescription.Name = "fieldDescription";
            this.fieldDescription.Size = new System.Drawing.Size(123, 20);
            this.fieldDescription.TabIndex = 40;
            // 
            // BuscarPor
            // 
            this.BuscarPor.AutoSize = true;
            this.BuscarPor.Location = new System.Drawing.Point(6, 22);
            this.BuscarPor.Name = "BuscarPor";
            this.BuscarPor.Size = new System.Drawing.Size(66, 13);
            this.BuscarPor.TabIndex = 44;
            this.BuscarPor.Text = "Descripcion:";
            // 
            // bt_buscar
            // 
            this.bt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_buscar.Location = new System.Drawing.Point(459, 15);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(85, 27);
            this.bt_buscar.TabIndex = 38;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.bt_buscar);
            this.groupBox3.Controls.Add(this.BuscarPor);
            this.groupBox3.Controls.Add(this.fieldDescription);
            this.groupBox3.Location = new System.Drawing.Point(8, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 52);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtros";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(549, 203);
            this.dataGridView1.TabIndex = 49;
            // 
            // bt_modificar
            // 
            this.bt_modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_modificar.Location = new System.Drawing.Point(381, 291);
            this.bt_modificar.Name = "bt_modificar";
            this.bt_modificar.Size = new System.Drawing.Size(85, 27);
            this.bt_modificar.TabIndex = 52;
            this.bt_modificar.Text = "Modificar";
            this.bt_modificar.UseVisualStyleBackColor = true;
            this.bt_modificar.Click += new System.EventHandler(this.bt_modificar_Click);
            // 
            // bt_nuevo
            // 
            this.bt_nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_nuevo.Location = new System.Drawing.Point(472, 291);
            this.bt_nuevo.Name = "bt_nuevo";
            this.bt_nuevo.Size = new System.Drawing.Size(85, 27);
            this.bt_nuevo.TabIndex = 51;
            this.bt_nuevo.Text = "Nuevo cliente";
            this.bt_nuevo.UseVisualStyleBackColor = true;
            this.bt_nuevo.Click += new System.EventHandler(this.bt_nuevo_Click_1);
            // 
            // bt_volver
            // 
            this.bt_volver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_volver.Location = new System.Drawing.Point(7, 291);
            this.bt_volver.Name = "bt_volver";
            this.bt_volver.Size = new System.Drawing.Size(85, 27);
            this.bt_volver.TabIndex = 53;
            this.bt_volver.Text = "Volver";
            this.bt_volver.UseVisualStyleBackColor = true;
            this.bt_volver.Click += new System.EventHandler(this.bt_volver_Click);
            // 
            // AbmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 330);
            this.Controls.Add(this.bt_volver);
            this.Controls.Add(this.bt_modificar);
            this.Controls.Add(this.bt_nuevo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BTModificar);
            this.Controls.Add(this.bt_nuevo_cliente);
            this.Name = "AbmTurno";
            this.Text = "AbmTurno";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_nuevo_cliente;
        private System.Windows.Forms.Button BTModificar;
        private System.Windows.Forms.TextBox fieldDescription;
        private System.Windows.Forms.Label BuscarPor;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_modificar;
        private System.Windows.Forms.Button bt_nuevo;
        private System.Windows.Forms.Button bt_volver;
    }
}