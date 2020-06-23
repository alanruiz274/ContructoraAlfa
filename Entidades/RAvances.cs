namespace Entidades
{
    public class RAvances
    {
        private int _Ida;
        private string _Proyecto;
        private string _Encargado;
        private string _FechaAvance;
        private string _Avance;
        private double _Metros;
        private double _Pago;
        private string _F;

        public int Ida { get => _Ida; set => _Ida = value; }
        public string Proyecto { get => _Proyecto; set => _Proyecto = value; }
        public string Encargado { get => _Encargado; set => _Encargado = value; }
        public string FechaAvance { get => _FechaAvance; set => _FechaAvance = value; }
        public string Avance { get => _Avance; set => _Avance = value; }
        public double Metros { get => _Metros; set => _Metros = value; }
        public double Pago { get => _Pago; set => _Pago = value; }
        public string F { get => _F; set => _F = value; }
    }
}
