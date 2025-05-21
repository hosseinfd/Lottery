using Application.BuildingBlocks.CQRS.Commands;
using Domain.Common;
using Domain.Exceptions;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.User;

namespace Application.Features.User.Commands;

public class CreateUserCommandHandler : ICommandHandler<UserCommands.CreateUserCommand, Guid>
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserWriteRepository userWriteRepository, IUnitOfWork unitOfWork)
    {
        _userWriteRepository = userWriteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UserCommands.CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userWriteRepository.UsernameExistsAsync(request.Username))
            throw new UserAlreadyExistException(
                new ValidationItem(null, 
                    "Username already exists",
                    null)
            );

        var user = new Domain.Entities.User.UserDao
        {
            UserId = Guid.NewGuid(),
            TelegramId = request.TelegramId,
            Username = request.Username,
            Name = request.Name,
            CreatedAt = DateTime.UtcNow
        };

        await _userWriteRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return user.UserId;
    }
}