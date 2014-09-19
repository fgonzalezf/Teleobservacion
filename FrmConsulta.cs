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
namespace Teleobservacion
{
    public partial class FrmConsulta : Form
    {
        MapPolygonLayer Layer1;
        MapPolygonLayer Layer2;
        MapPolygonLayer Layer3; 
        public FrmConsulta()
        {
            InitializeComponent();
            map1.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            map1.AddLayer(@"C:\Documents and Settings\Fernando\Mis documentos\Visual Studio 2010\Projects\Shapes\Departamentos.shp");
            map1.AddLayer(@"C:\Documents and Settings\Fernando\Mis documentos\Visual Studio 2010\Projects\Shapes\Municipios.shp");
            map1.AddLayer(@"C:\Documents and Settings\Fernando\Mis documentos\Visual Studio 2010\Projects\Shapes\Planchas_100K.shp");
            map1.Layers[0].UseDynamicVisibility = true;
            map1.Layers[0].DynamicVisibilityWidth = 1;
            map1.Layers[0].DynamicVisibilityMode = DynamicVisibilityMode.ZoomedOut;
            map1.Layers[1].UseDynamicVisibility = true;
            map1.Layers[1].DynamicVisibilityWidth = 1;
            map1.Layers[1].DynamicVisibilityMode = DynamicVisibilityMode.ZoomedOut;
            
            
            
            
        }

        
       

        private void btnAlejar_Click(object sender, EventArgs e)
        {

            map1.ZoomOut();
            
            



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
            map1.ZoomIn();
            
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

        }

        private void map1_Load(object sender, EventArgs e)
        {
           
        }
        private void map1_GeoMouseMove(object sender, EventArgs e)
        {
        }

        
        
    }
}
