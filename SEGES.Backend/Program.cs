using Microsoft.EntityFrameworkCore;
using SEGES.Backend.Repositories.Implementations;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Implementations;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SIEGESConnection"));
});

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<ICountriesUnitOfWork, CountriesUnitOfWork>();

builder.Services.AddScoped<IStateRepository, StatesRepository();
builder.Services.AddScoped<IStateUnitOfWork, StatesUnitOfWork>();

builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<ICitiesUnitOfWork, CitiesUnitOfWork>();

builder.Services.AddScoped<IDocTraceabilityTypesRepository, DocTraceabilityTypesRepository>();
builder.Services.AddScoped<IDocTraceabilityTypesUnitOfWork, DocTraceabilityTypesUnitOfWork>();

builder.Services.AddScoped<IHuAppruvalStatusRepository, HuAppruvalStatusRepository>();
builder.Services.AddScoped<IHuApprovalStatusUnitOfWork, HuApprovalStatusUnitOfWork>();

builder.Services.AddScoped<IHUPrioritiesRepository, HUPrioritiesRepository>();
builder.Services.AddScoped<IHUPrioritiesUnitOfWork, HUPrioritiesUnitOfWork>();

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
