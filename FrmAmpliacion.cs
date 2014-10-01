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
    public partial class FrmAmpliacion : Form
    {
        
        

        public FrmAmpliacion()
        {
            InitializeComponent();
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarImagen(Image Imagen)
        {
            this.pictureBox1.Image = Imagen;
            this.pictureBox1.Refresh();
        }

        
    }
}
