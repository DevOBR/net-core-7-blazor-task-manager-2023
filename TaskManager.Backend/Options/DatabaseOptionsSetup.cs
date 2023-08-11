using Microsoft.Extensions.Options;

namespace TaskManager.Backend.Options
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        private const string DatabaseOptionsName = "DatabaseOptions";
        private readonly IConfiguration _configuration;

        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options)
        {
            var connectionString = _configuration.GetConnectionString("DockerConnection");
            options.ConnectionString = connectionString;

            _configuration.GetSection(DatabaseOptionsName).Bind(options);
        }
    }
}

