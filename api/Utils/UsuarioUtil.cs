using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace api.Utils
{
    public static class UsuarioUtil
    {
        public static bool EmailValido(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            bool isValid = Regex.IsMatch(email, emailPattern);

            return isValid;
        }

        public static bool SenhaValida(string senha)
        {
            string senhaPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            bool isValid = Regex.IsMatch(senha, senhaPattern);

            return isValid;
        }
    }
}