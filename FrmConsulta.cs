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
namespace Teleobservacion
{
    public partial class FrmConsulta : Form
    {
         
        public FrmConsulta()
        {
            InitializeComponent();
            
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
            cbxTipo.Items.Add("SPOT");
            cbxTipo.Items.Add("LANDSAT");
            cbxTipo.Items.Add("RADAR");
            cbxTipo.Items.Add("FOTOGRAFIA AEREA");

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
            ITable pTable = pGputilities.OpenTableFromString(@"E:\SICAT\TELEOBSERVACION\TeleObservacion.mdb\F03IMG_IMGN_100K");
            Table_To_DataTable pDataTable = new Table_To_DataTable();
            DataTable Tabla = pDataTable.ConvertITable(pTable, "");
            dataGridViewResultados.DataSource = Tabla;
            dataGridViewResultados.Update();

            MessageBox.Show("X MAX: " + map1.ViewExtents.MaxX.ToString() + "   " + "X MIN: " + map1.ViewExtents.MinX.ToString() + "   " + "Y MAX: " + map1.ViewExtents.MaxY.ToString() + "   " + "Y MIN: " + map1.ViewExtents.MinY.ToString());

        }

        private void map1_Load(object sender, EventArgs e)
        {
           
        }
        private void map1_GeoMouseMove(object sender, EventArgs e)
        {
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


        //               \\172.25.1.204\siger\imagenes
        
        
    }
}
