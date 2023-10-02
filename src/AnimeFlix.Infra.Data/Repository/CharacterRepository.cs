using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;
using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AnimeFlixContext Db;
        private readonly DbSet<CharacterModel> DbSet;

        public CharacterRepository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<CharacterModel>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<CharacterModel>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<CharacterModel> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<CharacterModel> GetCharacterByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Remove(CharacterModel model)
        {
            DbSet.Remove(model);
        }

        public void Update(CharacterModel model)
        {
            DbSet.Update(model);
        }
        public void Add(CharacterModel model)
        {
            DbSet.Add(model);
        }

        public void Dispose()
        {
            Db.Dispose();
        }


    }
}
