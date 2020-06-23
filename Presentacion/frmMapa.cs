using System;
using System.Windows.Forms;
using LogicaNegocio;

namespace Presentacion
{
    public partial class frmMapa : Form
    {
        double latitud;
        double longitud;
        ProyectoManejador proyectoManejador;
        public frmMapa(double Latitud, double Longitud)
        {
            InitializeComponent();
            latitud = Latitud;
            longitud = Longitud;
            proyectoManejador = new ProyectoManejador();
        }

        private void frmMapa_Load(object sender, EventArgs e)
        {
            proyectoManejador.CargarMapa(gMapControl1, latitud, longitud);
            proyectoManejador.AgregarMarcador(gMapControl1, latitud, longitud);
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }
    }
}
