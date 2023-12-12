using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using ElectRight.Api.CQRS;
using ElectRight.Api.Interfaces;
using ElectRight.Api.Services;
using ElectRightApplication.CQRS.Commands.Create;
using ElectRightApplication.CQRS.Queries;
using Microsoft.Extensions.Logging;
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
                return await queryBus.SendAsync<Infrastructure.App.Candidate.Models.Candidate>(new RetrieveAllCandidatesQuery());
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
                var createCandidateCommand = new RegisterCandidateCommand<bool>(candidate.Name);
                candidate = await commandBus.SendAsync<Candidate>(createCandidateCommand);
                return candidate; 
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error creating candidate: {candidate.Name}");
                throw;
            }
        }

        public async Task<Candidate> CreateVoterAsync(Candidate candidate)
        {
            if (candidate == null)
                throw new ArgumentNullException(nameof(candidate));

            try
            {
                var registerVoterCommand = new RegisterVoterCommand<Voter>(candidate.Name);
                var registerVoter = await commandBus.SendAsync<Infrastructure.App.Candidate.Models.Candidate>(registerVoterCommand);
                if(registerVote is null) throw new NullReferenceException();
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error creating candidate: {candidate?.Name}");
                throw;
            }
        }

    }
}