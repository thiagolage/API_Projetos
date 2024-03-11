global using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;
using ProjetosAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using ProjetosAPI.Database;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureService()
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "API Thiago - EclipseWorks", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<ProjetosAPIContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetosAPI"))
);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); //Injetando a dependência
builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>(); 
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>(); 
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<ILogTarefaRepository, LogTarefaRepository>();
builder.Services.AddScoped<ILogComentarioRepository, LogComentarioRepository>();
#endregion

var app = builder.Build();

#region Configure()
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
#endregion