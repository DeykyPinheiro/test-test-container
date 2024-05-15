using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;

namespace api.IntegrationTests
{
    public class apiWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
              .Build();

        public async Task InitializeAsync()
        {
            await _postgres.StartAsync();

            Environment.SetEnvironmentVariable("ConnectionStrings:Database", _postgres.GetConnectionString());
        }

        public async Task DisposeAsync()
        {
            await _postgres.DisposeAsync().AsTask();
        }

        [Fact]
        public async Task ExecuteCommand()
        {
            using var connection = new NpgsqlConnection(_postgres.GetConnectionString());
            using var command = new NpgsqlCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT 1";
            command.ExecuteReader();
        }

    }
}
