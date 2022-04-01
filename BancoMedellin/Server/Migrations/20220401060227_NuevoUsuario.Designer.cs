﻿// <auto-generated />
using BancoMedellin.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoMedellin.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220401060227_NuevoUsuario")]
    partial class NuevoUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BancoMedellin.Shared.Usuario", b =>
                {
                    b.Property<decimal>("Dni")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Dni");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Dni = 771185581m,
                            Nombre = "German Fonseca P",
                            Password = "1234"
                        },
                        new
                        {
                            Dni = 1001m,
                            Nombre = "Daniela Fonseca",
                            Password = "1243"
                        },
                        new
                        {
                            Dni = 1002m,
                            Nombre = "Juan Sebastian Fonseca",
                            Password = "1244"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
