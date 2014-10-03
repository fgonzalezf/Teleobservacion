using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Teleobservacion
{
    public class Consulta : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public Consulta()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            ArcMap.Application.CurrentTool = null;
            Login Atentificacion = new Login();
            Atentificacion.Show();
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
