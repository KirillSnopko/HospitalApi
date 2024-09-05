using Application;
using HospitalApi.Middlewares;
using Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var lifetime = app.Lifetime;
var logger = app.Logger;


lifetime.ApplicationStarted.Register(() => logger.LogWarning("The application started..."));
lifetime.ApplicationStopped.Register(() => logger.LogWarning("The application stopped..."));

using (var scope = app.Services.CreateScope())
{
    var migrationRunner = scope.ServiceProvider.GetService<IAutomaticDbMigrationService>();
    migrationRunner?.Run();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
