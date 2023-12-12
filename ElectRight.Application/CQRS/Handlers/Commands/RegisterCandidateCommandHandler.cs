using DTOs;
using ElectRight.Mediator.Commands;
using ElectRightApplication.CQRS.Commands.Create;
using ElectRightApplication.Data;
using ElectRightApplication.Interfaces;
using Microsoft.Extensions.Azure;

namespace ElectRightApplication.CQRS.Handlers.Commands
{
    public class RegisterCandidateCommandHandler(IRepository<Candidate> candidateRepository , IRepository<Vote> voteRepository<Vote>, IVoterRepository voterRepository) : ICommandHandler<RegisterCandidateCommand>
    {
        public async Task Handle(RegisterCandidateCommand command,Candidate candidateRepository)
        {
            var vote = await voterRepository.AddEventGridPublisherClient();
            var newCandidate = await candidateRepository.AddAsync(new Candidate()
            {
                                        CandidateId = 
                
                
            });
            return Task.CompletedTask;
        }
    }
}