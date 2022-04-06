using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BancoMedellin.Shared
{
    public class Cuenta
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NombreCuenta { get; set; }
        [Required]
        public ulong UsuarioDni { get; set; }
        [Required]
        public ulong Balance { get; set; }
        

        [Timestamp]
        public byte[] Timestamp { get; set; }


        //Referencia Usuarios
        [ForeignKey("UsuarioDni")]
        public Usuario Usuario { get; set; }


        ////Referencias Transferencias
        //[InverseProperty("Credito")]
        public List<Transferencia> TransferenciasCredito { get; set; }

        //[InverseProperty("Debito")]
        public List<Transferencia> TransferenciasDebito { get; set; }

        public List<Autorizada> Autorizadas { get; set; }

    }
}
