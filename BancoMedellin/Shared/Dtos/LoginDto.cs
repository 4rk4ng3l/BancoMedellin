using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoMedellin.Shared
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Debe ingresar la identificación.")]
        [Range (1,999999999, ErrorMessage = "Error en la identicacion!.")  ]
        public int Dni { get; set; }
        //[Required]
        [StringLength(64, ErrorMessage = "Identificacion demasiado larga")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage ="Debe ingresar la contraseña")]
        [RegularExpression(@"^\d{4}", ErrorMessage ="La contraseña debe ser de 4 digitos")]
        public string Password { get; set; }
    }
}
