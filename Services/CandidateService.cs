using DTOs;
using ElectRight.Api.CQRS;
using ElectRightApplication.CQRS.Commands.Create;
using ElectRightApplication.CQRS.Queries;
using ICandidateService = ElectRight.Infrastructure.App.Candidate.Services.ICandidateService;

namespace ElectRight.Api.Services
{
    class CandidateService(ICommandBus commandBus, IQueryBus queryBus, ILogger<CandidateService> logger)
        : ICandidateService
    {
        public async Task<List<Candidate>> GetAllCandidatesAsync()
        { 
            try
            {
                return await queryBus.SendAsync<void>(
                    new RetrieveAllCandidatesQuery<List<Candidate>());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving all candidates");
                throw;
            }
        }

        public async Task<Candidate> CreateCandidateAsync(Candidate candidate)
        {
            if (candidate == null)
                throw new ArgumentNullException(nameof(candidate));

            try
            {
                var createCandidateCommand = new RegisterCandidateCommand<Candidate>(candidate);
                candidate = await commandBus.SendAsync<Candidate>(createCandidateCommand);
                return candidate; 
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error creating candidate: {candidate.Name}");
                throw;
            }
        }
    }
}