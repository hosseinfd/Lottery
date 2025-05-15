using Application.BuildingBlocks.CQRS.Commands;

namespace Application.Features.User.Commands;

public class UserCommands
{
    public record CreateUserCommand(string TelegramId, string? Username, string? Name) : ICommand<Guid>;
    public record UpdateUserCommand(Guid UserId, string? Username, string? Name) : ICommand<bool>;

    public record DeleteUserCommand(Guid UserId) : ICommand<bool>;
}