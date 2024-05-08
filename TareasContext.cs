using Microsoft.EntityFrameworkCore;
using efdemo.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Routing.Matching;

namespace efdemo;



public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Tarea> tareasInit =
        [
            new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoriaId = Guid.Parse("4147cfc2-63f8-412e-b89c-5583776da0e2"),  Titulo = "Pago de servicios publicos", Descripcion="aaaa", Pesos = 20, PrioridadTarea = Prioridad.Media, FechaCreacion = DateTime.Now},
            new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac53-da0540dfb411"), CategoriaId = Guid.Parse("4147cfc2-63f8-412e-b89c-5583776da0e2"),  Titulo = "Terminar de ver pelicula en netflix", Descripcion ="bbbb", Pesos = 20,PrioridadTarea = Prioridad.Baja,  FechaCreacion = DateTime.Now},
        ];


modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");                                                     // indica que es una tabla
            tarea.HasKey(t => t.TareaId);                                               // indica que es la clave primaria
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId).IsRequired(false);// indica que una tarea tiene una categoria y una categoria tiene muchas tareas
            tarea.Property(t => t.Titulo).IsRequired(false).HasMaxLength(200);               // indica que es un campo obligatorio y su tamaño máximo es 200
            tarea.Property(t => t.Descripcion);
             tarea.Property(t => t.Pesos);                                      // indica que es un campo opcional
            tarea.Property(t => t.PrioridadTarea).HasConversion(                        // indica que es un campo con una conversión de tipo enumerado
                v => v.ToString(),
                v => (Prioridad)Enum.Parse(typeof(Prioridad), v));
            tarea.Ignore(i =>i.resumen);
            tarea.HasData(tareasInit);
        });


       List<Categoria> categoriasInit =
       [
           new Categoria() { CategoriaId = Guid.Parse("990f2aab-3833-404d-bc2d-878096fadb03"), Nombre = "Actividades pendientes", Descripcion="llll"},
           new Categoria() { CategoriaId = Guid.Parse("4147cfc2-63f8-412e-b89c-5583776da0e2"), Nombre = "Actividades personales", Descripcion="mmmmmm"},
       ];


        modelBuilder.Entity<Categoria>( categoria =>{
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p => p.Descripcion);

              categoria.HasData(categoriasInit);
        });

        



}

}


  