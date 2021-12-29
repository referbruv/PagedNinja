using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PagedNinja.Core.Data.Services;
using PagedNinja.Persistence.Data;
using PagedNinja.Persistence.Data.Services;

namespace PagedNinja.Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<MyBlogContext>(options =>
            {
                options.LogTo(Console.WriteLine);
                options.UseSqlite("Data Source=app.db");
            });

            return services.AddScoped<IDataService, DataService>();
        }
    }
}
