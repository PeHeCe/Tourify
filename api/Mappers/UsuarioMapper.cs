using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Classes;

namespace api.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario UsuarioToClasses(Models.Usuario usuario_model)
        {
            return new Usuario
            {
                usuario = usuario_model
            };
        }
    }
}