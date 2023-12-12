namespace ElectRight.Mediator.Queries.Implementations;

using ElectRight.Mediator.Queries;
using Microsoft.Extensions.DependencyInjection;

internal sealed class InMemoryQueryBus : IQueryBus
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryQueryBus(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public Task<TResult> Send<TResult>(IQuery<TResult> query)
    {
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return ((Task<TResult>)handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.Handle))?
            .Invoke(handler, new object[] { query }))!;
    }
}