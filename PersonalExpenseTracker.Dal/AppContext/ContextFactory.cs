using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Text.Json;

namespace PersonalExpenseTracker.Dal.AppContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            var apiAppSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "PersonalExpenseTracker.Api", "appsettings.json");
            var jsonContent = File.ReadAllText(apiAppSettingsPath);

            var configJson = JsonSerializer.Deserialize<JsonElement>(jsonContent);

            var connectionString = configJson.GetProperty("ConnectionStrings")
                .GetProperty("DefaultConnection")
                .GetString();

            optionsBuilder.UseSqlServer(connectionString);

            return new Context(optionsBuilder.Options);
        }
    }
}