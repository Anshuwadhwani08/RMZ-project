using Microsoft.EntityFrameworkCore;
using rmz_meter_project.MeterDbcontext;
using rmz_meter_project.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<meterDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("meterDbConnection"));
});

builder.Services.AddScoped<ImeterRepository, meterRepository>();
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
