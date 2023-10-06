using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.User;
using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly AnimeFlixContext Db;
        protected readonly DbSet<UserModel> DbSet;

        public UserRepository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<UserModel>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await DbSet.Include(u => u.Address).ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await DbSet.Where(u => u.Id == id).Include(u => u.Address).FirstOrDefaultAsync();

        }

        public async Task<UserModel> GetByName(string name)
        {
            return await DbSet.AsNoTracking().Include(u => u.Address).FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Add(UserModel model)
        {
            DbSet.Add(model);
        }

        public void Remove(UserModel model)
        {
            DbSet.Remove(model);
        }

        public void Update(UserModel model)
        {
            DbSet.Update(model);
        }

        public void Dispose()
        {
            Db.Dispose();
        }


    }
}
