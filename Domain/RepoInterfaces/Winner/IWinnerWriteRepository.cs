using Domain.Entities.Winner;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Winner;

public interface IWinnerWriteRepository : IWriteRepository<WinnerDao>
{
}