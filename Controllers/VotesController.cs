
using System;
using System.Threading.Tasks;
using ElectRight.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElectRight.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController(IVoteService voteService, ILogger<VotesController> logger) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Cast(int voterId, int candidateId)
        {
            try
            {
                await voteService.CastVoteAsync(voterId, candidateId);
            }
            catch (Exception e)
            {
                logger.LogError("",e);
                throw;
            }
        
            return NoContent();
        }
    }
}