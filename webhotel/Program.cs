using Microsoft.EntityFrameworkCore;
using HotelBooking.DataAccess;
using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.DataAccess.Repository;
using HotelBooking.Services.Contracts;
using HotelBooking.Services;
using AutoMapper;
using HotelBooking.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection"); 

if (string.IsNullOrEmpty(connectionString))
{
    throw new ApplicationException("Could not load 'Default' connection string");
}

builder.Services.AddDbContext<BookingContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();

builder.Services.AddAutoMapper(typeof(UserProfile));

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
