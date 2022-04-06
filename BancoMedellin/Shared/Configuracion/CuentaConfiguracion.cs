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
    public class CuentaConfiguracion : IEntityTypeConfiguration<Cuenta>
    {

        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasData(
                new Cuenta
                {
                    Id = 1,
                    NombreCuenta = "Vivienda",
                    UsuarioDni = 77185581,
                    Balance = 50000
                },
                 new Cuenta
                 {
                     Id = 2,
                     NombreCuenta = "Vehiculo",
                     UsuarioDni = 77185581,
                     Balance = 90000
                 },
                 new Cuenta
                 {
                     Id = 3,
                     NombreCuenta = "Universidad",
                     UsuarioDni = 1001,
                     Balance = 90000
                 },
                 new Cuenta
                 {
                     Id = 4,
                     NombreCuenta = "Excursion",
                     UsuarioDni = 1001,
                     Balance = 70000
                 },
                  new Cuenta
                  {
                      Id = 5,
                      NombreCuenta = "España",
                      UsuarioDni = 1002,
                      Balance = 170000
                  }
                );
        }
    }
}
