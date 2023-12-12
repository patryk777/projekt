namespace ElectRight.Mediator.Queries;

public interface IQueryBus
{
    Task<TResult> Send<TResult>(IQuery<TResult> query);
}