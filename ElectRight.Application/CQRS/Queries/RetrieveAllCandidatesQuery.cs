using DTOs;
using ElectRight.Mediator.Queries;

namespace ElectRightApplication.CQRS.Queries
{
    public abstract class RetrieveAllCandidatesQuery : IQuery<List<Candidate>>
    {
    
    }
}