using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoMedellin.Shared
{
    public class Usuario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public ulong Dni { get; set; }
        [Required, MaxLength(64)]
        public string Nombre { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }


        //Relaciones
        public List<Cuenta> Cuentas { get; set; }
        public List<Transferencia> Transferencias { get; set; }
        public List<Autorizada> Autorizadas { get; set; }
    }
}
