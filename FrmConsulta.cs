using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Teleobservacion
{
    public partial class FrmConsulta : Form
    {
        public FrmConsulta()
        {
            InitializeComponent();
            map1.AddLayer(@"C:\Documents and Settings\Fernando\Mis documentos\Visual Studio 2010\Projects\Teleobservacion\Shapes_Magna\Planchas_100K.shp");
            map1.AddLayer(@"C:\Documents and Settings\Fernando\Mis documentos\Visual Studio 2010\Projects\Teleobservacion\Shapes_Magna\Municipios.shp");
            
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
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        
    }
}
