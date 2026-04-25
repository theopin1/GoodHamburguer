using FluentValidation;
using FluentValidation.AspNetCore;
using GoodHamburger.Api.Controllers;
using GoodHamburger.Application.Commands.PedidoCommands;
using GoodHamburger.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CadastrarPedidoCommand).Assembly));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(PedidoController).Assembly);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 4, 4))
    ));

builder.Services.AddValidatorsFromAssemblyContaining<CadastrarPedidoCommandValidator>();

builder.Services.AddFluentValidationAutoValidation();


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
