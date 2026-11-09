using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class AppDbContext
{
    public string connectionString = "Host=localhost;Port=5432;Database=MiniShopDB;Username=postgres;Password=p000;Include Error Detail=true";
    public IDbConnection Connection() => new NpgsqlConnection(connectionString);
}
