using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AnimeFlix.Infra.Data.Context
{
    public sealed class AnimeFlixContext : DbContext, IUnitOfWork
    {

        public AnimeFlixContext(DbContextOptions<AnimeFlixContext> options) : base(options)
        {
            // Define o comportamento de rastreamento de consulta como NoTracking.
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            // Desativa a detecção automática de alterações.
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<AnimeModel> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //Aplicando o mapeamento
            modelBuilder.ApplyConfiguration(new AnimeMap());

            base.OnModelCreating(modelBuilder);
        }


        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}
