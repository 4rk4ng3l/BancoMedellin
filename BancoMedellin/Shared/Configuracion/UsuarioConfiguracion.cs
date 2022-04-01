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
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(
                 new Usuario
                 {
                     Dni = 771185581,
                     Nombre = "German Fonseca P",
                     Password = "1234"
                 },
                new Usuario
                {
                    Dni = 1001,
                    Nombre = "Daniela Fonseca",
                    Password = "1243"
                },
                 new Usuario
                 {
                     Dni = 1002,
                     Nombre = "Juan Sebastian Fonseca",
                     Password = "1244"
                 }
            );
        }
    }
}
