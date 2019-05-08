using System;
using BuildingVitals.DataAccessContracts.Entities.Identity;
using BuildingVitals.DataAccessContracts.Repositories;
using BuildingVitals.DataAccessImplementations.Context;
using BuildingVitals.DataAccessImplementations.Repositories;
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

            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            services.AddScoped<IMetricRepository, MetricRepository>();

            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
