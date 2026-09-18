using Microsoft.EntityFrameworkCore;
using ServiceFlow.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
var password = builder.Configuration["MSSQL_SA_PASSWORD"];

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")!
    .Replace("PLACEHOLDER", password);
    
builder.Services.AddDbContext<ServiceFlowDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();