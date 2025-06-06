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
builder.Services.AddHttpContextAccessor();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("TaskManager.Application"));
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapOpenApi();
app.UseSwagger();
app.UseExceptionHandler();

app.Run();
