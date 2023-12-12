using ElectRight.Mediator.Commands;

namespace ElectRight.Api.CQRS;

internal interface ICommandBus
{
    Task<T> SendAsync<T>(ICommand command);
}