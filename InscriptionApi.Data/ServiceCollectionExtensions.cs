using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ni_Soft.InscriptionApi.Data.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<InscriptionDbContext>(builder =>
                    builder.UseSqlite(connectionString),
                    ServiceLifetime.Transient, ServiceLifetime.Singleton)
                .AddSingleton<InscriptionDbService>();

            return services;
        }
    }
}
