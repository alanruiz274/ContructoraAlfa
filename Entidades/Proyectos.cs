namespace Entidades
{
    public class Proyectos
    {
        private int _Idp;
        private string _Descripcion;
        private string _Direccion;
        private string _Estado;
        private string _FechaInicio;
        private string _FechaFinalizado;
        private string _Latitud;
        private string _Longitud;

        public int Idp { get => _Idp; set => _Idp = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string FechaInicio { get => _FechaInicio; set => _FechaInicio = value; }
        public string FechaFinalizado { get => _FechaFinalizado; set => _FechaFinalizado = value; }
        public string Latitud { get => _Latitud; set => _Latitud = value; }
        public string Longitud { get => _Longitud; set => _Longitud = value; }
    }
}
