using System.Text.RegularExpressions;

namespace Presentacion
{
    public class Validaciones
    {
        public bool Letras(string Campo)
        {
            if (Campo.Length > 0)
            {
                var regex = new Regex(@"^[a-zA-Z0-9\s,]+( [A-Za-z]+)*$");
                var match = regex.Match(Campo);

                if (match.Success)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public bool Numero(string Campo)
        {
            if (Campo.Length > 0)
            {
                var regex = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
                var match = regex.Match(Campo);
                if (match.Success)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public bool Vacio(string  Campo) 
        {
            if (Campo.Length == 0)
                return false;
            return true;
        }
    }
}
