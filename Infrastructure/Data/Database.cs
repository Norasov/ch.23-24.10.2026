using Npgsql;

namespace Infrastructure.Data;

public static class Database
{
    public static string connectionString = "Host=localhost;Port=5432;Database=MiniShopDB;Username=postgres;Password=p000";
    public static NpgsqlConnection Connection() => new NpgsqlConnection(connectionString);
}
