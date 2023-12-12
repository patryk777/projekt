using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ElectRight.UnitTests")]
namespace ElectRight.Mediator.Commands.Implementations;

using Microsoft.Extensions.DependencyInjection;

internal sealed class InMemoryCommandBus : ICommandBus
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryCommandBus(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public Task Send<TCommand>(TCommand? command) where TCommand : class, ICommand
    {
        if(command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        return handler.Handle(command);
    }

    public Task<TResult> Send<TResult>(ICommand<TResult> command)
    {
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return ((Task<TResult>)handlerType.GetMethod(nameof(ICommandHandler<ICommand<TResult>, TResult>.Handle))?
            .Invoke(handler, new object[] { command })!)!;
    }
}