using System.Collections.Generic;

namespace AccesoDatos
{
    public interface IAccionesBD
    {
        string Guardar(dynamic accion);
        string Modificar(dynamic accion);
        string Eliminar(dynamic accion);
    }
}
