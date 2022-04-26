using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoMedellin.Shared
{
    public class TransferenciaDto
    {
        [Required(ErrorMessage = "Es necesario una cuenta origen.")]
        public int CuentaCredito { get; set; }
        [Required(ErrorMessage = "Es necesario una cuenta destino.")]
        public int CuentaDebito { get; set; }
        [Required(ErrorMessage = "Es necesario un valor.")]
        public long Valor { get; set; }


    }
}
