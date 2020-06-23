using System.Collections.Generic;
using Entidades;
using AccesoDatos;


namespace LogicaNegocio
{
    public class EmpleadoManejador
    {
        private static EmpleadosAccesoDatos empleadosAccesoDatos;
        public EmpleadoManejador()
        {
            empleadosAccesoDatos = new EmpleadosAccesoDatos();
        }
        public void Guardar(Empleados empleados)
        {
            empleadosAccesoDatos.Guardar(empleados);
        }
        public void Eliminar(Empleados empleados)
        {
            empleadosAccesoDatos.Eliminar(empleados);
        }
        public void Modificar(Empleados empleados)
        {
            empleadosAccesoDatos.Modificar(empleados);
        }
        public List<Empleados> ObtenerEmpleados(string filtro)
        {
            var list = new List<Empleados>();
            list = empleadosAccesoDatos.Mostar(filtro);
            return list;
        }
        public List<Empleados> llenarCombo(string filtro)
        {
            var list = new List<Empleados>();
            list = empleadosAccesoDatos.llenarCombo(filtro);
            return list;
        }
    }
}
