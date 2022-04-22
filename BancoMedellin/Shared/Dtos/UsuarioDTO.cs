using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoMedellin.Shared
{
    public class UsuarioDTO
    {
        [Required]
        public string Dni { get; set; }
        //[Required]
        [StringLength(64, ErrorMessage = "Identificacion demasiado larga")]
        public string Nombre { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
