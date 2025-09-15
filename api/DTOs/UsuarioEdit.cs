using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class UsuarioEdit
    {
        public string? email { get; set; }
        public string? nome { get; set; }
        public string? sobrenome { get; set; }
        public string? senha { get; set; }
        public string? telefone { get; set; }
        public string? cep { get; set; }
        
    }
}