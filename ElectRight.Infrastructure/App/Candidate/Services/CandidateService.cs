using ElectRight.Mediator.Commands;
using ElectRightApplication.CQRS.Commands.Create;
using Microsoft.Extensions.Logging;

namespace ElectRight.Infrastructure.App.Candidate.Services
{
    public class CandidateService(ICommandBus commandBus, ILogger<CandidateService> logger) : ICandidateService
    {
        public async Task<DTOs.Candidate> CreateCandidateAsync(DTOs.Candidate candidate)
        {
            ArgumentNullException.ThrowIfNull(candidate);

            try
            {
                var createCandidateCommand = new RegisterCandidateCommand(candidate)
                {
                    Id = candidate.Id,
                    name = candidate.Name,
                    VoteId = 0,
                    VoterId = 0
                };
                var result = await commandBus.Send<RegisterCandidateCommand, DTOs.Candidate>(createCandidateCommand);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating a candidate.");
                throw;
            }
        }
    }
}
