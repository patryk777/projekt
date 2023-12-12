using DTOs;
using ElectRight.Mediator.Commands;

namespace ElectRightApplication.CQRS.Commands.Create
{
    public class RegisterVoterCommand: ICommand<Voter>
    {
        public required Guid Id { get; set; } = Guid.NewGuid();
        public required int VoterId { get; set; }
    }
}