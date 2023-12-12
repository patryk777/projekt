namespace DTOs
{
    public class Voter
    {
        public required Guid VoterId { get; set; }
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required bool HasVoted { get; set; }
    }
}