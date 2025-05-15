using Application.BuildingBlocks.CQRS.Commands;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.User;

namespace Application.Features.User.Commands;

public class DeleteUserCommandHandler : ICommandHandler<UserCommands.DeleteUserCommand, bool>
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserWriteRepository userWriteRepository, IUnitOfWork unitOfWork)
    {
        _userWriteRepository = userWriteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UserCommands.DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null) return false;

        _userWriteRepository.Delete(user);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}