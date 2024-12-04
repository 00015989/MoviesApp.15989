using MoviesApp_15989_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// Student ID: 15989

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MoviesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo      
    {
        Title = "Movies API",
        Version = "v1",
        Description = "This project is developed by Student ID: 15989"
    });
});

builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API v1");
    });
}
app.UseAuthorization();
app.MapControllers();
app.Run();
