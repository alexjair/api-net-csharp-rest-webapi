using api_net_csharp_rest_webapi.Models;

namespace api_net_csharp_rest_webapi.Services
{
    public class CategoriaService : ICategoriaService
    {
        TareasContext context;

        public CategoriaService(TareasContext _tareasContext) {
            context = _tareasContext;
        }

        //GET
        public IEnumerable<Categoria> Get() {
            return context.Categorias;
        }

        //INSERT
        public async Task Save(Categoria objRow) {
            context.Add(objRow);
            await context.SaveChangesAsync();
        }

        //DELETE
        public async Task Delete(Guid id)
        {
            var objRowActual = context.Categorias.Find(id);
            if (objRowActual != null)
            {
                context.Remove(objRowActual);
                await context.SaveChangesAsync();
            }
        }

        //UPDATE
        public async Task Update(Guid id, Categoria objRow) {
            var objRowActual = context.Categorias.Find(id);
            if (objRowActual != null)
            {
                objRowActual.Nombre = objRow.Nombre;
                objRowActual.Descripcion = objRow.Descripcion;
                objRowActual.Peso = objRow.Peso;

                await context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Task Save(Categoria objRow);
        Task Delete(Guid id);
        Task Update(Guid id, Categoria objRow);
    }

}
