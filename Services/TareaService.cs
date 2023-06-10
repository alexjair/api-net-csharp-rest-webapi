using api_net_csharp_rest_webapi.Models;

namespace api_net_csharp_rest_webapi.Services
{
    public class TareaService : ITareaService
    {
        TareasContext context;

        public TareaService(
            TareasContext _context
        )
        {
            context = _context;
        }

        //[GET]
        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }

        //[INSERT]
        public async Task Save(Tarea objRow)
        {
            context.Tareas.Add(objRow);
            await context.SaveChangesAsync();
        }

        //[DELTE]
        public async Task Remove(Guid id)
        {
            var objRowActual = context.Tareas.Find(id);
            if (objRowActual != null)
            {
                context.Remove(objRowActual);
                await context.SaveChangesAsync();
            }
        }

        //UPDATE
        public async Task Update(Guid id, Tarea objRow)
        {
            var objRowActual = context.Tareas.Find(id);
            if (objRowActual != null)
            {
                objRowActual.Titulo = objRow.Titulo;
                objRowActual.Descripcion = objRow.Descripcion;

                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea objRow);
        Task Remove(Guid id);
        Task Update(Guid id, Tarea objRow);

    }
}
