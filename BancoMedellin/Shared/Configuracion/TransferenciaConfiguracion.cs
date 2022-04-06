using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoMedellin.Shared
{
    public class TransferenciaConfiguracion : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.HasData(
                    new Transferencia
                    {
                        Id = 1,
                        CuentaDebito = 1,
                        CuentaCredito = 2,
                        UsuarioDni = 77185581,
                        Valor = 30000
                    }
                );
        }
    }
}
