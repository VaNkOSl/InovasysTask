using InovasysTask.Models;

namespace InovasysTask.Repository;

public interface IUserRepository
{
    Task<IEnumerable<UserViewModel>> GetAllUsersFromDbAsync();

    Task SaveAllUsersAsync(IEnumerable<UserViewModel> users);
}
