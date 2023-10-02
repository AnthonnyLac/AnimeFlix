using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.Character;

namespace AnimeFlix.Domain.Interfaces
{
    public interface ICharacterRepository  : IRepository<CharacterModel>
    {
        public Task<CharacterModel> GetCharacterByName(string name);
    }
}
