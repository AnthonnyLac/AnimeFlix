using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.Address;

namespace AnimeFlix.Domain.Interfaces
{
    public interface IAddressRepository : IRepository<AddressModel>
    {
        Task<AddressModel> GetById(int id);
    }
}
