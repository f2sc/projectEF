using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using projectEF.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) => 
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    
    //Se puede guardar de 2 formas:
    await dbContext.AddAsync(tarea); //1
    //await dbContext.Tareas.AddAsync(tarea); //2

    await dbContext.SaveChangesAsync();

    return Results.Ok("Insertado correctamente la tarea " + tarea.Titulo);
});


app.MapGet("/api/tareas/baja", async ([FromServices] TareasContext dbContext) => 
{
    var listaTareas = dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == Prioridad.Baja);
    if (listaTareas.Count() == 0)
    {
        return Results.Ok("No hay tareas con esta prioridad.");
    }
    else
    {
        return Results.Ok(listaTareas);
    }
});

app.MapGet("/api/tareas/media", async ([FromServices] TareasContext dbContext) => 
{
    var listaTareas = dbContext.Tareas.Include(p => p.Categoria)
    .Where(p => p.PrioridadTarea == Prioridad.Media);
    if (listaTareas.Count() == 0)
    {
        return Results.Ok("No hay tareas con esta prioridad.");
    }
    else
    {
        return Results.Ok(listaTareas);
    }
});

app.MapGet("/api/tareas/alta", async ([FromServices] TareasContext dbContext) => 
{
    var listaTareas = dbContext.Tareas.Include(p => p.Categoria)
    .Where(p => p.PrioridadTarea == Prioridad.Alta);
    if (listaTareas.Count() == 0)
    {
        return Results.Ok("No hay tareas con esta prioridad.");
    }
    else
    {
        return Results.Ok(listaTareas);
    }
});

app.Run();
