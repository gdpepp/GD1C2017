namespace UberFrba.Abm_Chofer
{
    partial class ABMChofer
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
            this.bt_nuevo_chofer = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.BTModificar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fieldDocument = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BuscarPor = new System.Windows.Forms.Label();
            this.fieldName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_nuevo_chofer
            // 
            this.bt_nuevo_chofer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_nuevo_chofer.Location = new System.Drawing.Point(725, 363);
            this.bt_nuevo_chofer.Name = "bt_nuevo_chofer";
            this.bt_nuevo_chofer.Size = new System.Drawing.Size(85, 27);
            this.bt_nuevo_chofer.TabIndex = 0;
            this.bt_nuevo_chofer.Text = "Nuevo chofer";
            this.bt_nuevo_chofer.UseVisualStyleBackColor = true;
            this.bt_nuevo_chofer.Click += new System.EventHandler(this.bt_nuevo_chofer_Click);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_buscar.Location = new System.Drawing.Point(707, 15);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(85, 27);
            this.bt_buscar.TabIndex = 1;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.button2_Click);
            // 
            // BTModificar
            // 
            this.BTModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTModificar.Location = new System.Drawing.Point(634, 363);
            this.BTModificar.Name = "BTModificar";
            this.BTModificar.Size = new System.Drawing.Size(85, 27);
            this.BTModificar.TabIndex = 6;
            this.BTModificar.Text = "Modificar";
            this.BTModificar.UseVisualStyleBackColor = true;
            this.BTModificar.Click += new System.EventHandler(this.BTModificar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(798, 293);
            this.dataGridView1.TabIndex = 46;
            // 
            // fieldDocument
            // 
            this.fieldDocument.Location = new System.Drawing.Point(409, 22);
            this.fieldDocument.Name = "fieldDocument";
            this.fieldDocument.Size = new System.Drawing.Size(123, 20);
            this.fieldDocument.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "DNI:";
            // 
            // fieldSurname
            // 
            this.fieldSurname.Location = new System.Drawing.Point(248, 22);
            this.fieldSurname.Name = "fieldSurname";
            this.fieldSurname.Size = new System.Drawing.Size(123, 20);
            this.fieldSurname.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Apellido:";
            // 
            // BuscarPor
            // 
            this.BuscarPor.AutoSize = true;
            this.BuscarPor.Location = new System.Drawing.Point(19, 25);
            this.BuscarPor.Name = "BuscarPor";
            this.BuscarPor.Size = new System.Drawing.Size(47, 13);
            this.BuscarPor.TabIndex = 51;
            this.BuscarPor.Text = "Nombre:";
            // 
            // fieldName
            // 
            this.fieldName.Location = new System.Drawing.Point(69, 22);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(123, 20);
            this.fieldName.TabIndex = 50;
            this.fieldName.TextChanged += new System.EventHandler(this.fieldName_TextChanged);
            // 
            // ABMChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 421);
            this.ControlBox = false;
            this.Controls.Add(this.fieldDocument);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fieldSurname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BuscarPor);
            this.Controls.Add(this.fieldName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTModificar);
            this.Controls.Add(this.bt_buscar);
            this.Controls.Add(this.bt_nuevo_chofer);
            this.Name = "ABMChofer";
            this.ShowIcon = false;
            this.Text = "Gestion de choferes";
            this.Load += new System.EventHandler(this.ABMChofer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_nuevo_chofer;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.Button BTModificar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox fieldDocument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fieldSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BuscarPor;
        private System.Windows.Forms.TextBox fieldName;
    }
}