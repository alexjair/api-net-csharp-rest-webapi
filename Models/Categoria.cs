using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

/********[ DATA-NONATION]*********/
/*
[Table("Task")]
[Key]
[Required]
[MaxLength(150)]
*/

namespace api_net_csharp_rest_webapi.Models;

public class Categoria
{
    //[Key]
    public Guid CategoriaId {get;set;}
    
    //[Required]
    //[MaxLength(150)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    
    public int Peso {get;set;}

    public DateTime FechaInicio {get;set;}

    //relacion de categioria 
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}

}