using System.Text;
using System.Text.Json;
using Application.BuildingBlocks.CQRS.Commands;
using Domain;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.User;
using Domain.User;
using Infrastructure.Extension;

namespace Application.User.Commands;

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

        var user = new Domain.User.User
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