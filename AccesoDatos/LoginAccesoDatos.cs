using System.Collections.Generic;
using System.Data;
using ConexionBD;
using Entidades;

namespace AccesoDatos
{
    public class LoginAccesoDatos
    {
        Conexion _conexion;
        public LoginAccesoDatos()
        {
            _conexion = new Conexion();
        }
        public List<Login> ObtenerUsuario(string user,string password)
        {
            var list = new List<Login>();
            string consulta = string.Format("select * from usuarios where user = '{0}' and password = '{1}'", user,password);
            var ds = _conexion.Buscar(consulta, "usuario");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var usuario = new Login
                {
                    Id = row["id"].ToString(),
                    User = row["user"].ToString(),
                    Password = row["password"].ToString(),
                    Nivel = row["nivel"].ToString()
                };
                list.Add(usuario);
            }
            return list;
        }
        public bool UsuarioBoll(string user, string password)
        {

            return true;
        }
    }
}
