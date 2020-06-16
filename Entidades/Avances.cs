namespace Entidades
{
    public class Avances
    {
        private int _Ida;
        private string _Proyecto;
        private string _Encargado;
        private string _FechaAvance;
        private string _Avance;
        private string _Metros;
        private string _Pago;
        private int _FKProyecto;
        private int _FKEmpleado;

        public int Ida { get => _Ida; set => _Ida = value; }
        public string Proyecto { get => _Proyecto; set => _Proyecto = value; }
        public string Encargado { get => _Encargado; set => _Encargado = value; }
        public string FechaAvance { get => _FechaAvance; set => _FechaAvance = value; }
        public string Avance { get => _Avance; set => _Avance = value; }
        public string Metros { get => _Metros; set => _Metros = value; }
        public string Pago { get => _Pago; set => _Pago = value; }
        public int FKProyecto { get => _FKProyecto; set => _FKProyecto = value; }
        public int FKEmpleado { get => _FKEmpleado; set => _FKEmpleado = value; }
    }
}
