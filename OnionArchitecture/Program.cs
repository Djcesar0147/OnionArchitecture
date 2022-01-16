using Application;
using OnionArchitecture.Extensions;
using Persistence;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Reflejar los servicios matriculados en Core/Application/ServicesExtensions
builder.Services.AddApplicationLayer();

//Refrenciamos servicios matriculados en Persistence
builder.Services.AddPersistenceInfraestructure(builder.Configuration);

//Refrenciamos servicios matriculados en Shared
builder.Services.AddSharedInfraestructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Rerencia a ./Middlewares
app.UseErrorHandlingMiddleware();


app.Run();

