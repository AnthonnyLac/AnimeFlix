using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.User;

namespace AnimeFlix.Domain.Interfaces
{
    public interface IAddressRepository : IRepository<AddressModel>
    {
        Task<AddressModel> GetAdressByUserId(int userId);
    }
}
