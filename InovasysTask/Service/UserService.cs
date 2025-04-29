using InovasysTask.Models;
using System.Text.Json;

namespace InovasysTask.Service;

public class UserService : IUserService
{
    private readonly HttpClient _client;
    private readonly string _ApiKey;

    public UserService(
        HttpClient client,
        IConfiguration configuration)
    {
        _client = client;
        _ApiKey = configuration["ApiKey:PublicApiKey"] 
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
    {
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
