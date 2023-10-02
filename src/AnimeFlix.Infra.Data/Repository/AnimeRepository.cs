using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        protected readonly AnimeFlixContext Db;
        protected readonly DbSet<AnimeModel> DbSet;

        public AnimeRepository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<AnimeModel>();
        }

        public IUnitOfWork UnitOfWork => Db;


        public async Task<IEnumerable<AnimeModel>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<AnimeModel> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<AnimeModel> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Title == name);
        }

        public void Add(AnimeModel model)
        {
            DbSet.Add(model);
        }

        public void Remove(AnimeModel model)
        {
            DbSet.Remove(model);
        }

        public void Update(AnimeModel model)
        {
            DbSet.Update(model);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
