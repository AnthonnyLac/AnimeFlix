namespace AnimeFlix.Domain.Core.Data
{
    public interface IRepository<T> : IDisposable
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();

        void Add(T anime);
        void Update(T anime);
        void Remove(T anime);
        IUnitOfWork UnitOfWork { get; }
    }
}
