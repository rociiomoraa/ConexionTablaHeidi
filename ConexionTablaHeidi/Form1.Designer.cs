namespace ConexionTablaHeidi
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAñadirAlumno = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.dataGridViewDatos = new System.Windows.Forms.DataGridView();
            this.dataGridViewNotas = new System.Windows.Forms.DataGridView();
            this.btnAñadirNota = new System.Windows.Forms.Button();
            this.btnModificarNota = new System.Windows.Forms.Button();
            this.btnEliminarNota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 467);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cargar desde BD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1326, 75);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(440, 427);
            this.textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1404, 546);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(304, 33);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1398, 623);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1398, 690);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "NOTA MEDIA:";
            // 
            // buttonAñadirAlumno
            // 
            this.buttonAñadirAlumno.Location = new System.Drawing.Point(526, 467);
            this.buttonAñadirAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAñadirAlumno.Name = "buttonAñadirAlumno";
            this.buttonAñadirAlumno.Size = new System.Drawing.Size(200, 56);
            this.buttonAñadirAlumno.TabIndex = 5;
            this.buttonAñadirAlumno.Text = "Añadir alumno";
            this.buttonAñadirAlumno.UseVisualStyleBackColor = true;
            this.buttonAñadirAlumno.Click += new System.EventHandler(this.buttonAñadirAlumno_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(1062, 467);
            this.buttonEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(200, 56);
            this.buttonEliminar.TabIndex = 6;
            this.buttonEliminar.Text = "Eliminar alumno";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridViewDatos
            // 
            this.dataGridViewDatos.AllowUserToAddRows = false;
            this.dataGridViewDatos.AllowUserToDeleteRows = false;
            this.dataGridViewDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatos.Location = new System.Drawing.Point(56, 56);
            this.dataGridViewDatos.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewDatos.MultiSelect = false;
            this.dataGridViewDatos.Name = "dataGridViewDatos";
            this.dataGridViewDatos.ReadOnly = true;
            this.dataGridViewDatos.RowHeadersWidth = 82;
            this.dataGridViewDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDatos.Size = new System.Drawing.Size(1206, 402);
            this.dataGridViewDatos.TabIndex = 7;
            this.dataGridViewDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDatos_CellContentClick);
            this.dataGridViewDatos.SelectionChanged += new System.EventHandler(this.dataGridViewDatos_Click);
            this.dataGridViewDatos.Click += new System.EventHandler(this.dataGridViewDatos_Click);
            // 
            // dataGridViewNotas
            // 
            this.dataGridViewNotas.AllowUserToAddRows = false;
            this.dataGridViewNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotas.Location = new System.Drawing.Point(56, 585);
            this.dataGridViewNotas.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewNotas.Name = "dataGridViewNotas";
            this.dataGridViewNotas.RowHeadersWidth = 82;
            this.dataGridViewNotas.Size = new System.Drawing.Size(868, 288);
            this.dataGridViewNotas.TabIndex = 8;
            // 
            // btnAñadirNota
            // 
            this.btnAñadirNota.Location = new System.Drawing.Point(954, 585);
            this.btnAñadirNota.Margin = new System.Windows.Forms.Padding(6);
            this.btnAñadirNota.Name = "btnAñadirNota";
            this.btnAñadirNota.Size = new System.Drawing.Size(150, 44);
            this.btnAñadirNota.TabIndex = 9;
            this.btnAñadirNota.Text = "Añadir";
            this.btnAñadirNota.UseVisualStyleBackColor = true;
            this.btnAñadirNota.Click += new System.EventHandler(this.btnAñadirNota_Click);
            // 
            // btnModificarNota
            // 
            this.btnModificarNota.Location = new System.Drawing.Point(954, 708);
            this.btnModificarNota.Margin = new System.Windows.Forms.Padding(6);
            this.btnModificarNota.Name = "btnModificarNota";
            this.btnModificarNota.Size = new System.Drawing.Size(150, 44);
            this.btnModificarNota.TabIndex = 10;
            this.btnModificarNota.Text = "Modificar";
            this.btnModificarNota.UseVisualStyleBackColor = true;
            this.btnModificarNota.Click += new System.EventHandler(this.btnModificarNota_Click);
            // 
            // btnEliminarNota
            // 
            this.btnEliminarNota.Location = new System.Drawing.Point(954, 829);
            this.btnEliminarNota.Margin = new System.Windows.Forms.Padding(6);
            this.btnEliminarNota.Name = "btnEliminarNota";
            this.btnEliminarNota.Size = new System.Drawing.Size(150, 44);
            this.btnEliminarNota.TabIndex = 11;
            this.btnEliminarNota.Text = "Eliminar";
            this.btnEliminarNota.UseVisualStyleBackColor = true;
            this.btnEliminarNota.Click += new System.EventHandler(this.btnEliminarNota_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1790, 938);
            this.Controls.Add(this.btnEliminarNota);
            this.Controls.Add(this.btnModificarNota);
            this.Controls.Add(this.btnAñadirNota);
            this.Controls.Add(this.dataGridViewNotas);
            this.Controls.Add(this.dataGridViewDatos);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonAñadirAlumno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alumnos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAñadirAlumno;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridViewDatos;
        private System.Windows.Forms.DataGridView dataGridViewNotas;
        private System.Windows.Forms.Button btnAñadirNota;
        private System.Windows.Forms.Button btnModificarNota;
        private System.Windows.Forms.Button btnEliminarNota;
    }
}

