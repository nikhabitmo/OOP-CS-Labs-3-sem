using ApplicationModels.Users;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace Infrastructure.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
#pragma warning disable CA1062
        builder.MapEnum<UserRole>();
#pragma warning restore CA1062
    }
}