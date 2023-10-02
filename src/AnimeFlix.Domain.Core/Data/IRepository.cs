namespace AnimeFlix.Domain.Core.Data
{
    public interface IRepository<T> : IDisposable
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();

        void Add(T model);
        void Update(T model);
        void Remove(T model);
        IUnitOfWork UnitOfWork { get; }
    }
}
