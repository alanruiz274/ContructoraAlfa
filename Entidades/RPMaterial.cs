namespace Entidades
{
    public class RPMaterial
    {
        private int _Idm;
        private string _Proyecto;
        private string _Fecha;
        private string _Nombre;
        private string _Concepto;
        private double _Cantidad;
        private double _Costo;
        private string _F;

        public int Idm { get => _Idm; set => _Idm = value; }
        public string Proyecto { get => _Proyecto; set => _Proyecto = value; }
        public string Fecha { get => _Fecha; set => _Fecha = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Concepto { get => _Concepto; set => _Concepto = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Costo { get => _Costo; set => _Costo = value; }
        public string F { get => _F; set => _F = value; }
    }
}
