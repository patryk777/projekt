using ElectRight.Infrastructure.Data;
using ElectRightApplication.App.Vote.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElectRight.Infrastructure.App.Vote.Repositories
{
    public class VoteRepository(UnitOfWorkService context) : IVoteRepository
    {
        public async Task<ClassLibrary1.dtos.Vote?> GetByIdAsync(int id)
        {
            return await context.Votes.FindAsync(id);
        }

        Task<ClassLibrary1.dtos.Vote?> IVoteRepository.GetByIdAsync(int id)
        {
            return GetByIdAsync(id);
        }

        public async Task<IEnumerable<ClassLibrary1.dtos.Vote?>> GetAllAsync()
        {
            return await context.Votes.ToListAsync();
        }

        public async Task AddAsync(ClassLibrary1.dtos.Vote? vote)
        {
            context.Votes.Add(vote);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClassLibrary1.dtos.Vote? vote)
        {
            context.Votes.Update(vote);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vote = await GetByIdAsync(id);
            if (vote != null)
            {
                context.Votes.Remove(vote);
                await context.SaveChangesAsync();
            }
        }
    }
}