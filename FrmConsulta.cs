using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geodatabase;
using DotSpatial.Data;
using DotSpatial.Controls;
using DotSpatial.Symbology;
using DotSpatial.Topology;
using DotSpatial.Projections;
using System.Reflection;
using System.Threading;
using System.Net;
using ESRI.ArcGIS.esriSystem;
namespace Teleobservacion
{
    public partial class FrmConsulta : Form
    {
        
        ComboBox cbxTipoRadar = null;
        Label lblTipoRadar = null;
        TextBox txbIdentificador = null;
        Label lblTipoIdentificador = null;
        Label lblpath = null;
        TextBox txbPath = null;
        Label lblrow = null;
        TextBox txbRow = null;
        
         
        public FrmConsulta()
        {
            InitializeComponent();

            this.dateTimeFecha.Format = DateTimePickerFormat.Custom;
            this.dateTimeFecha.CustomFormat = " ";
            map1.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            map1.AddLayer(AssemblyDirectory + "/Shapes/Departamentos.shp");
            map1.AddLayer(AssemblyDirectory + "/Shapes/Planchas_100K.shp");
            map1.AddLayer(AssemblyDirectory + "/Shapes/Municipios.shp"); 
            map1.Layers[0].UseDynamicVisibility = true;
            map1.Layers[0].DynamicVisibilityWidth = 25;
            map1.Layers[0].DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;
            map1.Layers[1].UseDynamicVisibility = true;
            map1.Layers[1].DynamicVisibilityWidth = 8;
            map1.Layers[1].DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;
            map1.Layers[2].UseDynamicVisibility = true;
            map1.Layers[2].DynamicVisibilityWidth = 8;
            map1.Layers[2].DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;

            MapPolygonLayer stateLayer1 = default(MapPolygonLayer);
            MapPolygonLayer stateLayer2 = default(MapPolygonLayer);
            MapPolygonLayer stateLayer3 = default(MapPolygonLayer);

            stateLayer1 = (MapPolygonLayer)map1.Layers[0];
            stateLayer2 = (MapPolygonLayer)map1.Layers[1];
            stateLayer3 = (MapPolygonLayer)map1.Layers[2];

            stateLayer2.AddLabels("[PLANCHA]", new Font("Tahoma", (float)8.0), Color.Black);
            stateLayer2.LabelLayer.UseDynamicVisibility = true;
            stateLayer2.LabelLayer.DynamicVisibilityWidth = 8;
            stateLayer2.LabelLayer.DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;

            stateLayer3.AddLabels("[MUNICIPIO]", new Font("Tahoma", (float)6.0), Color.Red);
            stateLayer3.LabelLayer.UseDynamicVisibility = true;
            stateLayer3.LabelLayer.DynamicVisibilityWidth = 8;
            stateLayer3.LabelLayer.DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;

            PolygonSymbolizer poligonoblanco1 = new PolygonSymbolizer(Color.Empty);
            poligonoblanco1.OutlineSymbolizer = new LineSymbolizer(Color.Black, 1);
            stateLayer1.Symbolizer = poligonoblanco1;

            PolygonSymbolizer poligonoblanco2 = new PolygonSymbolizer(Color.Empty);
            poligonoblanco2.OutlineSymbolizer = new LineSymbolizer(Color.Blue, 1);
            stateLayer2.Symbolizer = poligonoblanco2;

            PolygonSymbolizer poligonoblanco3 = new PolygonSymbolizer(Color.Empty);
            poligonoblanco3.OutlineSymbolizer = new LineSymbolizer(Color.Green, 1);
            stateLayer3.Symbolizer = poligonoblanco3;
            
            llenarComboBox();

            map1.Refresh();

            
            
        }

