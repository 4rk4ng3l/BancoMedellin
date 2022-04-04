using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoMedellin.Shared
{
    public class Transferencia
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public ulong UsuarioDni { get; set; }
        [Required]
        public int CuentaCredito { get; set; }

        [Required]
        public int CuentaDebito { get; set; }

        [Required, ConcurrencyCheck]
        public ulong Valor { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Cuenta Credito { get; set; }
        public Cuenta Debito { get; set; }

        public Usuario Usuario { get; set; }



    }
}
