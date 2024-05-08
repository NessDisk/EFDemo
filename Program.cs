

using efdemo;
using efdemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cntareas")); 

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("dbconexion", async ([FromServices] TareasContext dbContext) =>{

    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+ dbContext.Database.IsInMemory());
    
    });

    app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) => 
{
		var tareas = await dbContext.Tareas.ToListAsync();
		return Results.Ok(tareas);
});

// app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>
// {
//     return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria).Where(p=> p.PrioridadTarea == efdemo.Models.Prioridad.Baja));
// });
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea homeworks) =>
{
	homeworks.TareaId = Guid.NewGuid();
	homeworks.FechaCreacion = DateTime.Now;
	await dbContext.Tareas.AddAsync(homeworks);
	await dbContext.SaveChangesAsync();
	return Results.Ok(homeworks);
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea homeworks, [FromRoute] Guid id) =>
{

	var tarea = await dbContext.Tareas.FindAsync(id);
	if (tarea == null)
	{
		return Results.NotFound();
	}
	tarea.Titulo = homeworks.Titulo;
	tarea.Descripcion = homeworks.Descripcion;
	tarea.PrioridadTarea = homeworks.PrioridadTarea;
	tarea.resumen = homeworks.resumen;
	tarea.CategoriaId = homeworks.CategoriaId;
	await dbContext.SaveChangesAsync();
	return Results.Ok(tarea);
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
	var tarea = await dbContext.Tareas.FindAsync(id);
	if (tarea == null)
	{
		return Results.NotFound();
	}
	dbContext.Tareas.Remove(tarea);
	await dbContext.SaveChangesAsync();
	return Results.Ok(tarea);
});


app.Run();
