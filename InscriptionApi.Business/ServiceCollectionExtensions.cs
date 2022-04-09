using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ni_Soft.InscriptionApi.Business.Interfaces;
using Ni_Soft.InscriptionApi.Business.Services;
using Ni_Soft.InscriptionApi.Data;
using System;

namespace Ni_Soft.InscriptionApi.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("InscriptionDbContext");

            services
                .AddPersistance(connectionString);
            services
                .AddSingleton<ICustomerService, CustomerService>()

                ;


            return services;
        }

        public static IHost Migrate(this IHost host)
        {
            return host.MigrateDatabase();
        }
    }
}
