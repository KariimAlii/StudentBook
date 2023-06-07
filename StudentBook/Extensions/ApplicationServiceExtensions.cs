using Microsoft.EntityFrameworkCore;
using StudentBook.CoreLayer;

namespace StudentBook.PresentationLayer
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddDbContext<StudentBookContext>(options =>
            {
                var LocalConnectionString = services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("LocalConnectionString");
                options.UseSqlServer(LocalConnectionString);
            });
            return services;
        }
    }
}
