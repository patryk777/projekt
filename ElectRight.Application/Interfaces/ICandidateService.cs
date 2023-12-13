using DTOs;

namespace ElectRightApplication.Interfaces;

public interface ICandidateService
{
    public Task<List<Candidate>> GetAllCandidatesAsync();

    public Task<Candidate> CreateCandidateAsync(Candidate candidate);
}