using System.Collections.Generic;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class MaterialManejador
    {
        private static MaterialAccesoDatos materialAccesoDatos;
        public MaterialManejador()
        {
            materialAccesoDatos = new MaterialAccesoDatos(); ;
        }
        public void Guardar(Material material)
        {
            materialAccesoDatos.Guardar(material);
        }
        public void Eliminar(Material material)
        {
            materialAccesoDatos.Eliminar(material);
        }
        public void Modificar(Material material)
        {
            materialAccesoDatos.Modificar(material);
        }
        public List<Material> ObtenerProyectos(string filtro)
        {
            var list = new List<Material>();
            list = materialAccesoDatos.Mostar(filtro);
            return list;
        }
    }
}
