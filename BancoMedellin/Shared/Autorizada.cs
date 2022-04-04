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
        public ulong CuentaId { get; set; }
       

        ////Relaciones
        //public ulong Dni { get; set; }
        //public ICollection<Usuario> usuario { get; set; } 

        //public 
        //public ICollection<Cuenta> cuenta { get; set; }  

       

    }
}
