using System;
using System.Collections.Generic;
using System.Data;
using ConexionBD;
using Entidades;

namespace AccesoDatos
{
    public class AvancesAccesoDatos: IAccionesBD
    {
        Conexion conexion;
        Avances avances;
        public AvancesAccesoDatos()
        {
            conexion = new Conexion();
            avances = new Avances();
        }
        public string Eliminar(dynamic accion)
        {
            avances = accion;
            var consulta = string.Format("delete from avances WHERE IDAvance='{0}'", avances.Ida);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Guardar(dynamic accion)
        {
            avances = accion;
            var consulta = string.Format("insert into avances values(null,'{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", avances.Encargado, avances.Proyecto, avances.FechaAvance, avances.Avance, avances.Metros, avances.Pago);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Modificar(dynamic accion)
        {
            avances = accion;
            var consulta = string.Format("update avances SET FKEmpleado = '{0}' ,FKProyecto = '{1}' ,FechaAvance = '{2}', Avance = '{3}',Metros = '{4}',Pago = '{5}' WHERE IDAvance ='{6}'", avances.Encargado, avances.Proyecto, avances.FechaAvance, avances.Avance, avances.Metros, avances.Pago, avances.Ida);
            conexion.EjecutarConsulta(consulta);
            return "";
        }

        public List<Avances> Mostar(string filtro)
        {
            var list = new List<Avances>();
            string consulta = string.Format("select * from vavances where Avance like '%{0}%'", filtro);
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