        static public string AssemblyDirectory
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
            }
        }   
       

        private void btnAlejar_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = DotSpatial.Controls.FunctionMode.ZoomOut;           
        }

        private void llenarComboBox()
        {
            cbxTipo.Items.Add("");
            cbxTipo.Items.Add("RADAR");
            cbxTipo.Items.Add("LANDSAT TM");
            cbxTipo.Items.Add("LANDSAT ETM");
            cbxTipo.Items.Add("SPOT");
            cbxTipo.Items.Add("IKONOS");
            cbxTipo.Items.Add("ORTOFOTO");
            cbxTipo.Items.Add("ASTER");

            LlenarCombobox llenar = new LlenarCombobox();
            cbxDepartamento.DataSource = llenar.listaElementos(AssemblyDirectory + "/Shapes/Departamentos.shp", "NOMBRE", "");
            cbxPlanchas.DataSource = llenar.listaElementos(AssemblyDirectory + "/Shapes/Planchas_100K.shp", "PLANCHA", "");

            
            
        }

        private void btnFullExtent_Click(object sender, EventArgs e)
        {
            map1.ZoomToMaxExtent();
        }

        private void btnPaneo_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = DotSpatial.Controls.FunctionMode.Pan;
        }

        private void btnAcercar_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = DotSpatial.Controls.FunctionMode.ZoomIn;
            
            //Layer1.DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;
            //Layer1.DynamicVisibilityWidth = 2;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IGPUtilities pGputilities = new GPUtilitiesClass();
            string Query;
            IWorkspace pWorkspace = WorkgroupArcSdeWorkspaceFromPropertySet();
            IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
            ITable pTable=pFeatureWorkspace.OpenTable("TLOB.F03IMG_IMGN_100K");
            //ITable pTable = pGputilities.OpenTableFromString(@"E:\SICAT\TELEOBSERVACION\TeleObservacion.mdb\F03IMG_IMGN_100K");
            if (cbxTipoRadar!= null)
            {
                    Query = ConsutaExtent(txtLongitudMax.Text, txtLongitudMin.Text, txtLatitudMin.Text, txtLatitudMax.Text, cbxTipo.Text, txtNombre.Text, dateTimeFecha, groupBox2.Controls["cbxTipoRadar"].Text, groupBox2.Controls["txbIdentificador"].Text,"","");
            }
            else if (txbPath != null)
            {
                    Query = ConsutaExtent(txtLongitudMax.Text, txtLongitudMin.Text, txtLatitudMin.Text, txtLatitudMax.Text, cbxTipo.Text, txtNombre.Text, dateTimeFecha, "", "", groupBox2.Controls["txbPath"].Text, groupBox2.Controls["txbRow"].Text);
            }
            else
            {
                    Query = ConsutaExtent(txtLongitudMax.Text, txtLongitudMin.Text, txtLatitudMin.Text, txtLatitudMax.Text, cbxTipo.Text, txtNombre.Text, dateTimeFecha, "", "", "", "");
            }
            Table_To_DataTable pDataTable = new Table_To_DataTable();
            DataTable Tabla = pDataTable.ConvertITable(pTable, Query);
            dataGridViewResultados.DataSource = Tabla;
            dataGridViewResultados.Update();

           

        }

       

        private void cbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarCombobox llenar = new LlenarCombobox();
            char Comilla = '"';
            cbxMunicipio.DataSource = llenar.listaElementos(AssemblyDirectory + "/Shapes/Municipios.shp", "MUNICIPIO",  Comilla.ToString()+"DEPARTAMEN"+ Comilla.ToString()+"= '"+cbxDepartamento.Text+"'" );
            IFeatureLayer layerDepartamentos = (IFeatureLayer)map1.Layers[0];
            layerDepartamentos.SelectByAttribute("[NOMBRE]" + "= '" + cbxDepartamento.Text + "'");
            layerDepartamentos.ZoomToSelectedFeatures();
            map1.Refresh();

        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            cbxDepartamento.SelectedIndex = 0;
            cbxMunicipio.SelectedIndex = 0;
            cbxPlanchas.SelectedIndex = 0;
            cbxTipo.SelectedIndex = 0;
            txtLatitudMax.Text = "";
            txtLatitudMin.Text = "";
            txtLongitudMax.Text = "";
            txtLongitudMin.Text = "";
            txtNombre.Text = "";
            this.dateTimeFecha.Format = DateTimePickerFormat.Custom;
            this.dateTimeFecha.CustomFormat = " ";
        }

        private void cbxMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFeatureLayer layerMunicipios= (IFeatureLayer)map1.Layers[2];
            layerMunicipios.SelectByAttribute("[MUNICIPIO]" + "= '" + cbxMunicipio.Text + "'");
            layerMunicipios.ZoomToSelectedFeatures();
            map1.Refresh();
        }

        private void cbxPlanchas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDepartamento.SelectedIndex = 0;
            cbxMunicipio.SelectedIndex = 0;
            IFeatureLayer layerPlanchas = (IFeatureLayer)map1.Layers[1];
            layerPlanchas.SelectByAttribute("[PLANCHA]" + "= '" + cbxPlanchas.Text + "'");
            layerPlanchas.ZoomToSelectedFeatures();
            map1.Refresh();

        }

        private void dataGridViewResultados_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewResultados.SelectedRows)
            {
                NetworkCredential writeCredentials = new NetworkCredential("usr-siger","we3nya$i");
                using (new NetworkConnection(@"\\172.25.1.204\siger\imagenes\", writeCredentials))
                {
                    string filaSeleccionada = row.Cells[20].Value.ToString();
                    picMuestraGrafica.Image = Image.FromFile(@"\\172.25.1.204\siger\imagenes\" + filaSeleccionada);
                    picMuestraGrafica.Refresh();
                }
            }
        }

        

        private void picMuestraGrafica_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrmAmpliacion ampliarImagen = new FrmAmpliacion();
            ampliarImagen.CargarImagen(picMuestraGrafica.Image);
            ampliarImagen.Text = dataGridViewResultados.SelectedRows[0].Cells[20].Value.ToString();
            ampliarImagen.Show();
            ampliarImagen.Refresh();
        }
        private void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                string fileToCopy = @"\\172.25.1.204\siger\imagenes\" + dataGridViewResultados.SelectedRows[0].Cells[12].Value.ToString(); // or whatever 
                lblProceso.Text = "Descargando...";
                btnDescargar.Enabled = false;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sfd.FileName = dataGridViewResultados.SelectedRows[0].Cells[12].Value.ToString();
                sfd.Filter = "Jpeg Imagen|*.jpg|Bitmap Imagen|*.bmp|Tif Imagen|*.tif";
                sfd.FilterIndex = 1;
                sfd.ShowDialog();
                Thread threadExport = new Thread(() => copiaImagen(fileToCopy, sfd.FileName))
                {
                    IsBackground = true,
                    Name = "threadExport",
                    Priority = ThreadPriority.Normal
                };
                threadExport.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la descarga de la imagen" + ex.Message);
            }

        }

        public void copiaImagen(string fileToCopy, string Filename)
        {
            try
            {
                NetworkCredential writeCredentials = new NetworkCredential("usr-siger", "we3nya$i");
                using (new NetworkConnection(@"\\172.25.1.204\siger\imagenes\", writeCredentials))
                {

                    System.IO.File.Copy(fileToCopy, Filename, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conectandose al servidor de imagenes" + ex.Message);
            }
            try
            {

                IGPUtilities pGputilities = new GPUtilitiesClass();
                Table_To_DataTable tabla = new Table_To_DataTable();
                IWorkspace pWorkspace = WorkgroupArcSdeWorkspaceFromPropertySet();
                IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                ITable pTable = pFeatureWorkspace.OpenTable("TLOB.F03DES_DSCRG");
                tabla.registrarUsuario(pTable, Convert.ToInt32(dataGridViewResultados.SelectedRows[0].Cells[2].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error actualizando base de datos" + ex.Message);
            }
            lblProceso.Text = "Descarga Terminada";
            btnDescargar.Enabled = true;

        }

        

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbxTipo.Text == "RADAR")
            {
                if (groupBox2.Controls["txbPath"] != null)
                {
                    groupBox2.Controls.Remove(groupBox2.Controls["lblpath"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["txbPath"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["txbRow"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["lblrow"]);
                    
                    lblpath = null;
                    txbPath = null;
                    lblrow = null;
                    txbRow = null;
                }
                if (groupBox2.Controls["cbxTipoRadar"] == null)
                {
                    cbxTipoRadar = new ComboBox();
                    cbxTipoRadar.Location = new System.Drawing.Point(130, 260);
                    cbxTipoRadar.Name = "cbxTipoRadar";
                    cbxTipoRadar.Size = new System.Drawing.Size(315, 21);
                    cbxTipoRadar.Items.Add("");
                    cbxTipoRadar.Items.Add("Radarsat1");
                    cbxTipoRadar.Items.Add("Radarsat2");

                    lblTipoRadar = new Label();
                    lblTipoRadar.Name = "lblTipoRadar";
                    lblTipoRadar.Location = new System.Drawing.Point(22, 260);
                    lblTipoRadar.Text = "Tipo Radar ";


                    txbIdentificador = new TextBox();
                    txbIdentificador.Location = new System.Drawing.Point(130, 295);
                    txbIdentificador.Name = "txbIdentificador";
                    txbIdentificador.Size = new System.Drawing.Size(315, 21);


                    lblTipoIdentificador = new Label();
                    lblTipoIdentificador.Name = "lblTipoIdentificador";
                    lblTipoIdentificador.Location = new System.Drawing.Point(22, 295);
                    lblTipoIdentificador.Text = "Identificador ";


                    this.groupBox2.Controls.Add(cbxTipoRadar);
                    this.groupBox2.Controls.Add(lblTipoRadar);
                    this.groupBox2.Controls.Add(txbIdentificador);
                    this.groupBox2.Controls.Add(lblTipoIdentificador);
                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(groupBox2.Controls["cbxTipoRadar"], "Seleccione el Tipo de Radar");
                    tip.SetToolTip(groupBox2.Controls["txbIdentificador"], "Ingrese el Identificador de la Imagen a Mostrar");
                }

            }
            else if (cbxTipo.Text == "LANDSAT TM" || cbxTipo.Text == "LANDSAT ETM")
            {
                if (groupBox2.Controls["cbxTipoRadar"] != null)
                {
                    groupBox2.Controls.Remove(groupBox2.Controls["lblTipoRadar"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["cbxTipoRadar"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["txbIdentificador"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["lblTipoIdentificador"]);
                    cbxTipoRadar = null;
                    lblTipoRadar = null;
                    txbIdentificador = null;
                    lblTipoIdentificador = null;
                }
                if (groupBox2.Controls["txbPath"] == null)
                {
                    
                    lblpath = new Label();
                    lblpath.Name = "lblpath";
                    lblpath.Location = new System.Drawing.Point(22, 260);
                    lblpath.Text = "Path ";


                    txbPath = new TextBox();
                    txbPath.Location = new System.Drawing.Point(130, 260);
                    txbPath.Name = "txbPath";
                    txbPath.Size = new System.Drawing.Size(315, 21);


                    lblrow = new Label();
                    lblrow.Name = "lblrow";
                    lblrow.Location = new System.Drawing.Point(22, 295);
                    lblrow.Text = "Row ";

                    txbRow = new TextBox();
                    txbRow.Location = new System.Drawing.Point(130, 295);
                    txbRow.Name = "txbRow";
                    txbRow.Size = new System.Drawing.Size(315, 21);

                    this.groupBox2.Controls.Add(txbRow);
                    this.groupBox2.Controls.Add(lblpath);
                    this.groupBox2.Controls.Add(txbPath);
                    this.groupBox2.Controls.Add(lblrow);
                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(groupBox2.Controls["txbPath"], "Ingrese el Path de la Imagen a buscar");
                    tip.SetToolTip(groupBox2.Controls["txbRow"], "Ingrese el Row de la Imagen a buscar");
                }
            }
            else
            {
                if (groupBox2.Controls["cbxTipoRadar"] != null)
                {
                    groupBox2.Controls.Remove(groupBox2.Controls["lblTipoRadar"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["cbxTipoRadar"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["txbIdentificador"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["lblTipoIdentificador"]);
                    txbPath = null;
                    cbxTipoRadar = null;
                }
                else if (groupBox2.Controls["txbPath"] != null)
                {
                    groupBox2.Controls.Remove(groupBox2.Controls["lblpath"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["txbPath"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["txbRow"]);
                    groupBox2.Controls.Remove(groupBox2.Controls["lblrow"]);
                    txbPath = null;
                    cbxTipoRadar = null;
                }
                
            }


        }

        private void map1_ViewExtentsChanged(object sender, ExtentArgs e)
        {
            txtLatitudMax.Text = map1.ViewExtents.MaxY.ToString().Replace(",",".");
            txtLatitudMin.Text = map1.ViewExtents.MinY.ToString().Replace(",", ".");
            txtLongitudMax.Text = map1.ViewExtents.MaxX.ToString().Replace(",", ".");
            txtLongitudMin.Text = map1.ViewExtents.MinX.ToString().Replace(",", ".");        

        }
       

        private string ConsutaExtent( string xMax, string xMin, string yMin, string yMax, string tipo, string nombre, DateTimePicker fecha, string tipoRadar, string identificador, string path, string row)
        {
            
                string consulta = "";
              try
                {
                if (nombre != "")
                {
                    string cnombre = " AND IMG_NOMBRE =" + "'" + nombre + "'";
                    consulta = consulta + cnombre;
                }

                if (fecha.Text != " ")
                {

                    string cfecha = " AND IMG_FECHA =" + "TO_DATE('" + fecha.Value.ToString().Replace("/", "-") + "','DD-MM-YYYY HH24:MI:SS')";
                    consulta = consulta + cfecha;
                }

                if (tipo != "")
                {
                    string ctipo = " AND IMG_TIPO_IMGN =" + "'" + tipo + "'";
                    consulta = consulta + ctipo;
                }
                //[PST_TIPO_RADAR] = 1

                if (tipoRadar != "")
                {
                    string ctipoRadar;
                    if (tipoRadar == "Radarsat1")
                    {
                        ctipoRadar = " AND PST_TIPO_RADAR =" + "1";
                    }
                    else
                    {
                        ctipoRadar = " AND PST_TIPO_RADAR =" + "2";
                    }

                    consulta = consulta + ctipoRadar;
                }
                if (identificador != "")
                {
                    string cidentificador = " AND IMG_IDENT =" + "'" + identificador + "'";
                    consulta = consulta + cidentificador;
                }
                if (path != "")
                {
                    string cpath = " AND IMG_PATH =" + "'" + path + "'";
                    consulta = consulta + cpath;
                }
                if (row != "")
                {
                    string crow = " AND IMG_ROW =" + "'" + row + "'";
                    consulta = consulta + crow;
                }
                string latitudMinima = "";
                string latitudMaxima = "";
                string longitudMinima = "";
                string longitudMaxima = "";
                //[IMG_ROW] = '329' AND [IMG_PATH] = '4'
                if (yMin != "" && yMax != "" && xMin != "" && xMax != "")
                {
                    latitudMinima = "IMG_LAT_MIN >=" + yMin;
                    latitudMaxima = "IMG_LAT_MAX <=" + yMax;
                    longitudMinima = "IMG_LONG_MIN >=" + xMin;
                    longitudMaxima = "IMG_LONG_MAX <=" + xMax;
                    consulta = " AND " + latitudMinima + " AND " + latitudMaxima + " AND " + longitudMinima + " AND " + longitudMaxima + consulta;
                }
                if (consulta != "")
                {
                    consulta = consulta.Remove(0, 4);
                }
                //MessageBox.Show(consulta);
                return consulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta" + ex.Message);
                return consulta;
            }

        }

        private void dateTimeFecha_ValueChanged(object sender, EventArgs e)
        {
            dateTimeFecha.CustomFormat = "dd/MM/yyyy";
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.txtLatitudMin, "Latitud Minima en coordenadas Geográficas");
            tip.SetToolTip(this.txtLatitudMax, "Latitud Maxima en coordenadas Geográficas");
            tip.SetToolTip(this.txtLongitudMin, "Longitud Minima en coordenadas Geográficas");
            tip.SetToolTip(this.txtLongitudMax, "Longitud Maxima en coordenadas Geográficas");
            tip.SetToolTip(this.txtNombre, "Ingrese el nombre de la imagen Exacto");
            tip.SetToolTip(this.cbxDepartamento, "Seleccione el Departamento a busqueda");
            tip.SetToolTip(this.cbxMunicipio, "Seleccione el Municipio de busqueda");
            tip.SetToolTip(this.dateTimeFecha, "Seleccione la fecha exacta a buscar");
        }

        public static IWorkspace WorkgroupArcSdeWorkspaceFromPropertySet()
        {
            IPropertySet propertySet = new PropertySetClass();
            propertySet.SetProperty("SERVER", "172.25.3.110");
            propertySet.SetProperty("INSTANCE", "sde:oracle11g:sigprod_oda");
            propertySet.SetProperty("USER", "TLOB");
            propertySet.SetProperty("PASSWORD", "TeleobservacionSGC");
            propertySet.SetProperty("VERSION", "SDE.DEFAULT");
            propertySet.SetProperty("AUTHENTICATION_MODE", "DBMS");
            try
            {

                Type factoryType = Type.GetTypeFromProgID(
                    "esriDataSourcesGDB.SdeWorkspaceFactory");
                IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                    (factoryType);
                return workspaceFactory.Open(propertySet, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conectandose a la base de Datos" + ex.Message);
                return null;
            }

            
        }
            
            
        
        
    }
}
