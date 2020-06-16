using System.Collections.Generic;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class ProyectoManejador
    {
        private static ProyectosAccesoDatos proyectosAccesoDatos;
        public ProyectoManejador()
        {
            proyectosAccesoDatos = new ProyectosAccesoDatos();
        }
        public void Guardar(Proyectos proyectos)
        {
            proyectosAccesoDatos.Guardar(proyectos);
        }
        public void Eliminar(Proyectos proyectos)
        {
            proyectosAccesoDatos.Eliminar(proyectos);
        }
        public void Modificar(Proyectos proyectos)
        {
            proyectosAccesoDatos.Modificar(proyectos);
        }
        public List<Proyectos> ObtenerProyectos(string filtro)
        {
            var list = new List<Proyectos>();
            list = proyectosAccesoDatos.Mostar(filtro);
            return list;
        }
        public List<Proyectos> ObtenerProyectosCombo(string filtro)
        {
            var list = new List<Proyectos>();
            list = proyectosAccesoDatos.MostarCombo(filtro);
            return list;
        }
    }
}
