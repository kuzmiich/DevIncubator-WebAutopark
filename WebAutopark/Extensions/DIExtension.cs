using Microsoft.Extensions.DependencyInjection;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.Extensions
{
    public static class DIExtension
    {
        public static void AddEntityRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Detail>, DetailRepository>();

            services.AddScoped<IRepository<Vehicle>, VehicleRepository>();

            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
        }
    }
}
