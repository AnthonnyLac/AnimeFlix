using AnimeFlix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.WebApi.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AnimeFlixContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));



        }
    }
}
