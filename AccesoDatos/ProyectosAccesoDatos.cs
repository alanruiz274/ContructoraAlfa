using System;
using System.Collections.Generic;
using System.Data;
using ConexionBD;
using Entidades;

namespace AccesoDatos
{
    public class ProyectosAccesoDatos: IAccionesBD
    {
        Conexion conexion;
        Proyectos proyectos;
        public ProyectosAccesoDatos()
        {
            conexion = new Conexion();
            proyectos = new Proyectos();
        }
        
        public string Eliminar(dynamic accion)
        {
            proyectos = accion;
            var consulta = string.Format("delete from proyectos WHERE IDProyecto='{0}'", proyectos.Idp);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Guardar(dynamic accion)
        {
            proyectos = accion;
            var consulta = string.Format("insert into proyectos values(null,'{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", proyectos.Descripcion, proyectos.Direccion, proyectos.Estado, proyectos.FechaInicio, proyectos.FechaFinalizado, proyectos.Latitud, proyectos.Longitud);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Modificar(dynamic accion)
        {
            proyectos = accion;
            var consulta = string.Format("update proyectos set Descripcion = '{0}', Direccion = '{1}', Estado = '{2}', FechaInicio = '{3}', FechaFinalizado = '{4}', Latitud = '{5}', Longitud = '{6}' WHERE IDProyecto='{7}'", proyectos.Descripcion, proyectos.Direccion, proyectos.Estado, proyectos.FechaInicio,proyectos.FechaFinalizado, proyectos.Latitud, proyectos.Longitud, proyectos.Idp);
            conexion.EjecutarConsulta(consulta);
            return "";
        }

        public List<Proyectos> Mostar(string filtro)//string filtro)
        {
            var list = new List<Proyectos>();
            string consulta = string.Format("Select * from proyectos where Descripcion like '%{0}%' order by IDProyecto desc", filtro);
            var ds = conexion.ObtenerDatos(consulta, "proyectos");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var proyectos = new Proyectos
                {
                    Idp = Convert.ToInt32(row["IDProyecto"].ToString()),
                    Descripcion = row["Descripcion"].ToString(),
                    Direccion = row["Direccion"].ToString(),
                    Estado = row["Estado"].ToString(),
                    FechaInicio = row["FechaInicio"].ToString(),
                    FechaFinalizado = row["FechaFinalizado"].ToString(),
                    Latitud = row["Latitud"].ToString(),
                    Longitud = row["Longitud"].ToString()
                };
                list.Add(proyectos);
            }
            return list;
        }
        public List<Proyectos> MostarCombo(string filtro)//string filtro)
        {
            var list = new List<Proyectos>();
            string consulta = string.Format("select IDProyecto, CONCAT( Descripcion, ' - ', Direccion) as Descripcion FROM proyectos where Estado='En Proceso' and Descripcion like '%{0}%' order by IDProyecto desc", filtro);
            var ds = conexion.ObtenerDatos(consulta, "proyectos");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var proyectos = new Proyectos
                {
                    Idp = Convert.ToInt32(row["IDProyecto"].ToString()),
                    Descripcion = row["Descripcion"].ToString()
                };
                list.Add(proyectos);
            }
            return list;
        }
    }
}
