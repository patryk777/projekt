namespace DTOs
{
    public class Vote
    {
        public required Guid Id { get; set; }
        
        public int VoteId { get; set; }
        public int VoterId { get; set; }
        public Candidate Candidate { get; set; }
        public Voter Voter { get; set; }
    }
}