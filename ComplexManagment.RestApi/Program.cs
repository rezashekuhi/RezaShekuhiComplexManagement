using ComplexManagment;
using ComplexManagment.DataLayer;
using ComplexManagment.DataLayer.Repositories.Blocks;
using ComplexManagment.DataLayer.Repositories.Complexs;
using ComplexManagment.DataLayer.Repositories.ComplexUsageTypes;
using ComplexManagment.DataLayer.Repositories.Units;
using ComplexManagment.DataLayer.Repositories.UsageTypes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ComplexRepository, EFComplexRepository>();
builder.Services.AddScoped<BlockRepository, EFBlockRepository>();
builder.Services.AddScoped<UnitRepository, EFUnitRepository>();
builder.Services.AddScoped<UsageTypeRepository, EFUsageTypeRepository>();
builder.Services.AddScoped<ComplexUsageTypeRepository, EFComplexUsageTypeRepository>();
builder.Services.AddScoped<UnitOfWork,EFUnitWork>();



builder.Services.AddDbContext<EFDataContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("SqlServer"));
});

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
