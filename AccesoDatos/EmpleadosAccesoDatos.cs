using System;
using System.Collections.Generic;
using System.Data;
using ConexionBD;
using Entidades;

namespace AccesoDatos
{
    public class EmpleadosAccesoDatos : IAccionesBD
    {
        Conexion conexion;
        Empleados empleados;
        public EmpleadosAccesoDatos()
        {
            conexion = new Conexion();
            empleados = new Empleados();
        }
        public string Eliminar(dynamic accion)
        {
            empleados = accion;
            var consulta = string.Format("delete from empleados WHERE IDEmpleado='{0}'", empleados.Ide);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Guardar(dynamic accion)
        {
            empleados = accion;
            var consulta = string.Format("insert into empleados values(null,'{0}', '{1}', '{2}', '{3}')", empleados.Nombre, empleados.ApellidoPaterno, empleados.ApellidoMaterno, empleados.Telefono);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Modificar(dynamic accion)
        {
            empleados = accion;
            var consulta = string.Format("update empleados set Nombre = '{0}', ApellidoPaterno = '{1}', ApellidoMaterno = '{2}', Telefono = '{3}' WHERE IDEmpleado='{4}'", empleados.Nombre, empleados.ApellidoPaterno, empleados.ApellidoMaterno, empleados.Telefono, empleados.Ide);
            conexion.EjecutarConsulta(consulta);
            return "";
        }

        public List<Empleados> Mostar(string filtro)
        {
            var list = new List<Empleados>();
            string consulta = string.Format("Select * from empleados where Nombre like '%{0}%' order by IDEmpleado desc", filtro);
            var ds = conexion.ObtenerDatos(consulta, "empleados");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var empleados = new Empleados
                {
                    Ide = Convert.ToInt32(row["IDEmpleado"].ToString()),
                    Nombre = row["Nombre"].ToString(),
                    ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                    ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                    Telefono = row["Telefono"].ToString()
                };
                list.Add(empleados);
            }
            return list;
        }
    }
}
