using Microsoft.EntityFrameworkCore;
using ModuloAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* Criação da conexão do AgendaContext com a ConexaoPadrao que foi criada no appsettings.Development.json
 builder.services.AddDbContext<AgendaContext> -> está adicionando um Context que seria o AgendaContext
(options =>) adicionando as opções desse context
options.UseSqlServer -> Essa opção irá utilizar o SqlServer
builder.Configuration.GetConnectionString("ConexaoPadrao") -> Está adicionando essa conexão com o SqlServer
a ConnectionString com o nome de "ConexaoPadrao" que foi criada no arquivo JSON chamado appsetting.Development*/
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddControllers();
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
