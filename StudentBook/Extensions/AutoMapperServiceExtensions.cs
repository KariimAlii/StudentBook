using AutoMapper;
using StudentBook.BussinessLayer;

namespace StudentBook.PresentationLayer
{
    public static class AutoMapperServiceExtensions
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
            IMapper mapper = automapper.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
