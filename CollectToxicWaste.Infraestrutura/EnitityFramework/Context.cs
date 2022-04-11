using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.Configurações;
using Microsoft.EntityFrameworkCore;

namespace CollectToxicWaste.Infraestrutura.EnitityFramework
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Coleta> Coletas { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<Motorista> Motoristas {get; set; }

        protected override void OnConfiguring
           (DbContextOptionsBuilder OptionsBuidler)
        {
            OptionsBuidler.UseSqlServer("server=201.62.57.93;database=BD037083;user id=RA037083;password=037083;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Coleta>();
            modelBuilder.Entity<Motorista>();
            modelBuilder.Entity<Transporte>();
            modelBuilder.Entity<Rota>();

            modelBuilder.ApplyConfiguration(new ColetaConfiguracao());
            modelBuilder.ApplyConfiguration(new MotoristaConfiguracao());
            modelBuilder.ApplyConfiguration(new TransporteConfiguracao());
            modelBuilder.ApplyConfiguration(new RotaConfiguracao());

        }

    }
}
