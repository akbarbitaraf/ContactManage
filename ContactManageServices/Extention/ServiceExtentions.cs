using ContactManageRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ContactManageServices.Interfaces;
using ContactManageServices.Services;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace ContactManageServices.Extention
{
    public static class ServiceExtentions
    {
        //public static void ConfigureCors(this IServiceCollection services) =>
        //  services.AddCors(options =>
        //  {
        //      options.AddPolicy("AllowAll", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("X-Pagination"); });
        //  });
        public static void ConfiqureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new ConfigurationHelper.ConfigurationHelper(configuration);
            services.AddSingleton<ConfigurationHelper.ConfigurationHelper>(config);

            services.AddDbContext<ContactManageContext>(opts =>
             opts.UseSqlServer(config.GetValue("ConnectionStrings:sqlConnection"), b => b.MigrationsAssembly("ContactManage")));

        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddLogging(builder => { builder.SetMinimumLevel(LogLevel.Information); builder.AddNLog("nlog.config"); });
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICreatorContact, CreatorContact>();
            services.AddScoped<IGlobalServices,GlobalServices>();
            services.AddTransient<ContactServices>();
            services.ConfigureLoggerService();

        }
    }
}
