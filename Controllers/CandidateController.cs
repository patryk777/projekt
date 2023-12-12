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
    public class CandidatesController(ICandidateService candidateService, ILogger<CandidatesController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Candidate>>> GetAll()
        {
            List<Candidate> allCandidatesAsync; 

            try
            {
                allCandidatesAsync = await candidateService.GetAllCandidatesAsync();
            }
            catch (Exception e)
            {
                logger.LogError("",e);
                throw;
            }
        
            return Ok(allCandidatesAsync);
        }

        [HttpPost]
        public async Task<ActionResult<Voter>> Create([FromBody] Candidate candidate)
        {
            var createdCandidate = await candidateService.CreateCandidateAsync(candidate);
       
            return CreatedAtAction(nameof(Create),
                new
                {
                    id = createdCandidate.Id
                }, candidate);
        }
    }
}