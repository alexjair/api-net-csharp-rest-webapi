using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/********[ DATA-NONATION]*********/
/*
[Table("Task")]
[Key]
[ForeignKey("CategoriaId")]
[Required]
[MaxLength(200)]
[ForeignKey("CategoriaId")]
*/

namespace api_net_csharp_rest_webapi.Models;

public class Tarea
{
    //[Key]
    public Guid TareaId {get;set;}
    
    //[ForeignKey("CategoriaId")]
    public Guid CategoriaId {get;set;}

    //[Required]
    //[MaxLength(200)]
    public string Titulo {get;set;}

    public string Descripcion {get;set;}

    public Prioridad PrioridadTarea {get;set;}

    public DateTime FechaCreacion {get;set;}
    
    //proiedades adicionales
    //Relacionar 
    public virtual Categoria Categoria {get;set;}

    //No esta en la DB, Llenar las informacion haciendo un resumen
    //[NotMapped]
    public string Resumen {get;set;}
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}