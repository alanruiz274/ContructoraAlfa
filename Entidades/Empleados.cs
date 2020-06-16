namespace Entidades
{
    public class Empleados
    {
        private int _Ide;
        private string _Nombre;
        private string _ApellidoPaterno;
        private string _ApellidoMaterno;
        private string _Telefono;

        public int Ide { get => _Ide; set => _Ide = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string ApellidoPaterno { get => _ApellidoPaterno; set => _ApellidoPaterno = value; }
        public string ApellidoMaterno { get => _ApellidoMaterno; set => _ApellidoMaterno = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
    }
}
