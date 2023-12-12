using ElectRight.Mediator.Queries;

namespace ElectRightApplication.CQRS.Queries;

public class CheckVoterParticipationQuery :  IQuery<bool>
{
    public Guid CandidateId { get; set; }
    private bool HasParticipated { get; set; }
}