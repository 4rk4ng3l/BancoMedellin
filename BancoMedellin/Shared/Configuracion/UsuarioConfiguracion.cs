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
                CreateUsuario(77185581, "German Fonseca P", "1111"),
                CreateUsuario(11111, "Daniela Fonseca", "2222"),
                CreateUsuario(22222, "Juan Sebastian Fonseca", "3333")
            );
        }

        private static Usuario CreateUsuario(int Dni, string Nombre, string Password)
        {
            Utilidades utilidades = new Utilidades();
            byte[] passwordHash;
            byte[] passwordSalt;
            utilidades.createPasswordHash(Password,out passwordHash, out passwordSalt);
            Usuario usuario = new Usuario();
            usuario.Dni = Dni;
            usuario.Nombre = Nombre;
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;
            return usuario;
        }
    }
}
