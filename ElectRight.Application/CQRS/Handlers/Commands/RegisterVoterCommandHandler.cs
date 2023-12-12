using ElectRight.Mediator.Commands;
using ElectRightApplication.CQRS.Commands.Create;

namespace ElectRightApplication.CQRS.Handlers.Commands
{
    public class RegisterVoterCommandHandler: ICommandHandler<RegisterVoterCommand>
    {
        public Task Handle(RegisterVoterCommand command)
        {
        }
    }
}