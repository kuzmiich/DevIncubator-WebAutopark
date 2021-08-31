using Microsoft.Extensions.DependencyInjection;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.DataAccess.Repositories;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.ExtendRepository;

namespace WebAutopark.Extensions
{
    public static class DIExtension
    {
        public static void AddEntityRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<DetailViewModel>, DetailRepository>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();

            services.AddScoped<IRepository<VehicleTypeViewModel>, VehicleTypeRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IRepository<OrderDetailViewModel>, OrderDetailRepository>();
        }
    }
}
