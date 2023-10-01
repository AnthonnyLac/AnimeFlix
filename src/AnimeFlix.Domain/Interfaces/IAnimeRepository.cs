﻿using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.Anime;

namespace AnimeFlix.Domain.Interfaces
{
    public interface IAnimeRepository : IRepository<AnimeModel>
    {
        Task<AnimeModel> GetById(int id);
        Task<AnimeModel> GetByName(string name);
        Task<IEnumerable<AnimeModel>> GetAll();

        void Add(AnimeModel anime);
        void Update(AnimeModel anime);
        void Remove(AnimeModel anime);
    }
}
