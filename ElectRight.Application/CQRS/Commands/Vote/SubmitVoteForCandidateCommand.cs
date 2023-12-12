using ElectRight.Mediator.Commands;

namespace ElectRightApplication.CQRS.Commands.Vote
{
    public class SubmitVoteForCandidateCommand : ICommand<bool>
    {
        public required Guid Id { get; init; } = Guid.NewGuid();
        
        public required int  VoterId { get; set; }
    
        public required int CandidateId { get; set; }
    }
}