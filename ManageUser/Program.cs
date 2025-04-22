using Microsoft.EntityFrameworkCore;
using ManagerUser.Context;
using ManagerUser.DAO;
using ManagerUser.Repository;
using System.Text.Json;
using System.Text.Json.Serialization;
using ManagerUser.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter()); // Nếu có custom converter
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.WriteIndented = true;
    
    // Thêm cấu hình này để format DateTime
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
});

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging(); // Thêm dòng này
});

// Register DAO and Repository
builder.Services.AddScoped<UserDAO>();
builder.Services.AddScoped<UserRepository>();

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
