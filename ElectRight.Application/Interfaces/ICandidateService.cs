using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace ElectRight.Api.Interfaces;

public interface ICandidateService
{
    public Task<List<Candidate>> GetAllCandidatesAsync();

    public Task<Candidate> CreateCandidateAsync(Candidate candidate);
}