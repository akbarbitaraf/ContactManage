//using EmployeePanelEntities.Entities.Mapper;
//using EmployeePanelServices.Exceptions;
//using EmployeePanelServices.Extentions;
//using EmployeePanelServices.Interfaces;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text.Json.Serialization;
//using EmployeePanelEntities.Entities.Enums;
//using EmployeePanelEntities;
//using EmployeePanelTools;
using ContactManageEntities.Mapper;
using ContactManageServices.Extention;
using ContactManageServices.Interfaces;
using ContactManage.Exceptions;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.ConfiqureSqlContext(configuration);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.ConfigureServices();
builder.Services.BuildServiceProvider().GetService<IGlobalServices>().SeedBaseTable();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactManage", Version = "v1" });
});

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowAll");

var storage_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");
if (!Directory.Exists(storage_path)) Directory.CreateDirectory(storage_path);
app.UseFileServer(new FileServerOptions { FileProvider = new PhysicalFileProvider(storage_path), RequestPath = "/Storage", EnableDefaultFiles = true });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.Use(async (context, next) =>
{
    await next();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.ConfigureMigration();
app.Run();
