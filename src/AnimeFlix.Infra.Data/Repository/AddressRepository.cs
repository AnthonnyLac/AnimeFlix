using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.User;
using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        protected readonly AnimeFlixContext Db;
        protected readonly DbSet<AddressModel> DbSet;


        public AddressRepository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<AddressModel>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<AddressModel>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<AddressModel> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(AddressModel model)
        {
            DbSet.Add(model);
        }


        public void Update(AddressModel model)
        {
            DbSet.Update(model);
        }

        public void Remove(AddressModel model)
        {
            DbSet.Remove(model);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task SaveChanges()
        {
            await Db.SaveChangesAsync();
        }
    }
}
