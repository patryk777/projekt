using DTOs;
using ElectRight.Mediator.Commands;

namespace ElectRightApplication.CQRS.Commands.Create
{
    public class RegisterCandidateCommand : ICommand<Candidate>
    {
        public required Guid Id { get; set; } = Guid.NewGuid();
        public required string name { get; set; }
        
        public required int VoteId { get; set; }
        public required int VoterId { get; set; }
    }
}