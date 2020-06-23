using System.Collections.Generic;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class AvancesManejador
    {
        private static AvancesAccesoDatos avancesAccesoDatos;
        public AvancesManejador()
        {
            avancesAccesoDatos = new AvancesAccesoDatos();
        }
        public void Guardar(Avances avances)
        {
            avancesAccesoDatos.Guardar(avances);
        }
        public void Eliminar(Avances avances)
        {
            avancesAccesoDatos.Eliminar(avances);
        }
        public void Modificar(Avances avances)
        {
            avancesAccesoDatos.Modificar(avances);
        }
        public List<Avances> ObtenerAvances(string filtro)
        {
            var list = new List<Avances>();
            list = avancesAccesoDatos.Mostar(filtro);
            return list;
        }
    }
}
