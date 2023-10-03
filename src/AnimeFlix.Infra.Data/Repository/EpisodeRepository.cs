using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;
using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Repository
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly AnimeFlixContext Db;
        private readonly DbSet<EpisodeModel> DbSet;

        public EpisodeRepository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<EpisodeModel>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<EpisodeModel>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<EpisodeModel> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(EpisodeModel model)
        {
            DbSet.Add(model);
        }

        public void Update(EpisodeModel model)
        {
            DbSet.Update(model);
        }

        public void Remove(EpisodeModel model)
        {
            DbSet.Remove(model);
        }


        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
