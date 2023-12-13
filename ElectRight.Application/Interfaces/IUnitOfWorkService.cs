namespace ElectRightApplication.Interfaces
{
    public interface IUnitOfWorkService
    {
        Task BeginTransactionAsync();
        Task SaveChangesAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}