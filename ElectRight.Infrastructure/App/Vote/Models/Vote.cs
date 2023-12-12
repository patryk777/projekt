namespace ElectRight.Infrastructure.App.Vote.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public required int CandidateId { get; set; }
        public virtual App.Candidate.Models.Candidate Candidate { get; set; }

        public required int VoterId { get; set; }
        public virtual Voter.Models.Voter Voter { get; set; }
    }
}