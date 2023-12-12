namespace ElectRight.Mediator.Commands;
public interface ICommandBus
{
    Task Send<TCommand>(TCommand command) where TCommand : class, ICommand;

    Task<TResult> Send<TResult>(ICommand<TResult> command);
}