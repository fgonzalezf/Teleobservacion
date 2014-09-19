namespace Teleobservacion
{
    partial class FrmConsulta
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
            this.map1 = new DotSpatial.Controls.Map();
            this.btnAcercar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnPaneo = new System.Windows.Forms.Button();
            this.btnFullExtent = new System.Windows.Forms.Button();
            this.btnAlejar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFecha = new System.Windows.Forms.ComboBox();
            this.txtLongitudMax = new System.Windows.Forms.TextBox();
            this.txtLongitudMin = new System.Windows.Forms.TextBox();
            this.txtLatitudMax = new System.Windows.Forms.TextBox();
            this.txtLatitudMin = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cbxMunicipio = new System.Windows.Forms.ComboBox();
            this.cbxDepartamento = new System.Windows.Forms.ComboBox();
            this.cbxPlanchas = new System.Windows.Forms.ComboBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewResultados = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.picMuestraGrafica = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultados)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMuestraGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.BackColor = System.Drawing.Color.White;
            this.map1.CollectAfterDraw = false;
            this.map1.CollisionDetection = false;
            this.map1.ExtendBuffer = false;
            this.map1.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.map1.IsBusy = false;
            this.map1.IsZoomedToMaxExtent = false;
            this.map1.Legend = null;
            this.map1.Location = new System.Drawing.Point(6, 16);
            this.map1.Name = "map1";
            this.map1.ProgressHandler = null;
            this.map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.RedrawLayersWhileResizing = false;
            this.map1.SelectionEnabled = true;
            this.map1.Size = new System.Drawing.Size(326, 292);
            this.map1.TabIndex = 0;
            this.map1.Load += new System.EventHandler(this.map1_Load);
            this.map1.GeoMouseMove += new System.EventHandler<DotSpatial.Controls.GeoMouseArgs>(map1_GeoMouseMove);
           
            // 
            // btnAcercar
            // 
            this.btnAcercar.Image = global::Teleobservacion.Properties.Resources.i_zoomin;
            this.btnAcercar.Location = new System.Drawing.Point(6, 314);
            this.btnAcercar.Name = "btnAcercar";
            this.btnAcercar.Size = new System.Drawing.Size(45, 47);
            this.btnAcercar.TabIndex = 1;
            this.btnAcercar.UseVisualStyleBackColor = true;
            this.btnAcercar.Click += new System.EventHandler(this.btnAcercar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnPaneo);
            this.groupBox1.Controls.Add(this.btnFullExtent);
            this.groupBox1.Controls.Add(this.btnAlejar);
            this.groupBox1.Controls.Add(this.map1);
            this.groupBox1.Controls.Add(this.btnAcercar);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 367);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar en el mapa";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(233, 326);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnPaneo
            // 
            this.btnPaneo.Image = global::Teleobservacion.Properties.Resources.i_pan;
            this.btnPaneo.Location = new System.Drawing.Point(159, 314);
            this.btnPaneo.Name = "btnPaneo";
            this.btnPaneo.Size = new System.Drawing.Size(45, 47);
            this.btnPaneo.TabIndex = 4;
            this.btnPaneo.UseVisualStyleBackColor = true;
            this.btnPaneo.Click += new System.EventHandler(this.btnPaneo_Click);
            // 
            // btnFullExtent
            // 
            this.btnFullExtent.Image = global::Teleobservacion.Properties.Resources.i_zoomfull;
            this.btnFullExtent.Location = new System.Drawing.Point(108, 314);
            this.btnFullExtent.Name = "btnFullExtent";
            this.btnFullExtent.Size = new System.Drawing.Size(45, 47);
            this.btnFullExtent.TabIndex = 3;
            this.btnFullExtent.UseVisualStyleBackColor = true;
            this.btnFullExtent.Click += new System.EventHandler(this.btnFullExtent_Click);
            // 
            // btnAlejar
            // 
            this.btnAlejar.Image = global::Teleobservacion.Properties.Resources.i_zoomout;
            this.btnAlejar.Location = new System.Drawing.Point(57, 314);
            this.btnAlejar.Name = "btnAlejar";
            this.btnAlejar.Size = new System.Drawing.Size(45, 47);
            this.btnAlejar.TabIndex = 2;
            this.btnAlejar.UseVisualStyleBackColor = true;
            this.btnAlejar.Click += new System.EventHandler(this.btnAlejar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimpiarBusqueda);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbxFecha);
            this.groupBox2.Controls.Add(this.txtLongitudMax);
            this.groupBox2.Controls.Add(this.txtLongitudMin);
            this.groupBox2.Controls.Add(this.txtLatitudMax);
            this.groupBox2.Controls.Add(this.txtLatitudMin);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.cbxMunicipio);
            this.groupBox2.Controls.Add(this.cbxDepartamento);
            this.groupBox2.Controls.Add(this.cbxPlanchas);
            this.groupBox2.Controls.Add(this.cbxTipo);
            this.groupBox2.Location = new System.Drawing.Point(357, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 366);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar por atributo";
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(346, 337);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(115, 23);
            this.btnLimpiarBusqueda.TabIndex = 20;
            this.btnLimpiarBusqueda.Text = "Limpiar Campos";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Fecha:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Max:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Max:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Longitud Min:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Latítud Min:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Planchas 1:100.000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Municipio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Departamento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tipo:";
            // 
            // cbxFecha
            // 
            this.cbxFecha.FormattingEnabled = true;
            this.cbxFecha.Location = new System.Drawing.Point(130, 229);
            this.cbxFecha.Name = "cbxFecha";
            this.cbxFecha.Size = new System.Drawing.Size(215, 21);
            this.cbxFecha.TabIndex = 9;
            // 
            // txtLongitudMax
            // 
            this.txtLongitudMax.Location = new System.Drawing.Point(307, 190);
            this.txtLongitudMax.Name = "txtLongitudMax";
            this.txtLongitudMax.Size = new System.Drawing.Size(138, 20);
            this.txtLongitudMax.TabIndex = 8;
            // 
            // txtLongitudMin
            // 
            this.txtLongitudMin.Location = new System.Drawing.Point(130, 190);
            this.txtLongitudMin.Name = "txtLongitudMin";
            this.txtLongitudMin.Size = new System.Drawing.Size(138, 20);
            this.txtLongitudMin.TabIndex = 7;
            // 
            // txtLatitudMax
            // 
            this.txtLatitudMax.Location = new System.Drawing.Point(307, 164);
            this.txtLatitudMax.Name = "txtLatitudMax";
            this.txtLatitudMax.Size = new System.Drawing.Size(138, 20);
            this.txtLatitudMax.TabIndex = 6;
            // 
            // txtLatitudMin
            // 
            this.txtLatitudMin.Location = new System.Drawing.Point(130, 164);
            this.txtLatitudMin.Name = "txtLatitudMin";
            this.txtLatitudMin.Size = new System.Drawing.Size(138, 20);
            this.txtLatitudMin.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(130, 57);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(315, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // cbxMunicipio
            // 
            this.cbxMunicipio.FormattingEnabled = true;
            this.cbxMunicipio.Location = new System.Drawing.Point(130, 110);
            this.cbxMunicipio.Name = "cbxMunicipio";
            this.cbxMunicipio.Size = new System.Drawing.Size(315, 21);
            this.cbxMunicipio.TabIndex = 3;
            // 
            // cbxDepartamento
            // 
            this.cbxDepartamento.FormattingEnabled = true;
            this.cbxDepartamento.Location = new System.Drawing.Point(130, 83);
            this.cbxDepartamento.Name = "cbxDepartamento";
            this.cbxDepartamento.Size = new System.Drawing.Size(315, 21);
            this.cbxDepartamento.TabIndex = 2;
            // 
            // cbxPlanchas
            // 
            this.cbxPlanchas.FormattingEnabled = true;
            this.cbxPlanchas.Location = new System.Drawing.Point(130, 137);
            this.cbxPlanchas.Name = "cbxPlanchas";
            this.cbxPlanchas.Size = new System.Drawing.Size(315, 21);
            this.cbxPlanchas.TabIndex = 1;
            // 
            // cbxTipo
            // 
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(130, 30);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(315, 21);
            this.cbxTipo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewResultados);
            this.groupBox3.Location = new System.Drawing.Point(12, 379);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 219);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultados";
            // 
            // dataGridViewResultados
            // 
            this.dataGridViewResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultados.Location = new System.Drawing.Point(7, 19);
            this.dataGridViewResultados.Name = "dataGridViewResultados";
            this.dataGridViewResultados.Size = new System.Drawing.Size(487, 194);
            this.dataGridViewResultados.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.picMuestraGrafica);
            this.groupBox4.Location = new System.Drawing.Point(518, 379);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(306, 219);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Muestra Gráfica";
            // 
            // picMuestraGrafica
            // 
            this.picMuestraGrafica.Location = new System.Drawing.Point(7, 19);
            this.picMuestraGrafica.Name = "picMuestraGrafica";
            this.picMuestraGrafica.Size = new System.Drawing.Size(293, 194);
            this.picMuestraGrafica.TabIndex = 0;
            this.picMuestraGrafica.TabStop = false;
            // 
            // FrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 610);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmConsulta";
            this.Text = "Consulta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultados)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMuestraGrafica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DotSpatial.Controls.Map map1;
        private System.Windows.Forms.Button btnAcercar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPaneo;
        private System.Windows.Forms.Button btnFullExtent;
        private System.Windows.Forms.Button btnAlejar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridViewResultados;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFecha;
        private System.Windows.Forms.TextBox txtLongitudMax;
        private System.Windows.Forms.TextBox txtLongitudMin;
        private System.Windows.Forms.TextBox txtLatitudMax;
        private System.Windows.Forms.TextBox txtLatitudMin;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cbxMunicipio;
        private System.Windows.Forms.ComboBox cbxDepartamento;
        private System.Windows.Forms.ComboBox cbxPlanchas;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.PictureBox picMuestraGrafica;
    }
}