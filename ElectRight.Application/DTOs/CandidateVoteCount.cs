using DTOs;

namespace ElectRightApplication.DTOs;

public class CandidateVoteCount
{
    public Candidate candidate { get; set; }
    public long VoteCount { get; set; }
}