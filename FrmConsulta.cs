using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Teleobservacion
{
    public partial class FrmConsulta : Form
    {
        public FrmConsulta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddLayerWM agregar = new AddLayerWM();
            axMap1.Projection = MapWinGIS.tkMapProjection.PROJECTION_GOOGLE_MERCATOR;
            axMap1.KnownExtents = MapWinGIS.tkKnownExtents.keColombia;
            agregar.AddLayers(axMap1,"C:/Documents and Settings/Fernando/Mis documentos/Visual Studio 2010/Projects/Teleobservacion/Shapes_Magna");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
