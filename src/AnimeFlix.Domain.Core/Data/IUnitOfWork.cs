namespace AnimeFlix.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        void BeginTransaction();
        void RollBack();
        object GetDbContext();

    }
}
