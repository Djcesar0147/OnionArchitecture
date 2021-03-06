using Application;
using Application.Feautres.Persona.Commands.CreatePersonaCommand;
using Application.Feautres.Persona.Commands.DeletePersonaCommand;
using Application.Feautres.Persona.Commands.UpdatePersonaCommand;
using Application.Feautres.Persona.Queries.GetPersonaById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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



app.MapGet("Persona/{personaId}", async (int personaId, HttpContext httpContext, IMediator mediator, LinkGenerator links) =>
{
    var result = await mediator.Send(new GetPersonaByIdQuery { personaId = personaId });
    return result;
});

app.MapPost("Persona", async (HttpContext httpContext, IMediator mediator, LinkGenerator links, CreatePersonaCommand command) =>
{
    var result = await mediator.Send(command);
    return result;
});

app.MapPut("Persona", async (HttpContext httpContext, IMediator mediator, LinkGenerator links, UpdatePersonaCommand command) =>
{
    var result = await mediator.Send(command);
    return result;
});

app.MapDelete("Persona/{personaId}", async (int personaId, HttpContext httpContext, IMediator mediator, LinkGenerator links) =>
{
    var result = await mediator.Send(new DeletePersonaCommand { persona_Id = personaId});
    return result;
});


app.Run();

