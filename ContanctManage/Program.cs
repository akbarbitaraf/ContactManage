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
using ContanctManageEntities.Mapper;
using ContanctManageServices.Extention;

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
//builder.Services.BuildServiceProvider().GetService<IGlobalServices>().SeedBaseTable();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContanctManage", Version = "v1" });

    //var securityScheme = new OpenApiSecurityScheme
    //{
    //    Name = "JWT Authentication",
    //    Description = "Enter JWT Bearer token **_only_**",
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.Http,
    //    Scheme = "bearer", // must be lower case
    //    BearerFormat = "JWT",
    //    Reference = new OpenApiReference
    //    {
    //        Id = JwtBearerDefaults.AuthenticationScheme,
    //        Type = ReferenceType.SecurityScheme
    //    }
    //};
    //c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //            {
    //                {securityScheme, new string[] { }}
    //            });
});

var app = builder.Build();
//app.ConfigureCustomExceptionMiddleware();
//app.UseMiddleware<ExceptionMiddleware>();




// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
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

    //if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    //{
    //    GeneralExtentions.ThrowException("Unauthorized", HttpStatus.Unauthorized);


    //}
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
//app.ConfigureMigration();
app.Run();
