using DTOs;

namespace ElectRightApplication.Interfaces
{
    public interface IVoterService
    {
        Task<List<Voter>> GetAllVotersAsync();
        Task<Voter?> CreateVoterAsync(Voter voter);
    }
}