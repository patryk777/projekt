namespace ElectRight.Mediator.Queries;

public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    Task<TResult> Handle(TQuery query);
}