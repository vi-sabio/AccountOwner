using Contracts;
using LoggerService;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Extensions;

    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy", 
                    builder => builder
                    .AllowAnyOrigin()    // WithOrigins("dominio")
                    .AllowAnyMethod()    // WithMethods("POST", "GET")
                    .AllowAnyHeader());  // WithHeaders("accept", "content-type")
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
        
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
           services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureMySqlContexte(this IServiceCollection services, IConfiguration config)
        {
            var conn = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(conn, ServerVersion.AutoDetect(conn)));
        }

    }
