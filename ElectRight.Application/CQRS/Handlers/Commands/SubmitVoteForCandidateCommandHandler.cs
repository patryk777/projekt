using DTOs;
using ElectRight.Mediator.Commands;
using ElectRightApplication.Data;
using ElectRightApplication.Data.UnitOfWork;
using ElectRightApplication.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace ElectRightApplication.CQRS.Handlers.Commands
{
    public class SubmitVoteForCandidateCommandHandler : ICommand<bool>
    {
        public required Guid Id { get; init; } = Guid.NewGuid();
        
        public required int  VoterId { get; set; }
    
        public required int CandidateId { get; set; }
        
        public async Task<bool> Handle(IUnitOfWorkService<Candidate> service, IRepository<Candidate> candidateRepository, IRepository<Vote> voteRepository, IRepository<Voter> voterRepository, ILogger<SubmitVoteForCandidateCommandHandler> logger) {
            try
            {
                await service.BeginTransactionAsync();

                var dbCandidate = await candidateRepository.GetByIdAsync(CandidateId);
                if(dbCandidate == null) throw new InvalidOperationException(string.Format("{1} from DB doesn't exist with id={0}  of {1}",CandidateId, nameof(Voter)));

                var dbVoter = await voterRepository.GetByIdAsync(VoterId);
                if(dbVoter == null) throw new InvalidOperationException(string.Format(@"{1} from DB doesn't exist with id={0}  of {1}",VoterId, nameof(Voter)));

                await service.EndTransactionAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e, nameof(SubmitVoteForCandidateCommandHandler) + " throws the exception");
                throw;
            }

            await service.SaveChangesAsync();
            return true;
        }
    }
}