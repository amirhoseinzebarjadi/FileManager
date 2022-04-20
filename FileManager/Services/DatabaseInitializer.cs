using System;
using FileManager.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FileManager.Services
{
    public static class ServiceProviderExtensions
    {
        public static void MigrateDatabases(this IServiceProvider provider)
        {
            using (provider.CreateScope())
            using (var context = provider.GetRequiredService<AppDbContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}
