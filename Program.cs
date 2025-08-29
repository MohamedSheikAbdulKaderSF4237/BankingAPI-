using BankingAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var serviceProvider = new ServiceCollection();

        serviceProvider.AddSingleton<IBankingOperations, BankingOperations>();
        serviceProvider.AddSingleton<BankingController>();

var services=serviceProvider.BuildServiceProvider();

var bankingController = services.GetRequiredService<BankingController>();

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
