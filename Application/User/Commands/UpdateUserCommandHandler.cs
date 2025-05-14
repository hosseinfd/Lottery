using Application.BuildingBlocks.CQRS.Commands;
using Domain.Interfaces;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.User;

namespace Application.User.Commands;

public class UpdateUserCommandHandler : ICommandHandler<UserCommands.UpdateUserCommand, bool>
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserWriteRepository userWriteRepository, IUnitOfWork unitOfWork)
    {
        _userWriteRepository = userWriteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UserCommands.UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null) return false;

        user.Username = request.Username;
        user.Name = request.Name;

        _userWriteRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}