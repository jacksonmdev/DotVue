namespace FunctionalTests.Common;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new SqlServerTestcontainersTestDatabase();
        await database.InitialiseAsync();
        return database;
    }
}
