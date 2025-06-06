using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using TaskManager.Api.Configurations;
using TaskManager.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection();
builder.Services.AddMediator();
builder.Services.AddHttpContextAccessor();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("TaskManager.Application"));
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddDatabaseConfiguration(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler();

app.Run();
