using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            services.AddScoped<IRepository<Order>, OrderRepository>();

            services.AddScoped<IRepository<OrderDetail>, OrderDetailRepository>();
        }
    }
}
