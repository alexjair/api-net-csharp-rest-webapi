using Microsoft.EntityFrameworkCore; //DbContext
using api_net_csharp_rest_webapi.Models; //importante

namespace api_net_csharp_rest_webapi;

//Tiene toda la donfiguracion para crear la DB
public class TareasContext: DbContext
{
    /*******************[ CONFIGURACION ]**********************/
    //CREAR SET DE DATOS: DEL MODELO
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    //MIO: METODO BASE DE CONSTRUCTOR
    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    /*******************[ CONFIGURACION - FIN ]**********************/    

    
    
    /*******************[ SOBRE ESCRIBIR LOS MODELOS DE DB ]**********************/    
    //----------> Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // INICIALIZAR DATOS - Categoria
        List<Categoria> categoriasInit = new List<Categoria>(); //--main

        // Generar KEY-ID
            // generar new id, de forma automatica
            // CategoriaId = Guid.NewGuid(), 

            // codigos fijos para , key foraneas
            // https://guidgenerator.com/

        categoriasInit.Add(new Categoria() { 
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), 
            Nombre = "Actividades pendientes", 
            Peso = 20
        });
        categoriasInit.Add(new Categoria() { 
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), 
            Nombre = "Actividades personales", 
            Peso = 50
        });

        //----------------- FLUET API: MODIFICAR CONFIG. MODELOS DB --------------
        // CATEGORIA
        modelBuilder.Entity<Categoria>(categoria=> 
        {
            categoria.ToTable("Categoria");
            //Key
            categoria.HasKey(p=> p.CategoriaId);
            //Requerido, MaxLength
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            //No es Requerido, MaxLength
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.Property(p=> p.FechaInicio);
               
            //Agregar los datos iniciales
            categoria.HasData(categoriasInit);
        });

        //----------------- FLUET API: MODIFICAR CONFIG. MODELOS DB --------------
        // TAREA

        // INICIALIZAR DATOS - Tarea
        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() { 
            TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), 
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), 
            PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", 
            FechaCreacion = DateTime.Now 
        });
        tareasInit.Add(new Tarea() { 
            TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), 
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), 
            PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula en netflix", 
            FechaCreacion = DateTime.Now 
        });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);
            //FOREANA KEY
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            //Requerido max 200
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            //no es requerido
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);
            //Ignora no se crea en la DB
            tarea.Ignore(p=> p.Resumen);

            //Agregar los datos iniciales
            tarea.HasData(tareasInit);
        });

    }
}