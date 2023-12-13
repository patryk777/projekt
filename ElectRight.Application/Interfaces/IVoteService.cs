namespace ElectRightApplication.Interfaces
{
    public interface IVoteService
    {
        Task CastVoteAsync(int voterId, int candidateId);
    }

    class VoteService : IVoteService
    {
        public Task CastVoteAsync(int voterId, int candidateId)
        {
            throw new NotImplementedException();
        }
    }
}