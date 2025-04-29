using InovasysTask.Models;

namespace InovasysTask.Service;

public interface IUserService
{
    Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
}

