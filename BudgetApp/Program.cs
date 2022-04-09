using BudgetApp.Core.Repositories;
using BudgetApp.Data.DbContext;
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


builder.Services.AddTransient<UsersRepository>();


builder.Services.AddControllers();

var connectionString = configuration.GetConnectionString("budgetContext");
builder.Services.AddDbContext<BudgetContext>(
    opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


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
app.Run();