using BankingAPI;
using BankingAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection of IBankingOperations interface and AccountHolderDetails class
builder.Services.AddScoped<IBankingOperations, BankingOperations>();
builder.Services.AddScoped<IAccountHolderDetails, AccountHolderDetails>();

var app = builder.Build();

//Commenting the below lines 
//creating a new ServiceCollection() inside Program.cs and manually building another service provider.
//That bypasses ASP.NET Core’s DI container, so your BankingController isn’t properly wired in the real app pipeline.
//Swagger can’t instantiate the controller, so the OpenAPI endpoint fails.

/*var serviceProvider = new ServiceCollection();

        serviceProvider.AddSingleton<IBankingOperations, BankingOperations>();
        serviceProvider.AddSingleton<BankingController>();

var services=serviceProvider.BuildServiceProvider();

var bankingController = services.GetRequiredService<BankingController>();*/



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
