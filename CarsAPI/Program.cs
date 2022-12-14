using CarsAPI.EF;
using CarsAPI.Interfaces;
using CarsAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection //
// How long are we going to be holding the instance for //
// singelton - single instance // 
builder.Services.AddScoped<IMakeRepository, MakeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); 

builder.Services.AddDbContext<CarDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarDB"));
}); 

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
