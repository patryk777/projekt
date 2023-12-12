using System.Runtime.Serialization.Formatters.Binary;

namespace ElectRight.Infrastructure.App.Candidate.Models
{
    public class Candidate
    {
        public Candidate()
        {
        }

        public int Id { get; set; }

        public required string Name { get; set; }

        public required int VoteCount { get; set; }
    }
}