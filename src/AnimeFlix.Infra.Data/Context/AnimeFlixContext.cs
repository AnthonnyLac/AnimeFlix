using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;
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
        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<EpisodeModel> Episodes { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //Aplicando o mapeamento
            modelBuilder.ApplyConfiguration(new AnimeMap());
            modelBuilder.ApplyConfiguration(new CharacterMap());
            modelBuilder.ApplyConfiguration(new EpisodeMap());
            modelBuilder.ApplyConfiguration(new RatingMap());

            base.OnModelCreating(modelBuilder);
        }


        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}
