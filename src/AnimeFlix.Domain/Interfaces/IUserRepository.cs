using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.User;

namespace AnimeFlix.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task<UserModel> GetById(int id);
        Task<UserModel> GetByName(string name);
        

    }
}
