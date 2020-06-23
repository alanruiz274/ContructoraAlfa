using System;
using System.Collections.Generic;
using System.Data;
using ConexionBD;
using Entidades;


namespace AccesoDatos
{
    public class MaterialAccesoDatos: IAccionesBD
    {
        Conexion conexion;
        Material material;
        public MaterialAccesoDatos()
        {
            conexion = new Conexion();
            material = new Material();
        }

        public string Eliminar(dynamic accion)
        {
            material = accion;
            var consulta = string.Format("delete from material WHERE IDMaterial='{0}'", material.Idm);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Guardar(dynamic accion)
        {
            material = accion;
            var consulta = string.Format("insert into material values(null,'{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", material.Proyecto, material.Fecha, material.Nombre, material.Concepto, material.Cantidad, material.Costo);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Modificar(dynamic accion)
        {
            material = accion;
            var consulta = string.Format("update material set FKProyecto = '{0}', Fecha = '{1}', Nombre = '{2}', Concepto = '{3}', Cantidad = '{4}', Costo = '{5}' WHERE IDMaterial='{6}'", material.Proyecto, material.Fecha, material.Nombre, material.Concepto, material.Cantidad, material.Costo, material.Idm);
            conexion.EjecutarConsulta(consulta);
            return "";
        }

        public List<Material> Mostar(string filtro)//string filtro)
        {
            var list = new List<Material>();
            string consulta = string.Format("Select IDMaterial, proyecto, Fecha, Nombre, Concepto, Cantidad, Costo,FKProyecto from vmaterial where Nombre like '%{0}%' order by IDMaterial desc", filtro);
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
    }
}
