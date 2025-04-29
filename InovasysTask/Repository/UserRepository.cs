using Dapper;
using InovasysTask.Commons;
using InovasysTask.Models;
using Microsoft.Data.SqlClient;

namespace InovasysTask.Repository;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
       _connectionString = configuration["ConnectionStrings:DefaultConnection"] 
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task SaveAllUsersAsync(IEnumerable<UserViewModel> users)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        using var transaction = await connection.BeginTransactionAsync();

        try
        {
            var usersCount = await connection.ExecuteScalarAsync<int>(
                SqlQueries.GetUserCount, transaction: transaction);

            if(usersCount > 0)
            {
                await connection.ExecuteAsync(SqlQueries.DeleteAllUsersAndAddresses, transaction: transaction);
            }

            foreach (var user in users)
            {
                var parameters = MapUserToParameters(user);

                var userId = await connection.QuerySingleAsync<int>(SqlQueries.InsertUser, parameters, transaction);

                var addressParams = MapAddressToParameters(user, userId);

                await connection.ExecuteAsync(SqlQueries.InsertAddress, addressParams, transaction);
            }

            await transaction.CommitAsync();
        }
        catch(Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("An error occurred while saving the user data.", ex);
        }
    }

    private object MapAddressToParameters(UserViewModel user, int userId) => 
        new
        {
            Street = user.Address.Street,
            Suite = user.Address.Suite,
            City = user.Address.City,
            Zipcode = user.Address.Zipcode,
            Lat = user.Address.Geo.Lat,
            Lng = user.Address.Geo.Lng,
            UserId = userId
        };

    private DynamicParameters MapUserToParameters(UserViewModel user)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Name", user.Name);
        parameters.Add("@NotUsername", user.Username);
        parameters.Add("@Email", user.Email);
        parameters.Add("@Phone", user.Phone);
        parameters.Add("@Website", user.Website);
        parameters.Add("@Note", user.Note);
        parameters.Add("@IsActive", user.IsActive);
        parameters.Add("@CreatedAt", user.CreatedAt);
        return parameters;
    }
}
