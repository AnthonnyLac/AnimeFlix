using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.User;
using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        protected readonly AnimeFlixContext Db;
        protected readonly DbSet<UserSubscriptionModel> DbSet;

        public SubscriptionRepository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<UserSubscriptionModel>();
        }

        public IUnitOfWork UnitOfWork => Db;


        public async Task<IEnumerable<UserSubscriptionModel>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<UserSubscriptionModel> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<UserSubscriptionModel> GetSubscriptionByUserId(int userId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == userId);
        }
        public void Add(UserSubscriptionModel model)
        {
            DbSet.Add(model);
        }



        public void Update(UserSubscriptionModel model)
        {
            DbSet.Update(model);
        }
        public void Remove(UserSubscriptionModel model)
        {
            DbSet.Remove(model);
        }
        public void Dispose()
        {
            Db.Dispose();
        }


    }
}
