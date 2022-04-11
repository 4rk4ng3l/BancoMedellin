using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoMedellin.Shared
{
    public class AutorizadaConfiguracion : IEntityTypeConfiguration<Autorizada>
    {
        public void Configure(EntityTypeBuilder<Autorizada> builder)
        {
            builder.HasData(
                     new Autorizada
                     {
                         Id = 1,
                         UsuarioDni = 77185581,
                         CuentaId = 3
                     },
                     new Autorizada
                     {
                         Id = 2,
                         UsuarioDni = 77185581,
                         CuentaId = 4
                     },
                     new Autorizada
                     {
                         Id = 3,
                         UsuarioDni = 11111,
                         CuentaId = 1
                     },
                     new Autorizada
                     {
                         Id = 4,
                         UsuarioDni = 11111,
                         CuentaId = 2
                     }
                );
        }
    }
}
