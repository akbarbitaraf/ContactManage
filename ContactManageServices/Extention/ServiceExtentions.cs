using ContactManageRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ContactManageServices.Interfaces;
using ContactManageServices.Services;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Memory;

namespace ContactManageServices.Extention
{
    public static class ServiceExtentions
    {
        // if exist migration not generate to DB in time run program run migration or handle : update-database 
        public static void ConfigureMigration(this IApplicationBuilder app)
        {
            try
            {
                using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    scope.ServiceProvider.GetService<ContactManageContext>().Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void ConfiqureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new ConfigurationHelper.ConfigurationHelper(configuration);
            services.AddSingleton<ConfigurationHelper.ConfigurationHelper>(config);

            services.AddDbContext<ContactManageContext>(opts =>
             opts.UseSqlServer(config.GetValue("ConnectionStrings:sqlConnection"), b => b.MigrationsAssembly("ContactManage")));

        }
        // use package nlog for logger
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddLogging(builder => { builder.SetMinimumLevel(LogLevel.Information); builder.AddNLog("nlog.config"); });
        }

        // add servicess in program  with centeral method
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ICreatorContact, CreatorContact>();
            services.AddScoped<IGlobalServices,GlobalServices>();
            services.AddTransient<ContactServices>();
            //services.AddScoped<IMemoryCache>();
            services.ConfigureLoggerService();

        }
    }
}
