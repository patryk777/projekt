using ElectRight.Mediator.Queries;
using ElectRightApplication.DTOs;

namespace ElectRightApplication.CQRS.Queries;

public class RetrieveCandidateVoteCountQuery: IQuery<List<CandidateVoteCount>>{
    public Guid CandidateId { get; set; }
}