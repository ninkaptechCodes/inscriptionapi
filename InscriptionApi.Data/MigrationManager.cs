using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Data
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var dbService = scope.ServiceProvider.GetRequiredService<InscriptionDbService>();
                try
                {
                    dbService.Migrate();
                }
                catch (Exception ex)
                {
                    //Log.Fatal(ex, $"{nameof(MigrationManager.MigrateDatabase)} failed to execute migration");
                    throw;
                }
            }
            return host;
        }

    }
}
