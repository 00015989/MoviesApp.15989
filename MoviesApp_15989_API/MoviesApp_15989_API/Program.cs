using MoviesApp_15989_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext for Movies
builder.Services.AddDbContext<MoviesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers for the API
builder.Services.AddControllers();

// Enable Swagger documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Movies API",
        Version = "v1",
        Description = "This project is developed by Student ID: 15989"
    });
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()       // Allow any origin (you can restrict this in production)
              .AllowAnyMethod()       // Allow any HTTP method (GET, POST, DELETE, etc.)
              .AllowAnyHeader();      // Allow any header
    });
});

// Add endpoints API explorer (for Swagger)
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Enable Swagger in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API v1");
    });
}

// Enable CORS middleware
app.UseCors("AllowAll"); // Apply the CORS policy to all requests

// Enable authorization
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();
