using InovasysTask.Models;
using InovasysTask.Repository;
using InovasysTask.Service;
using Microsoft.AspNetCore.Mvc;

namespace InovasysTask.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(
        IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index() =>
        View();

    [HttpGet]
    public async Task<IActionResult> LoadAllUsers() =>
        Json(await _userService.GetAllUsersAsync());

    [HttpPost]
    public async Task<IActionResult> SaveData([FromBody] IEnumerable<UserViewModel> users, [FromServices] IUserRepository userRepository)
    {
        await userRepository.SaveAllUsersAsync(users);
        return Ok();
    }
}
