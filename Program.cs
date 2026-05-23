using ComputerManagementApi.Data;
using ComputerManagementApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPcService, PcService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
