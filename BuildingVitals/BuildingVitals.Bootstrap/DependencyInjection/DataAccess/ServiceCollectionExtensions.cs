using System;
using BuildingVitals.DataAccessContracts.Entities.Identity;
using BuildingVitals.DataAccessImplementations.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingVitals.Bootstrap.DependencyInjection.DataAccess
{
    internal static class ServiceCollectionExtensions
    {
        internal static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName, "BuildingVitals")));

            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
