
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestFulASPNET.Configs;
using RestFulASPNET.DTOs.Repositories;
using RestFulASPNET.Exceptions;
using RestFulASPNET.Features.Users.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceConfiguration.ConfigureService(builder.Services);

// Add Repository
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();


//DataBase
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// global error handle
app.UseMiddleware<ErrorHandlerMiddleware>();
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

