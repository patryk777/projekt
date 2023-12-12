using ElectRight.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ElectRight.Infrastructure.App.Voter.Repositories
{
    public class VoterRepository(UnitOfWorkService context) : IVoterRepository
    {
        public async Task<DTOs.Voter?> GetByIdAsync(int id)
    {
        return await context.Voters.FindAsync(id);
    }

        public async Task<IEnumerable<DTOs.Voter>> GetAllAsync()
    {
        return await context.Voters.ToListAsync();
    }

        public async Task AddAsync(DTOs.Voter voter)
    {
        context.Voters.Add(voter);
        await context.SaveChangesAsync();
    }

        public async Task UpdateAsync(DTOs.Voter voter)
    {
        context.Voters.Update(voter);
        await context.SaveChangesAsync();
    }

        public async Task DeleteAsync(int id)
    {
        var voter = await GetByIdAsync(id);
        if (voter != null)
        {
            context.Voters.Remove(voter);
            await context.SaveChangesAsync();
        }
    }
    }
}