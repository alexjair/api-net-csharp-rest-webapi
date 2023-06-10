namespace api_net_csharp_rest_webapi.Middlewares
{
    public class TimeMiddleware
    {
        public TimeMiddleware(
            RequestDelegate _nextRequest        
        ){
            next = _nextRequest;
        }

        readonly RequestDelegate next;

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            //Modo 02, despues de la peticion http
            if (context.Request.Query.Any(
                p=>
                p.Key == "time"
                )
            ){
                await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
                return;
            }

            await next(context);
            
            //Modo 01, antes de la peticion http
            /*
            await next(context);

            if (context.Request.Query.Any(
                p=>
                p.Key == "time"
                )
            ){
                await context.Response.WriteAsync(DateTime.Now.ToString());
            }
            */
        }
    }

    //Agregar el middleware dentro de la configuracion
    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
