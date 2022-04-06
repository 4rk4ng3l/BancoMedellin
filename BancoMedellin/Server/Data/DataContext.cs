
namespace BancoMedellin.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Usuario>Usuarios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<Autorizada> Autorizadas { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>()
                .HasOne(p => p.Usuario)
                .WithMany(y => y.Cuentas);

            modelBuilder.Entity<Transferencia>()
                .HasOne(p => p.Debito)
                .WithMany(y => y.TransferenciasCredito)
                .HasForeignKey(p => p.CuentaCredito)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transferencia>()
                .HasOne(p => p.Credito)
                .WithMany(y => y.TransferenciasDebito)
                .HasForeignKey(p => p.CuentaDebito)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transferencia>()
                .HasOne(p => p.Usuario)
                .WithMany(y => y.Transferencias)
                .HasForeignKey(p => p.UsuarioDni)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Autorizada>()
                .HasOne(p => p.Usuario)
                .WithMany(y => y.Autorizadas)
                .HasForeignKey(p => p.UsuarioDni)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Autorizada>()
                .HasOne(p => p.Cuenta)
                .WithMany(y => y.Autorizadas)
                .HasForeignKey(p => p.CuentaId);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            modelBuilder.ApplyConfiguration(new CuentaConfiguracion());
            modelBuilder.ApplyConfiguration(new TransferenciaConfiguracion());
            modelBuilder.ApplyConfiguration(new AutorizadaConfiguracion());
        }
    }
}
