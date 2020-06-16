using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Presentacion
{
    public partial class frmMapa : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        double latitud;
        double longitud;
        public frmMapa(double Latitud, double Longitud)
        {
            InitializeComponent();
            latitud = Latitud;
            longitud = Longitud;
        }

        private void frmMapa_Load(object sender, EventArgs e)
        {
            CargarMapa();
            AgregarMarcador();
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarMapa()
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(latitud, longitud);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;
        }
        private void AgregarMarcador()
        {
            //Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(latitud, longitud), GMarkerGoogleType.green_dot);
            markerOverlay.Markers.Add(marker); //agregamos al mapa

            //agregamos un tooltip de texto a los marcadores.
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicacion: \n Latitud: {0} \n Longitud: {1}", latitud, longitud);

            //agregamos el mapa y el marcador al map control
            gMapControl1.Overlays.Add(markerOverlay);
        }
    }
}
