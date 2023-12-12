namespace ElectRightApplication.Interfaces
{
    // IVoterRepository.cs
    public interface IVoterRepository
    {
        Task<DTOs.Voter> GetByIdAsync(int id);
        Task<IEnumerable<DTOs.Voter>> GetAllAsync();
        Task AddAsync(DTOs.Voter voter);
        Task UpdateAsync(DTOs.Voter voter);
        Task DeleteAsync(int id);
    }
}