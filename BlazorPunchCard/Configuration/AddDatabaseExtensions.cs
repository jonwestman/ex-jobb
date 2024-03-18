using BlazorPunchCard.Config;
using BlazorPunchCard.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorPunchCard.Configuration
{
    public static class AddDatabaseExtensions
    {
        public static void AddDatabase(this IServiceCollection service, IConfiguration configuration) 
        {
            service.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString(nameof(AppConfiguration.DefaultConnection))));
        }
    }
}
