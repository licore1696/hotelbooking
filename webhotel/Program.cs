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

builder.Services.AddScoped<IUserRepository, UserRepository>();//singleton
builder.Services.AddScoped<IUserService,UserService>();//singleton

builder.Services.AddScoped<IHotelRepository, HotelRepository>();//singleton
builder.Services.AddScoped<IHotelService, HotelService>();//singleton

builder.Services.AddScoped<IBookingRepository, BookingRepository>();//singleton
builder.Services.AddScoped<IBookingService, BookingService>();//singleton

builder.Services.AddScoped<IRoomRepository, RoomRepository>();//singleton
builder.Services.AddScoped<IRoomService, RoomService>();//singleton

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();//singleton
builder.Services.AddScoped<IReviewService, ReviewService>();//singleton


builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddAutoMapper(typeof(HotelProfile));

builder.Services.AddAutoMapper(typeof(ReviewProfile));

builder.Services.AddAutoMapper(typeof(RoomProfile));

builder.Services.AddAutoMapper(typeof(BookingProfile));



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
