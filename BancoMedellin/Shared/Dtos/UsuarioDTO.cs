using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoMedellin.Shared
{
    public class UsuarioDTO
    {
        public ulong Dni { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
