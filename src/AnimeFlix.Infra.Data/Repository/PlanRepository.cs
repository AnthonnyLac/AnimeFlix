using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Plan;
using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Repository
{
    public class PlanRepository : IPlanRepository
    {
        protected readonly AnimeFlixContext Db;
        protected readonly DbSet<SubscriptionPlanModel> DbSet;

        public PlanRepository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<SubscriptionPlanModel>();
        }

        public IUnitOfWork UnitOfWork => Db;


        public async Task<IEnumerable<SubscriptionPlanModel>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<SubscriptionPlanModel> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public void Add(SubscriptionPlanModel model)
        {
            DbSet.Add(model);
        }
        public void Update(SubscriptionPlanModel model)
        {
            DbSet.Update(model);
        }

        public void Remove(SubscriptionPlanModel model)
        {
            DbSet.Remove(model);
        }
        public async Task<SubscriptionPlanModel> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
