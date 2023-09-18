using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using aspnet_boilerplate_mvc.Services.Auths;
using aspnet_boilerplate_mvc.Services.Notifications;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System;

namespace aspnet_boilerplate_mvc
{
    public static class ServiceContract
    {
        public static void DbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    var version = new Version("7.0.4");
                    npgsqlOptions.SetPostgresVersion(version);
                });
            });
        }
        public static void IdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                     .AddEntityFrameworkStores<AppDbContext>()
                     .AddDefaultTokenProviders();
        }

        public static void ServiceConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAuthService,AuthService>();

        }
        public static void HangfireConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string hangfireConnectionString = configuration.GetConnectionString("HangfireDb");

            services.AddHangfire(config => config
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseStorage(
                    new PostgreSqlStorage(
                        hangfireConnectionString,
                        new PostgreSqlStorageOptions
                        {
                            QueuePollInterval = TimeSpan.FromSeconds(10),
                            JobExpirationCheckInterval = TimeSpan.FromHours(1),
                            CountersAggregateInterval = TimeSpan.FromMinutes(5),
                            PrepareSchemaIfNecessary = true
                        }
                    )
                )
            );

            services.AddHangfireServer();
        }
    }
}
    

