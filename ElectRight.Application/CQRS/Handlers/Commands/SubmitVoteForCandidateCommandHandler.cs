using DTOs;
using ElectRight.Mediator.Commands;
using ElectRightApplication.Data;
using ElectRightApplication.Data.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace ElectRightApplication.CQRS.Handlers.Commands
{
    public class SubmitVoteForCandidateCommandHandler : ICommand<bool>
    {
        public required Guid Id { get; init; } = Guid.NewGuid();
        
        public required int  VoterId { get; set; }
    
        public required int CandidateId { get; set; }
        
        public Task Handle(IUnitOfWorkService<Candidate> service, IRepository<Candidate> candidateRepository, IRepository<Vote> voteRepository, IRepository<Voter> voterRepository, Logger<SubmitVoteForCandidateCommandHandler> logger) {
            try
            {
                service.BeginTransactionAsync();

                var dbCandidate = candidateRepository.GetByIdAsync(CandidateId);
                dbVoter ?? throw new InvalidOperationException(@"{1} from DB doesn't exist with id={0}  of {1}",CandidateId, nameof(Voter));

                var dbVoter = voterRepository.GetByIdAsync(VoterId);
                dbVoter ?? throw new InvalidOperationException(@"{1} from DB doesn't exist with id={0}  of {1}",VoterId, nameof(Voter));

                service.EndTransactionAsync();
            }
            catch (Exception e)
            {
                logger.LogError(nameof(SubmitVoteForCandidateCommandHandler) + " throwns the exception", e);
            }

            service.SaveChangesAsync();
        }
    }
}