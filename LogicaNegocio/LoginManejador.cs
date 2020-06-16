using System.Collections.Generic;
using System.Text.RegularExpressions;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LoginManejador
    {
        private LoginAccesoDatos _loginAccesoDatos;
        //private LoginEntidades _loginEntidades;

        public LoginManejador()
        {
            _loginAccesoDatos = new LoginAccesoDatos();
        }
        public List<Login> ObtenerLista(string user, string password)
        {
            var list = new List<Login>();
            list = _loginAccesoDatos.ObtenerUsuario(user, password);
            return list;
        }
        public bool UsuarioValido(string user)
        {
            var regex = new Regex(@"^[A-Za-z]+( [A-Za-z]+)*$");
            var match = regex.Match(user);

            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
