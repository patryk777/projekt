using DTOs;
using ElectRight.Mediator.Commands;
using ElectRightApplication.CQRS.Commands.Create;
using ElectRightApplication.Data;

namespace ElectRightApplication.CQRS.Handlers.Commands
{
    public class RegisterCandidateCommandHandler(IRepository<Candidate> candidateRepository ) : ICommandHandler<RegisterCandidateCommand>
    {
        public Task Handle(RegisterCandidateCommand command)
        {
        }
    }
}