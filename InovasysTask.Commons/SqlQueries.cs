namespace InovasysTask.Commons;

public static class SqlQueries
{
    public const string DeleteAllUsersAndAddresses = @"
        DELETE FROM Addresses;
        DELETE FROM Users;";

    public const string GetUserCount = @"
        SELECT COUNT(*) FROM Users";

    public const string InsertUser = @"
        INSERT INTO Users (Name, [Not Username], Email, Phone, Website, Note, IsActive, CreatedAt)
        OUTPUT INSERTED.Id 
        VALUES(@Name, @NotUsername, @Email, @Phone, @Website, @Note, @IsActive, @CreatedAt);";

    public const string InsertAddress = @"
        INSERT INTO Addresses (Street, Suite, City, Zipcode, Lat, Lng, UserId)
        VALUES(@Street, @Suite, @City, @Zipcode, @Lat, @Lng, @UserId);";
}
