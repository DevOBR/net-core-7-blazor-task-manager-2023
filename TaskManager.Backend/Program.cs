using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Repository.Repositories;
using TaskManager.Repository.Interfaces;
using TaskManager.Service.Interfaces;
using TaskManager.Service.Services;
using TaskManager.Backend.Options;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

builder.Services.AddDbContext<DataContext>
(
    (serviceProvider, dbContextOptionBuilder) =>
    {
        var dataBaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

        dbContextOptionBuilder.UseSqlServer
        (
            dataBaseOptions.ConnectionString,
            sqlServerAction =>
            {
                sqlServerAction.MigrationsAssembly(dataBaseOptions.MigrationsAssemblyName);
                sqlServerAction.EnableRetryOnFailure(dataBaseOptions.MaxTryCount);
                sqlServerAction.CommandTimeout(dataBaseOptions.CommandTimeout);
            }
        );

        dbContextOptionBuilder.EnableDetailedErrors(dataBaseOptions.EnableDetailedErrors);
        dbContextOptionBuilder.EnableSensitiveDataLogging(dataBaseOptions.EnabledSensitiveDataLogging);
    }
);

builder.Services.AddScoped<IMyTaskRepository, MyTaskRepository>();
builder.Services.AddScoped<IMyTaskService, MyTaskService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors(x =>
    x.AllowAnyMethod()
     .AllowAnyHeader()
     .SetIsOriginAllowed(origin => true)
     .AllowCredentials());

app.Run();

