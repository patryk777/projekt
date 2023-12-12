namespace ElectRightApplication.Interfaces
{
    // ICandidateRepository.cs
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T candidate);
        Task<T> UpdateAsync(T candidate);
        Task DeleteAsync(int id);
    }
}