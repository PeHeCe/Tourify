using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UsuarioCronograma
    {
        public int id { get; set; }
        public string papel { get; set; } = string.Empty;
        public Usuario usuario { get; set; } = null!;
    }
}