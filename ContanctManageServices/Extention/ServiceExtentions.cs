using ContanctManageRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ContanctManageServices.Interfaces;
using ContanctManageServices.Services;

namespace ContanctManageServices.Extention
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
             opts.UseSqlServer(config.GetValue("ConnectionStrings:sqlConnection"), b => b.MigrationsAssembly("ContanctManage")));





        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICreatorContact, CreatorContact>();
            services.AddTransient<ContactServices>(); 
        }
    }
}
