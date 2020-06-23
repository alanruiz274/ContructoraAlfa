using System.Collections.Generic;
using Entidades;
using AccesoDatos;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class ProyectoManejador
    {
        private static ProyectosAccesoDatos proyectosAccesoDatos;
        public ProyectoManejador()
        {
            proyectosAccesoDatos = new ProyectosAccesoDatos();
        }
        public void Guardar(Proyectos proyectos)
        {
            proyectosAccesoDatos.Guardar(proyectos);
        }
        public void Eliminar(Proyectos proyectos)
        {
            proyectosAccesoDatos.Eliminar(proyectos);
        }
        public void Modificar(Proyectos proyectos)
        {
            proyectosAccesoDatos.Modificar(proyectos);
        }
        public List<Proyectos> ObtenerProyectos(string filtro)
        {
            var list = new List<Proyectos>();
            list = proyectosAccesoDatos.Mostar(filtro);
            return list;
        }
        public List<Proyectos> ObtenerProyectosCombo(string filtro)
        {
            var list = new List<Proyectos>();
            list = proyectosAccesoDatos.MostarCombo(filtro);
            return list;
        }
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        public void CargarMapa(GMapControl gMapControl1, double latitud, double longitud)
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
        public void AgregarMarcador(GMapControl gMapControl1, double latitud, double longitud)
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
