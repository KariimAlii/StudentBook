using StudentBook.DataAccessLayer;

namespace StudentBook.PresentationLayer
{
    public static class RepoServiceExtensions
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentRepo, StudentRepo>();
            return services;
        }
    }
}
