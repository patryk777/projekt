using DTOs;
using ElectRight.Mediator.Commands;
using ElectRightApplication.CQRS.Commands.Create;
using ElectRightApplication.Interfaces;

namespace ElectRightApplication.CQRS.Handlers.Commands
{
    public class RegisterCandidateCommandHandler(IRepository<Candidate> candidateRepository) : ICommandHandler<RegisterCandidateCommand>
    {
        public async Task Handle(RegisterCandidateCommand command, Candidate candidate)
        {
            var newCandidate = await candidateRepository.AddAsync(new Candidate()
            {
                CandidateId = candidate.
                Id = candidate.
            });
            return;
        }
    }
}