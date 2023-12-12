using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using ElectRight.Api.Interfaces;
using ElectRight.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElectRight.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotersController(IVoterService voterService, ILogger<VotersController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Voter>>> GetAll()
        {
            List<Voter> allVoters;
            try
            {
                allVoters = await voterService.GetAllVotersAsync();
            }
            catch (Exception e)
            {
                logger.LogError("",e);
                throw;
            }
            return Ok(allVoters);
        }

        [HttpPost]
        public async Task<ActionResult<Voter>> Create(Voter voter)
        {
            Voter? createdVote;
            try
            {
                createdVote = await voterService.CreateVoterAsync(voter);
            }
            catch (Exception e)
            {
                logger.LogError("",e);
                throw;
            }
        
            return CreatedAtAction(nameof(Create),
                new
                {
                    id = createdVote.Id
                }, voter);
        }
    }
}