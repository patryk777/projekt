namespace ElectRightApplication.Data.UnitOfWork
{
    public interface IUnitOfWorkService<T>
    {
        Task BeginTransactionAsync();
        Task SaveChangesAsync();
        Task EndTransactionAsync();
        Task RollbackChangesAsync();
    }
}