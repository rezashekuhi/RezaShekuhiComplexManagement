using ComplexManagement.Services;
using ComplexManagement.Services.Blooks;
using ComplexManagement.Services.Blooks.Contract;
using ComplexManagement.Services.Complexes;
using ComplexManagement.Services.Complexes.Contracts;
using ComplexManagement.Services.ComplexUsageTypes;
using ComplexManagement.Services.ComplexUsageTypes.Contact;
using ComplexManagement.Services.units;
using ComplexManagement.Services.units.Contact;
using ComplexManagement.Services.UsageTypes;
using ComplexManagement.Services.UsageTypes.Contract;
using ComplexManagment;
using ComplexManagment.Persistence.Ef;
using ComplexManagment.Persistence.Ef.Repositories.Blocks;
using ComplexManagment.Persistence.Ef.Repositories.Complexs;
using ComplexManagment.Persistence.Ef.Repositories.ComplexUsageTypes;
using ComplexManagment.Persistence.Ef.Repositories.Units;
using ComplexManagment.Persistence.Ef.Repositories.UsageTypes;
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
builder.Services.AddScoped<UnitOfWork,EfUnitOfWork>();
builder.Services.AddScoped<BlookService,BlookAppService>();
builder.Services.AddScoped <ComplexService,ComplexAppService>();
builder.Services.AddScoped <ComplexUsageTypeService,ComplexUsageTypeAppService>();
builder.Services.AddScoped <UnitService,UnitAppService>();
builder.Services.AddScoped <UsageTypeService,UsagetypeAppService>();



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
