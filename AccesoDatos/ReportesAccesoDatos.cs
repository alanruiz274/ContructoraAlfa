using System;
using System.Collections.Generic;
using Entidades;
using ConexionBD;
using System.Data;

namespace AccesoDatos
{
    public class ReportesAccesoDatos
    {
        Conexion conexion;
        public ReportesAccesoDatos()
        {
            conexion = new Conexion();
        }
        public List<Proyectos> MostarCombo()
        {
            var list = new List<Proyectos>();
            string consulta = string.Format("select IDProyecto, CONCAT( Descripcion, ' - ', Direccion) as Descripcion FROM proyectos order by IDProyecto desc");
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
        public List<Proyectos> MostarPT()
        {
            var list = new List<Proyectos>();
            string consulta = string.Format("select * from proyectos order by IDProyecto desc");
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
        public List<Proyectos> MostarPTE(string estado)
        {
            var list = new List<Proyectos>();
            string consulta = string.Format("select * from proyectos where Estado = '{0}' order by IDProyecto desc",estado);
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
        public List<Proyectos> MostarPF(string f1, string f2)
        {
            var list = new List<Proyectos>();
            string consulta = string.Format("select * from proyectos where FechaInicio BETWEEN '{0}' and '{1}' order by IDProyecto desc", f1, f2);
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
        public List<Proyectos> MostarPFE(string estado, string f1, string f2)
        {
            var list = new List<Proyectos>();
            string consulta = string.Format("select * from proyectos where Estado = '{0}' and FechaInicio BETWEEN '{1}' and '{2}' order by IDProyecto desc", estado, f1, f2);
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

        //material
        public List<Material> MostarMT(string p)
        {
            var list = new List<Material>();
            string consulta = string.Format("Select IDMaterial, proyecto, Fecha, Nombre, Concepto, Cantidad, Costo,FKProyecto from vmaterial where FKProyecto ='{0}' order by IDMaterial desc", p);
            var ds = conexion.ObtenerDatos(consulta, "vmaterial");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var material = new Material
                {
                    Idm = Convert.ToInt32(row["IDMaterial"].ToString()),
                    Proyecto = row["proyecto"].ToString(),
                    Fecha = row["Fecha"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Concepto = row["Concepto"].ToString(),
                    Cantidad = Convert.ToDouble(row["Cantidad"].ToString()),
                    Costo = Convert.ToDouble(row["Costo"].ToString())
                };
                list.Add(material);
            }
            return list;
        }
        public List<Material> MostarMTF(string p, string f1, string f2)
        {
            var list = new List<Material>();
            string consulta = string.Format("Select IDMaterial, proyecto, Fecha, Nombre, Concepto, Cantidad, Costo,FKProyecto from vmaterial where FKProyecto ='{0}' and Fecha BETWEEN '{1}' and '{2}' order by IDMaterial desc", p, f1, f2);
            var ds = conexion.ObtenerDatos(consulta, "vmaterial");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var material = new Material
                {
                    Idm = Convert.ToInt32(row["IDMaterial"].ToString()),
                    Proyecto = row["proyecto"].ToString(),
                    Fecha = row["Fecha"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Concepto = row["Concepto"].ToString(),
                    Cantidad = Convert.ToDouble(row["Cantidad"].ToString()),
                    Costo = Convert.ToDouble(row["Costo"].ToString())
                };
                list.Add(material);
            }
            return list;
        }

        //avacnes
        public List<Avances> MostarAT(string p)
        {
            var list = new List<Avances>();
            string consulta = string.Format("select * from vavances where FKProyecto = '{0}'", p);
            var ds = conexion.ObtenerDatos(consulta, "avacnces");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var avances = new Avances
                {
                    Ida = Convert.ToInt32(row["IDAvance"].ToString()),
                    Proyecto = row["proyecto"].ToString(),
                    Encargado = row["empleado"].ToString(),
                    FechaAvance = row["FechaAvance"].ToString(),
                    Avance = row["Avance"].ToString(),
                    Metros = Convert.ToDouble(row["Metros"].ToString()),
                    Pago = Convert.ToDouble(row["Pago"].ToString())
                };
                list.Add(avances);
            }
            return list;
        }
        public List<Avances> MostarAF(string p,string f1, string f2)
        {
            var list = new List<Avances>();
            string consulta = string.Format("select * from vavances where FKProyecto = '{0}' and FechaAvanceBETWEEN '{1}' and '{2}'", p, f1, f2);
            var ds = conexion.ObtenerDatos(consulta, "avacnces");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var avances = new Avances
                {
                    Ida = Convert.ToInt32(row["IDAvance"].ToString()),
                    Proyecto = row["proyecto"].ToString(),
                    Encargado = row["empleado"].ToString(),
                    FechaAvance = row["FechaAvance"].ToString(),
                    Avance = row["Avance"].ToString(),
                    Metros = Convert.ToDouble(row["Metros"].ToString()),
                    Pago = Convert.ToDouble(row["Pago"].ToString())
                };
                list.Add(avances);
            }
            return list;
        }
    }
}
