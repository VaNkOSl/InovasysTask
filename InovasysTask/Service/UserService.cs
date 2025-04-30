using InovasysTask.Models;
using InovasysTask.Repository;
using System.Text.Json;

namespace InovasysTask.Service;

public class UserService : IUserService
{
    private readonly HttpClient _client;
    private readonly string _ApiKey;
    private readonly IUserRepository _userRepository;

    public UserService(
        HttpClient client,
        IConfiguration configuration,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _client = client;
        _ApiKey = configuration["ApiKey:PublicApiKey"] 
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
    {
        var usersFromDb = await _userRepository.GetAllUsersFromDbAsync();

        if(usersFromDb.Any())
        {
            return usersFromDb;
        }

        var response = await _client.GetAsync(_ApiKey);
        var json = await response.Content.ReadAsStringAsync();

        if(response.IsSuccessStatusCode)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<IEnumerable<UserViewModel>>(json, options) 
                ?? Enumerable.Empty<UserViewModel>();
        }
        else
        {
            throw new HttpRequestException("An unexpected error occurred while processing the data!" + response.StatusCode);
        }
    }
}
