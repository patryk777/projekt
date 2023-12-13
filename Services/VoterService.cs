using DTOs;

namespace ElectRight.Api.Services;

public class VoterService
{
    public async Task<Voter> CreateVoterAsync(Voter voter)
    {
        if (voter == null)
            throw new ArgumentNullException(nameof(voter));

        try
        {
            var registerVoterCommand = new RegisterVoterCommand<Voter>(voter);
            var registerVoter = await commandBus.SendAsync<Infrastructure.App.Candidate.Models.Candidate>(registerVoterCommand);
            if(registerVoter is null) throw new NullReferenceException();
                
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error creating voter: {voter?.Name}");
            throw;
        }
    }
    public async Task<Voter> GetVoterAsync(Voter voter)
    {
        if (voter == null)
            throw new ArgumentNullException(nameof(voter));

        try
        {
            var registerVoterCommand = new RegisterVoterCommand<Voter>(voter);
            var registerVoter = await commandBus.SendAsync<Infrastructure.App.Candidate.Models.Candidate>(registerVoterCommand);
            if(registerVoter is null) throw new NullReferenceException();
                
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error creating voter: {voter?.Name}");
            throw;
        }
    }
}