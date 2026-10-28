using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class DapperContext
{
    public string connectionString = "Host=localhost;Port=5432;Database=MiniShopDB;Username=postgres;Password=p000";
    public IDbConnection Connection() => new NpgsqlConnection(connectionString);
}
