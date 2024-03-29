using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Core.Entities;
using Infrastrucure.Data;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
options.AddPolicy("CorsPolicy", policy =>
{
    policy.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin();
}));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");

/**********************Migration if there is any new changes************************/
using var scope = app.Services.CreateScope();
var Services = scope.ServiceProvider;
var context = Services.GetRequiredService<StoreContext>();
var Logger = Services.GetRequiredService<ILogger<Program>>();

try
{
    
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);

}
catch (Exception ex)
{
    Logger.LogError(ex, "Error occured while migrating process");
}

app.Run();
