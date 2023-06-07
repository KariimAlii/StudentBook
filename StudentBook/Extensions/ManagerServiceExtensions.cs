using StudentBook.BussinessLayer;
namespace StudentBook.PresentationLayer
{
    public static class ManagerServiceExtensions
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentManager, StudentManager>();
            return services;
        }
    }
}
