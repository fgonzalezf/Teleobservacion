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
                IGPUtilities pGputilities = new GPUtilitiesClass();
                ITable pTable = pGputilities.OpenTableFromString(@"E:\SICAT\TELEOBSERVACION\TeleObservacion.mdb\F03_USUARIOS");

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
    }
}
