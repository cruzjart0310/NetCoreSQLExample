using Example.NetCore.DataAccess.Base;
using Example.NetCore.DataAccess.Contracts;
using Example.NetCore.DataAccess.Models;
using Example.NetCore.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddTransient<ISurveyRepository, SurveyRepository>();

//builder.Services.AddTransient<IDataAccess, IDataAccess>();

RegisterAssembly("Example.NetCore.DataAccess", builder.Services);


builder.Services.Configure<AppSettings>(configuration)
                            .AddSingleton(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/// <summary>
/// Auxiliary method to record the injection of dependencies
/// </summary>
/// <param name="assembly"></param>
/// <param name="services"></param>
void RegisterAssembly(string assembly, IServiceCollection services)
{
    var DataAccessAssembly = System.Reflection.Assembly.Load(assembly);

    var registrationsDataAccess = from type in DataAccessAssembly.GetExportedTypes()
                                  where type.GetInterfaces().Any()
                                  select new { service = type.GetInterfaces().First(), implementation = type };

    foreach (var reg in registrationsDataAccess)
    {
        services.AddScoped(reg.service, reg.implementation);
    }
}
