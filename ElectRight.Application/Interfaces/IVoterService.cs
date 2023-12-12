
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace ElectRight.Api.Interfaces
{
    public interface IVoterService
    {
        Task<List<Voter>> GetAllVotersAsync();
        Task<Voter?> CreateVoterAsync(Voter voter);
    }
}