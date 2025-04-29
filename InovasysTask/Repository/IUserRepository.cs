using InovasysTask.Models;

namespace InovasysTask.Repository;

public interface IUserRepository
{
    Task SaveAllUsersAsync(IEnumerable<UserViewModel> users);
}
