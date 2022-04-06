using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BancoMedellin.Shared
{
    public class Autorizada
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public ulong UsuarioDni { get; set; }
        [Required]
        public int CuentaId { get; set; }
       
        public Cuenta Cuenta { get; set; }
        public Usuario Usuario { get; set; }

    }
}
