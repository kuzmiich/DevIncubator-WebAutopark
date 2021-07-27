using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.Specification;

namespace WebAutopark.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddDetailService(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<Detail>, DetailRepository>(_ => new DetailRepository(new DbConnectionBuilder(connectionString)));
        }
        public static void AddVehicleService(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<Vehicle>, VehicleRepository>(_ => new VehicleRepository(new DbConnectionBuilder(connectionString)));
        }
        public static void AddVehicleTypeService(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<VehicleType>, VehicleTypeRepository>(_ => new VehicleTypeRepository(new DbConnectionBuilder(connectionString)));
        }
    }
}
