namespace ElectRight.Infrastructure.App.Voter.Models
{
    public class Voter
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required bool HasVoted { get; set; }
    }
}