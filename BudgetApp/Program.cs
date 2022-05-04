using System.Threading.Tasks;
using BudgetApp.AuthMiddleware;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Core.Interfaces.Services;
using BudgetApp.Core.Repositories;
using BudgetApp.Core.Services;
using BudgetApp.Database;
using BudgetApp.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


builder.Services.AddControllers();
AddServices(builder);

var connectionString = configuration.GetConnectionString("budgetContext");
builder.Services.AddDbContext<BudgetContext>(
    opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        mysqlOptions => mysqlOptions.MigrationsAssembly("BudgetApp.Database")));



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

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void AddServices(WebApplicationBuilder builder)
{
    #region Repositories

    builder.Services.AddScoped<IUsersRepository, UsersRepository>();

    #endregion

    #region Services

    builder.Services.AddScoped<IUsersService, UsersService>();
    builder.Services.AddScoped<IAuthService, AuthService>();

    #endregion
}