using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace WebAPI.Extensions
{
    //Burada servisleri kayıt edeceğiz, amacımız program.cs kalabalık olmasın 
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
    }
}
