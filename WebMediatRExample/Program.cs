using MediatR;
using Microsoft.EntityFrameworkCore;
using WebMediatRExample.Behaviour;
using WebMediatRExample.Data;
using WebMediatRExample.Repozitories.IRepozitory;
using WebMediatRExample.Repozitories.Repozitory;
using WebMediatRExample.Services.ProductServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    //.UseLazyLoadingProxies();
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<FakeDataStore>();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
