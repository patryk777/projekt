namespace DTOs
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public int VoteCount { get; set; }
    }
}