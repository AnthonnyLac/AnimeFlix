using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AnimeFlixContext Db;
        private readonly DbSet<RatingModel> DbSet;

        public RatingRepository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<RatingModel>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<RatingModel>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
        public async Task<RatingModel> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(RatingModel model)
        {
            DbSet.Add(model);
        }

        public void Update(RatingModel model)
        {
            DbSet.Update(model);
        }

        public void Remove(RatingModel model)
        {
            DbSet.Remove(model);
        }


        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<RatingModel> GetByAnimeId(int animeId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.AnimeId == animeId);
        }
    }
}
