using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace Teleobservacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show(" Ingrese su Usuario");
            }
            if (txtContraseña.Text == "")
            {
                MessageBox.Show(" Ingrese la contraseña");
            }
            if (txtUsuario.Text != "" && txtContraseña.Text != "")
            {
                IWorkspace pWorkspace = WorkgroupArcSdeWorkspaceFromPropertySet();
                IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                ITable pTable = pFeatureWorkspace.OpenTable("TLOB.F03_USUARIOS");

                Table_To_DataTable tabla = new Table_To_DataTable();
                bool autentifiacion = tabla.autentificacion(pTable, txtUsuario.Text, txtContraseña.Text);
                if (autentifiacion)
                {
                    FrmConsulta Consulta = new FrmConsulta();
                    Consulta.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario ó Contraseña invalidos");
                }
            }
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

            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.SdeWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            return workspaceFactory.Open(propertySet, 0);
        }
    }
}
