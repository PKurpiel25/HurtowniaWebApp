using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Entities
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<HurtowniaDbContext>();
                try
                {
                    appContext.Database.Migrate();
                }
                catch
                {
                    throw;
                }
            }
            return webApp;
        }

    }
}
