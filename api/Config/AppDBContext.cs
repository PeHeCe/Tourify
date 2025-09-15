using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Config
{
    public class AppDBContext : DbContext
    {
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Cronograma> Cronogramas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Excursao> Excursoes { get; set; }
        public DbSet<FavoritoCronograma> FavoritosCronogramas { get; set; }
        public DbSet<FavoritoEstabelecimento> FavoritosEstabelecimentos { get; set; }
        public DbSet<FavoritoExcursao> FavoritosExcursoes { get; set; }
        public DbSet<TipoEstabelecimento> TiposEstabelecimentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioCronograma> UsuariosCronogramas { get; set; }
        public DbSet<EstabelecimentoCronograma> EstabelecimentoCronogramas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db; Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estabelecimento>()
                .HasOne(e => e.tipo_estabelecimento)
                .WithMany()
                .HasForeignKey(e => e.tipo_estabelecimento_id)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}